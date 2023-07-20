using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database.SpecificationExpression.Extensions;

internal static class SpecificationExtension
{
    internal static Specification<TSpecific> Or<TSpecific> (this Specification<TSpecific> left, Specification<TSpecific> right) 
        where TSpecific : class
    {
        return left.Compose(right, Expression.OrElse);
    }

    internal static Specification<TSpecific> And<TSpecific> (this Specification<TSpecific> left, Specification<TSpecific> right) 
        where TSpecific : class
    {
        return left.Compose(right, Expression.AndAlso);
    }

    private static Specification<TSpecific> Compose<TSpecific> (this Specification<TSpecific> left, Specification<TSpecific> right, 
                                                                              Func<Expression, Expression, Expression> op)
        where TSpecific : class
    {
        return SpecificationCache.GetOrAdd(left, right, () =>
        {
            var newParam = Expression.Parameter(typeof(TSpecific));
            var replacedLeft = Replace<Func<TSpecific, bool>, Func<TSpecific, bool>>(left, newParam);
            var replacedRight = Replace<Func<TSpecific, bool>, Func<TSpecific, bool>>(right, newParam);

            var body = op(replacedLeft.Body, replacedRight.Body);

            return Expression.Lambda<Func<TSpecific, bool>>(body, newParam);
        });
    }

    private static Expression<TOutput> Replace<TInput, TOutput>(Expression<TInput> expression, Expression target)
    {
        return new ParameterReplacerVisitor<TOutput>(expression.Parameters.Single(), target).VisitAndConvert(expression);
    }
}

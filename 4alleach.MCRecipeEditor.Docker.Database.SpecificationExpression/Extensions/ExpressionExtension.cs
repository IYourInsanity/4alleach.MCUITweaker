using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database.SpecificationExpression.Extensions;

internal static class ExpressionExtension
{
    internal static Expression<Func<TSpecific, bool>> Or<TSpecific> (this Expression<Func<TSpecific, bool>> left, Expression<Func<TSpecific, bool>> right) 
        where TSpecific : class
    {
        return left.Compose(right, Expression.OrElse);
    }

    internal static Expression<Func<TSpecific, bool>> And<TSpecific> (this Expression<Func<TSpecific, bool>> left, Expression<Func<TSpecific, bool>> right) 
        where TSpecific : class
    {
        return left.Compose(right, Expression.AndAlso);
    }

    private static Expression<Func<TSpecific, bool>> Compose<TSpecific> (this Expression<Func<TSpecific, bool>> left, Expression<Func<TSpecific, bool>> right, 
                                                                              Func<Expression, Expression, Expression> op)
        where TSpecific : class
    {
        return SpecificationCache.GetOrAdd((Specification<TSpecific>)left, right, () =>
        {
            var newParam = Expression.Parameter(typeof(TSpecific));
            var replacedLeft = left.Replace<Func<TSpecific, bool>, Func<TSpecific, bool>>(left.Parameters.Single(), newParam);
            var replacedRight = right.Replace<Func<TSpecific, bool>, Func<TSpecific, bool>>(right.Parameters.Single(), newParam);

            var body = op(replacedLeft.Body, replacedRight.Body);

            return Expression.Lambda<Func<TSpecific, bool>>(body, newParam);
        });
    }

    public static Expression<TOutput> Replace<TInput, TOutput>(this Expression<TInput> expression, ParameterExpression source, Expression target)
    {
        return new ParameterReplacerVisitor<TOutput>(source, target).VisitAndConvert(expression);
    }
}

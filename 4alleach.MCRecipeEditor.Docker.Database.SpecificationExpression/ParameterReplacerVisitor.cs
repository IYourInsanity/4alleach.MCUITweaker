using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database.SpecificationExpression;

public sealed class ParameterReplacerVisitor<TOutput> : ExpressionVisitor
{
    private readonly ParameterExpression source;
    private readonly Expression target;

    public ParameterReplacerVisitor(ParameterExpression source, Expression target)
    {
        this.source = source;
        this.target = target;
    }

    internal Expression<TOutput> VisitAndConvert<T>(Expression<T> root)
    {
        return (Expression<TOutput>)VisitLambda(root);
    }

    protected override Expression VisitLambda<T>(Expression<T> node)
    {
        var parameters = node.Parameters
                             .Select(p => p == source ? target : p)
                             .Cast<ParameterExpression>();

        return Expression.Lambda<TOutput>(Visit(node.Body), parameters);
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return node == source ? target : base.VisitParameter(node);
    }
}

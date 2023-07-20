using _4alleach.MCRecipeEditor.Docker.Database.SpecificationExpression.Extensions;
using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database.SpecificationExpression;

public interface ISpecification
{
}

public sealed class Specification<TSpecific> : ISpecification
    where TSpecific : class
{
    private readonly Expression<Func<TSpecific, bool>> expression;

    internal IReadOnlyCollection<ParameterExpression> Parameters => expression.Parameters;

    private Specification(Expression<Func<TSpecific, bool>> expression)
    {
        this.expression = expression;
    }

    private Specification(Specification<TSpecific> expression)
    {
        this.expression = expression;
    }

    #region Operators

    public static Specification<TSpecific> operator | (Specification<TSpecific> left, Specification<TSpecific> right) => new(left.Or(right));

    public static Specification<TSpecific> operator & (Specification<TSpecific> left, Specification<TSpecific> right) => new(left.And(right));

    //#region This is necessary so that the chain is guaranteed to be executed

    //public static bool operator false(Specification<TSpecific> left) => false;

    //public static bool operator true(Specification<TSpecific> left) => false;

    //#endregion

    public static implicit operator Expression<Func<TSpecific, bool>>(Specification<TSpecific> spec)
    {
        return spec.expression;
    }

    public static implicit operator Specification<TSpecific>(Expression<Func<TSpecific, bool>> expression)
    {
        return new Specification<TSpecific>(expression);
    }

    #endregion

    public override int GetHashCode()
    {
        return expression.Body.GetHashCode();
    }
}

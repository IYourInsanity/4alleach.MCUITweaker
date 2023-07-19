using _4alleach.MCRecipeEditor.Docker.Database.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.SpecificationExpression;
using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database;

internal struct Specifications
{
    internal struct Items
    {
        public static Specification<Item> DescriptionIsNull => DescriptionIsNullExpression;
        private static Expression<Func<Item, bool>> DescriptionIsNullExpression = _ => _.Description == null;

        public static Specification<Item> NameIsNotNull => NameIsNotNullExpression;
        private static Expression<Func<Item, bool>> NameIsNotNullExpression = _ => _.Name != null;
    }
}

using System.Collections.Concurrent;

namespace _4alleach.MCRecipeEditor.Docker.Database.SpecificationExpression;
public static class SpecificationCache
{
    private static readonly ConcurrentDictionary<int, ISpecification> storage;

    static SpecificationCache()
    {
        storage = new ConcurrentDictionary<int, ISpecification>();
    }

    public static Specification<TSpecific> GetOrAdd<TSpecific>(Specification<TSpecific> left, Specification<TSpecific> right, Func<Specification<TSpecific>> generateSpecification)
        where TSpecific : class
    {
        var key = left.GetHashCode() + right.GetHashCode();

        if (storage.TryGetValue(key, out var specification))
        {
            return (Specification<TSpecific>)specification;
        }

        specification = generateSpecification();

        storage.TryAdd(key, specification);

        return (Specification<TSpecific>)specification;
    }
}

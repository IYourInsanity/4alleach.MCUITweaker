using System.Collections.ObjectModel;

namespace _4alleach.MCRecipeEditor.Client.Extensions;

internal static class ObservableCollectionExtension
{
    internal static ObservableCollection<TValue> Update<TValue>(this ObservableCollection<TValue> values, IList<TValue>? collection)
    {
        values.Clear();

        if(collection == null)
        {
            return values;
        }

        foreach (var item in collection)
        {
            values.Add(item);
        }

        return values;
    }    
}

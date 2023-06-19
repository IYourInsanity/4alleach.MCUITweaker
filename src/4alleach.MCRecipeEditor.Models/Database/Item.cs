using _4alleach.MCRecipeEditor.Models.Abstractions.Database;

namespace _4alleach.MCRecipeEditor.Models.Database;
public class Item : Asset
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? ItemTypeId { get; set; }
    public Guid? ModTypeId { get; set; }
    public Guid? ItemPrefixId { get; set; }
    public Guid? ItemPostfixId { get; set; }
}

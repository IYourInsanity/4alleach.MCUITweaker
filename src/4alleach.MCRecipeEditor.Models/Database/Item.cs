using _4alleach.MCRecipeEditor.Models.Database.Base;

namespace _4alleach.MCRecipeEditor.Models.Database;

public class Item : Asset
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public Guid? ItemTypeId { get; set; }
    public ItemType? ItemType { get; set; }

    public Guid? ModTypeId { get; set; }
    public ModType? ModType { get; set; }

    public Guid? ItemPrefixId { get; set; }
    public ItemPrefix? ItemPrefix { get; set; }

    public Guid? ItemPostfixId { get; set; }
    public ItemPostfix? ItemPostfix { get; set; }
}

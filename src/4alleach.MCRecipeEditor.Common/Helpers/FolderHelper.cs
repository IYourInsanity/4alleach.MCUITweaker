namespace _4alleach.MCRecipeEditor.Common.Helpers;

public static class FolderHelper
{
    public static void Create(string path)
    {
        Directory.CreateDirectory(path);
    }

    public static bool IsExist(string path)
    {
        return Directory.Exists(path);
    }

}

namespace _4alleach.MCRecipeEditor.Common.Helpers;

public static class FileHelper
{
    public static string RootPath => AppDomain.CurrentDomain.BaseDirectory;

    public static bool IsExist(string filename)
    {
        var pathToFile = Path.Combine(RootPath, filename);

        return File.Exists(pathToFile);
    }

    public static void Create(string path)
    {
        File.Create(path);
    }
}

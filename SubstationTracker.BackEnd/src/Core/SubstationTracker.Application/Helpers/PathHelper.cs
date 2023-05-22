using SubstationTracker.Application.Constants;

namespace SubstationTracker.Application.Helpers;

public static class PathHelper
{
    public static string? GetPath(string? fileName)
    {
        if (string.IsNullOrEmpty(fileName))
            return null;

        return string.Join("/", FolderConsts.FolderName, fileName);
    }
}
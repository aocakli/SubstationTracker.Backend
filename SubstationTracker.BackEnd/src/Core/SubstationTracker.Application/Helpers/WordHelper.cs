using System.Text.RegularExpressions;

namespace SubstationTracker.Application.Helpers;

public static class WordHelper
{
    public static string CamelCaseToWhiteSpaceSplit(string text)
    {
        return Regex.Replace(text, "([A-Z])", " $1").Trim();
    }
}
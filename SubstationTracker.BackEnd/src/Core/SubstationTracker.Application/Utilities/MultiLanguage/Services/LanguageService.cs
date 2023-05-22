using Microsoft.Extensions.Localization;
using SubstationTracker.Application.Resources.Languages;

namespace SubstationTracker.Application.Utilities.MultiLanguage.Services;

public class LanguageService
{
    private readonly IStringLocalizer<Lang> _localizer;

    public LanguageService(IStringLocalizer<Lang> localizer)
    {
        _localizer = localizer;
    }

    public string Get(params string[] keys)
    {
        List<string> values = new();

        foreach (var key in keys)
            values.Add(_localizer[key].Value);

        return string.Join(" ", values);
    }
}
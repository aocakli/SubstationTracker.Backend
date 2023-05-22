namespace SubstationTracker.Application.Repositories._Bases;

public struct RepoFeatures
{
    public RepoFeatures()
    {
    }

    public RepoFeatures(bool includeAudit = false, bool ignoreQueryFilters = false, bool noTracking = true)
    {
        IncludeAudit = includeAudit;
        IgnoreQueryFilters = ignoreQueryFilters;
        NoTracking = noTracking;
    }

    public bool IncludeAudit { get; set; } = false;
    public bool IgnoreQueryFilters { get; set; } = false;
    public bool NoTracking { get; set; } = true;
}
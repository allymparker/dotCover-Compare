namespace dotCoverCompare.Domain
{
    public enum CoverageChange
    {
        Increased,
        Unchanged,
        Decreased
    }
    public enum CodeChange
    {
        StatementsIncreased,
        StatementsDecreased,
        Added,
        Removed

    }
}
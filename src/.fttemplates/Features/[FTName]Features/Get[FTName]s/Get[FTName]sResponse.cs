namespace ASPReactCQRS.Application.Features.[FTName]Features.Get[FTName]s
{
    public sealed record Get[FTName]sResponse
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long TotalRows { get; set; }
        public IEnumerable<[FTName]Features.Get[FTName].Get[FTName]Response> [FTName]s { get; set; } = Enumerable.Empty<Get[FTName].Get[FTName]Response>();
    }
}

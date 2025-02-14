namespace Dima.Core.Requests;

public abstract class PagedRequests : Request
{
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}
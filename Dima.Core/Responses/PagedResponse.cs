﻿using System.Text.Json.Serialization;

namespace Dima.Core.Responses;

public class PagedResponse <TData> : Response<TData>
{
    [JsonConstructor]
    public PagedResponse(
        TData? data, int totalCount, int currentPage, int pageSize = Configuration.DefaultPageSize
        )
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize ;
    }

    public PagedResponse(TData? data, int code = Configuration.DefaultStatusCode, string? message = null): base(data, code, message)
    {
        
    }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}
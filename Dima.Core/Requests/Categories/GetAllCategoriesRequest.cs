﻿namespace Dima.Core.Requests.Categories;

public class GetAllCategoriesRequest : PagedRequests
{
    public string userId { get; set; }
    public int Page { get; set; }
}
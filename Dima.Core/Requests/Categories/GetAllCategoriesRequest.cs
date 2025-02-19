namespace Dima.Core.Requests.Categories;

public class GetAllCategoriesRequest : PagedRequest
{
    public string userId { get; set; }
    public int Page { get; set; }
}
namespace Dima.Core.Requests.Categories;

public class GetCategoryByIdRequest : Request
{
    public long Id { get; set; }
    public string userId { get; set; }
}
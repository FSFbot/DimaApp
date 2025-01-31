using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Core.Handlers;

public interface ICategoryHandler
{
    Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
    Task<Response<Category?>> UpdateAsync(UpdataCategoryRequest request);
    Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request);
    Task<Response<Category?>> GetByIdAsync(GetCategoryByRequest request);
    Task<Response<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
    
}
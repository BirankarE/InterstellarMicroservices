using Interstellar.FreeCourse.Services.Catalog.Dtos;
using Interstellar.FreeCourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interstellar.FreeCourse.Services.Catalog.Services
{
    interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }

}

using Interstellar.FreeCourse.Services.Catalog.Dtos;
using Interstellar.FreeCourse.Services.Catalog.Services;
using Interstellar.FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interstellar.FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")] // Bu attr sayasinde daha temiz bir url olacak örn: courses/4 gibi; olmasaydı courses?id=4 olacaktı.
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);

            return CreateActionResultInstance(response);//StatusCode kontrol yapmamak için CustomBaseController oluştruldu ve geriye statusCode donmesi sağlandı.
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]//GetById methodu ile aynı parametreleri aldığı için custom bir root verdik.
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _courseService.GetAllByUserIdAsync(userId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
        {
            var response = await _courseService.CreateAsync(courseCreateDto);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            var response = await _courseService.UpdateAsync(courseUpdateDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}

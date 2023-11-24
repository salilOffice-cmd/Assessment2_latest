using Application.CoursesCQRS.Commands;
using Application.CoursesCQRS.Queries;
using Application.DTOs.CourseDTOs;
using Application.StudentsCQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CourseController : APIControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddCourseAsync([FromBody] AddCourseDTO _addCourseDTO)
        {
            var addCourseCommand = new AddCourseCommand { addCourseDTO = _addCourseDTO};
            var gotAddedCourse = await Mediator.Send(addCourseCommand);
            return Ok(gotAddedCourse);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult> GetAllCoursesAsync()
        {
            var gotAllCourses = await Mediator.Send(new GetAllCoursesQuery { });
            return Ok(gotAllCourses);
        }

    }
}

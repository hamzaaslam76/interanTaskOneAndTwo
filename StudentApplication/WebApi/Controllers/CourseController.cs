using IRepository.IRepository;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CourseController : ApiController
    {
        private ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courserepo)
        {
            _courseRepository = courserepo;
        }
        [HttpGet]

        public IHttpActionResult GetAllCourse()
        {
             var Item= _courseRepository.GetModel();
            if (Item != null)
            {
                return Ok(Item);
            }
            return BadRequest("Table Is Empty");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Homework_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("api/users")]
        public ActionResult<List<string>> GetAllUsers()
        {
            return Ok(StaticDb.UserNames);
        }

        [HttpGet]
        [Route("api/users/{index}")]
        public ActionResult<string> GetUser(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The index must not have negative value");
                }

                if (index >= StaticDb.UserNames.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no resourse on index {index}");
                }

                return Ok(StaticDb.UserNames[index]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the administrator");
            }
        }
    }
}

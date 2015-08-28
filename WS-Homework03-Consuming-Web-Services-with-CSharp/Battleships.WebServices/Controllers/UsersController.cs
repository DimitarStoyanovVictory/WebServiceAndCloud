namespace Battleships.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;

    public class UsersController : BaseApiController
    {
        public UsersController(IBattleshipsData data) : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetUsersCount()
        {
            var count = Data.Users.All().Count();
            return Ok(count);
        }
    }
}
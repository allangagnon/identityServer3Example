using System.Collections.Generic;
using System.Web.Http;

namespace ExampleAPI.Controllers
{
    [Authorize]
    public class PeopleController : ApiController
    {
        public List<string> Get()
        {
            return new List<string>
            {
                "Holly", "Scott", "Calvin", "Nana", "Nora"
            };
        }
    }
}

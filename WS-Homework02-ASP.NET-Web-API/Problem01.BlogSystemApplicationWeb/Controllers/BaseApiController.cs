using System.Web.Http;
using BlogSystem.Data;

namespace Problem01.BlogSystemApplication.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private IBlogSystemData _data;

        protected BaseApiController()
            : this(new BlogSystemData(new BlogSystemDbContext()))
        {
        }

        protected BaseApiController(IBlogSystemData data)
        {
            _data = data;
        }

        public IBlogSystemData Data
        {
            get
            {
                return _data;
            }

            private set
            {
                _data = value;
            }
        }
    }
}
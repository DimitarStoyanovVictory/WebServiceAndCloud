using System;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using BlogSystem.Models;
using Problem01.BlogSystemApplication.Controllers;
using Problem01.BlogSystemApplicationWeb.Models;
using Newtonsoft.Json;

namespace Problem01.BlogSystemApplicationWeb.Controllers
{
    public class UserController : BaseApiController
    {
        // POST api/user/register
        [HttpPost]
        [ActionName("regiset")]
        public IHttpActionResult CreauteUser(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Username = model.Username,
                ContactInfo = new UserContactInfo()
            };

            Data.Users.Add(user);
            Data.SaveChanges();

            return Ok(user.Id);
        }

        [HttpGet]
        [ActionName("getallUsers")]
        public IHttpActionResult ReadAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = Data.Users.All().ToList();

            if (users.Count == 0)
            {
                return NotFound();
            }

            string jsonUsers = JsonConvert.SerializeObject(users);

            return Ok(jsonUsers);
        }

        [HttpPut]
        [ActionName("updateUser")]
        public IHttpActionResult UpdateUser(UpdateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Data.Users.GetById(model.Id);

            if (model.Username != null)
            {
                user.Username = model.Username;
            }

            if (model.FullName != null)
            {
                user.FullName = model.FullName;
            }

            if (model.RegistrationDate != null)
            {
                user.RegistrationDate = DateTime.ParseExact(model.RegistrationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);
            }

            if (model.Birthday != null)
            {
                user.Birthday = DateTime.ParseExact(model.Birthday, "dd/MM/yyy", CultureInfo.InvariantCulture);
            }

            if (model.Gender != null)
            {
                user.Gender = ConvertTo.GenderType(model.Gender);
            }

            if (model.Facebook != null)
            {
                if (user.ContactInfo != null)
                {
                    user.ContactInfo.Facebook = model.Facebook;
                }
                else
                {
                    user.ContactInfo = new UserContactInfo { Facebook = model.Facebook };
                }
            }

            if (model.Facebook != null)
            {
                if (user.ContactInfo != null)
                {
                    user.ContactInfo.Skype = model.Skype;
                }
                else
                {
                    user.ContactInfo = new UserContactInfo { Facebook = model.Skype };
                }
            }

            if (model.Facebook != null)
            {
                if (user.ContactInfo != null)
                {
                    user.ContactInfo.Tweeter = model.Tweeter;
                }
                else
                {
                    user.ContactInfo = new UserContactInfo { Facebook = model.Tweeter };
                }
            }

            if (model.Facebook != null)
            {
                if (user.ContactInfo != null)
                {
                    user.ContactInfo.PhoneNumber = model.PhoneNumber;
                }
                else
                {
                    user.ContactInfo = new UserContactInfo { Facebook = model.PhoneNumber };
                }
            }

            Data.SaveChanges();

            return Ok("User updated");
        }
    }
}

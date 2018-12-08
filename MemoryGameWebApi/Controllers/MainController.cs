using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json;

namespace MemoryGameWebApi.Controllers
{
    [RoutePrefix("api")]
    public class MainController : ApiController
    {
        private MemoryGameEntities1 db = new MemoryGameEntities1();

        [Route("Login"), HttpPost]
        public IHttpActionResult UserLogin(Users data)
        {
            try
            {
                Users[] user = db.Users.Where(u => u.UserName == data.UserName && u.Password == data.Password).ToArray()
                    .Select(u => new Users { FullName = u.FullName, UserName = u.UserName, UserId = u.UserId }).ToArray();
                if (user.Count() == 0)
                {
                    return Ok("שם המשתמש או הסיסמה שגויים!");
                }
                else
                {
                    return Ok(user[0]);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("SignUp"), HttpPost]
        public IHttpActionResult SignUp(Users data)
        {
            try
            {
                if (db.Users.Where(u => u.UserName == data.UserName).Count() > 0)
                {
                    return Ok("שם המשתמש שבחרת תפוס. נסה שם משתמש אחר.");
                }
                db.Users.Add(data);
                db.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("SaveGameResult"), HttpPost]
        public IHttpActionResult SaveGameResult(GameResult data)
        {
            try
            {
                data.GameDateTime = DateTime.Now;
                db.GameResult.Add(data);
                db.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("GetGameResult"), HttpGet]
        public IHttpActionResult GetGameResult()
        {
            try
            {
                GameResult[] gameResult = db.GameResult.Where(_ => true).ToArray();
                return Ok(gameResult);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("GetImages"), HttpGet]
        public IHttpActionResult GetImages()
        {
            try
            {
                Images[] images = db.Images.Where(_ => true).ToArray();
                return Ok(images);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("InsertFeedback"), HttpPost]
        public IHttpActionResult InsertFeedback(Feedback data)
        {
            try
            {
                data.FeedbackDateTime = DateTime.Now;
                db.Feedback.Add(data);
                db.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("GetFeedbacks"), HttpGet]
        public IHttpActionResult GetFeedbacks()
        {
            try
            {
                Feedback[] feedbacks = db.Feedback.Where(_ => true).ToArray();
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("SendMessage"), HttpPost]
        public IHttpActionResult SendMessage(ContactMessage data)
        {
            try
            {
                data.MessageDateTime = DateTime.Now;
                db.ContactMessage.Add(data);
                db.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

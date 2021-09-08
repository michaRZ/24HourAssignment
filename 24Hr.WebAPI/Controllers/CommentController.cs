using _24Hr.Data;
using _24Hr.Models;
using _24Hr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24Hr.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        [Authorize]

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var CommentService = new CommentService(userId);

            return CommentService;
        }

        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentsByAuthor();

            return Ok(comments);

        }

        public IHttpActionResult GetPostComments([FromUri] int postId)
        {
            CommentService commentService = CreateCommentService();

            var comments = commentService.GetCommentsByPost(postId);

            return Ok(comments);
        }

        public IHttpActionResult PostComment([FromUri] int postId, [FromBody]CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var service = CreateCommentService();

            if (!service.CreateComment(comment))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult PutComment(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.EditComment(comment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult DeleteComment(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}

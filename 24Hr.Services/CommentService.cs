using _24Hr.Data;
using _24Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace _24Hr.Services
{
    //does this work-test
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                AuthorId = _userId,
                Contents = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetCommentsByAuthor()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.AuthorId == _userId)
                    .Select
                    (
                        e => new CommentListItem
                        {
                            CommentId = e.CommentId,
                            PostId = e.PostId,
                            Contents = e.Contents,
                            AuthorId = e.AuthorId,
                            CreatedUtc = e.CreatedUtc
                        }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<CommentListItem> GetCommentsByPost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Comments
                    .Where(e => e.PostId == id)
                    .Select
                    (
                    e => new CommentListItem
                    {

                        CommentId = e.CommentId,
                        PostId = e.PostId,
                        Contents = e.Contents,
                        AuthorId = e.AuthorId,
                        CreatedUtc = e.CreatedUtc
                    }
                    );

                return query.ToArray();
            }
        }

        public bool EditComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId && e.AuthorId == _userId);

                entity.Contents = model.Contents;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.AuthorId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

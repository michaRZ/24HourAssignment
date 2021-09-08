using _24Hr.Data;
using _24Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                AuthorId = _userId,
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }





        public IEnumerable<ReplyListItem> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Replies.Where(p => p.AuthorId == _userId).Select(p => new ReplyListItem
                {
                    ReplyId = p.ReplyId,
                    Text = p.Text,
                    CreatedUtc = p.CreatedUtc
                });
                return query.ToArray();
            }
        }

        public IEnumerable<ReplyListItem> GetReplyByComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Replies
                    .Where(p => p.CommentId == id)
                    .Select
                    (
                    p => new ReplyListItem
                    {
                        ReplyId = p.ReplyId,
                        Text = p.Text,
                        CreatedUtc = p.CreatedUtc
                    }
                    );
                return query.ToArray();
            }
        }
        
    }

}

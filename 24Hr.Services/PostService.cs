using _24Hr.Data;
using _24Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AuthorId = _userId,
                Title = model.Title,
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now,
                // add Comments?
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Where(p => p.AuthorId == _userId).Select(p => new PostListItem
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Text = p.Text,
                    CreatedUtc = p.CreatedUtc
                });
                return query.ToArray();
            }
        }
    }
}

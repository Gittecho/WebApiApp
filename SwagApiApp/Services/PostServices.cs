using Microsoft.EntityFrameworkCore;
using SwagApiApp.Data;
using SwagApiApp.Domain;
using static SwagApiApp.Contracts.v1.ApiRoute;

namespace SwagApiApp.Services
{
    public class PostServices : IPostServices
    {
        private readonly ApplicationDbContext _dbcontext;

        public PostServices(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dbcontext.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _dbcontext.Posts.SingleOrDefaultAsync(post => post.Id == postId);    
        }

        public async Task<bool> UpdateToPostAsync(Post postToUpdate)
        {
           
            _dbcontext.Posts.Update(postToUpdate);
            var updated = await _dbcontext.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<bool> DeletePostByIdAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            _dbcontext.Posts.Remove(post);
            var deleted = await _dbcontext.SaveChangesAsync();  

            return deleted > 0;
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _dbcontext.Posts.AddAsync(post); 
            var created = await _dbcontext.SaveChangesAsync();  

            return created > 0;
        }
    }
}

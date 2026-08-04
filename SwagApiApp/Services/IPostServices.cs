using SwagApiApp.Domain;

namespace SwagApiApp.Services
{
    public interface IPostServices
    {
        public  Task<List<Post>> GetPostsAsync();
        public  Task<Post> GetPostByIdAsync(Guid postId);
        public  Task<bool> UpdateToPostAsync(Post post);
        public  Task<bool> DeletePostByIdAsync(Guid postId);
        public  Task<bool> CreatePostAsync(Post post);
    }
}

using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts {get;} //veritabanında filtreli olarak getirir. Hepsini getirmez.

        void CreatePost(Post post);
    }
}
using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags {get;} //veritabanında filtreli olarak getirir. Hepsini getirmez.

        void CreateTag(Tag tag);
    }
}
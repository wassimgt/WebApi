using WebApi.entites;

namespace WebApi.service
{
    public interface IRepository
    {
      
        Task< List<genre>> GetGenres();
        genre Getbyid(int id);
        void addgenre(genre genres);
    }
}

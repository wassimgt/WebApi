using WebApi.entites;

namespace WebApi.service
{
    public class memorieRpository : IRepository
    {
        private List<genre> _genres;
        private readonly ILogger<genre> _logger;
        public memorieRpository(ILogger<genre> logger)
        {
            _genres = new List<genre>()
            {
                new genre(){ Id = 1, Name = "wassim"},
                new genre(){ Id = 2, Name="ali"}
            };
            _logger = logger;
        }

        public async Task< List<genre> > GetGenres()
        {
            _logger.LogInformation("executing get all genre");
            await Task.Delay(3000);
             return _genres;
        }   
        public genre Getbyid(int id)
        {
            var rep= _genres.FirstOrDefault(x => x.Id == id);
            return rep; 
        }
        public void addgenre( genre genres)
        {
            genres.Id= _genres.Max(x => x.Id)+1;  

        _genres.Add(genres);    
        }
    }
}

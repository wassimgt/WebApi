using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebApi.DTO;
using WebApi.entites;
using WebApi.service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
  
    public class genresController : ControllerBase
    {
       
        private readonly ILogger<genre> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public genresController(ILogger<genre> logger  , ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            this.mapper = mapper;
        }
      

        [HttpGet]
        public async Task< ActionResult<List<genreDTO>>> Get()
        {
            _logger.LogInformation("getting all the genres");
          var genres =await context.genres.OrderBy(x=>x.Name).ToListAsync();
           

            return mapper.Map<List<genreDTO>>(genres);


        }
        [HttpGet("{id:int}", Name ="getgenre")]
       
        public async Task< ActionResult <genreDTO>> Get(int id)
        {
           var genre= await context.genres.FirstOrDefaultAsync(x=>x.Id==id);
            if (genre == null)
            {
                return NotFound();
            }
           return mapper.Map<genreDTO>(genre);    

        }
        [HttpPost] 
        public async Task< ActionResult> Post([FromBody] genrecreateDTO genrescreate)
        {
            
           var genres= mapper.Map<genre>(genrescreate);   
            context.Add(genres);  
            await context.SaveChangesAsync();
            return NoContent();
           

        }
        [HttpPut("{id:int}")]   
        public async Task< ActionResult> Put(int id,[FromBody] genrecreateDTO genrecreationdto)
        {
            var genre = mapper.Map<genre>(genrecreationdto);
            genre.Id = id;
            context.Entry(genre).State= EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task< ActionResult> Delete(int id)
        {
            var genre = await context.genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genre == null)
            {
                return NotFound();
            }
            context.Remove(genre);
            await context.SaveChangesAsync();
            return NoContent();

        }
    }
}

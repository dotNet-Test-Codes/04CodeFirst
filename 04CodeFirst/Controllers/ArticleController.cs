using _04CodeFirst.Data;
using _04CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _04CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly CodeFirstDBContext _context;
        public ArticleController(CodeFirstDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetHeroes()
        {
            return Ok(await _context.Articles.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddHeroes(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return Ok(article);
        }
    }
}

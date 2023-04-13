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
        public async Task<ActionResult<List<Article>>> GetArticles()
        {
            return Ok(await _context.Articles.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Article>> GetArticleById(int id)
        {
            var article = GetArticle(id);

            if (id == null)
            {
                return NotFound("Id cannot find");
            }

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticles(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return Ok(article);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateArticles(Article article)
        {
            var art = this.GetArticle(article.ID);
            if(art != null)
            {
                art.ID = article.ID;
                art.Name = article.Name;
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return Ok(art);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteArticles(int id)
        {
            var art = await _context.Articles.Where(a => a.ID == id).FirstOrDefaultAsync();
            if (art != null)
            {
                _context.Articles.Remove(art);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return Ok(art);
        }

        private Article GetArticle(int id)
        {
            var article = _context.Articles.Where(a => a.ID == id).FirstOrDefault();

            return article;
        }
    }
}

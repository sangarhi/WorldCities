using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCities.Data;
using WorldCities.Data.Models;
namespace WorldCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetBlogPost()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetBlogPost(int id)
        {
            var blogPost = await _context.Usuarios.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var aux = _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
            aux.Email = user.Email;
            _context.SaveChanges();
           
            return NoContent();
          
        }

        // POST: api/BlogPosts
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostBlogPost(Usuario blogPost)
        {
            _context.Usuarios.Add(blogPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPost", new { id = blogPost.Id }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteBlogPost(int id)
        {
            var blogPost = await _context.Usuarios.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(blogPost);
            await _context.SaveChangesAsync();

            return blogPost;
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}


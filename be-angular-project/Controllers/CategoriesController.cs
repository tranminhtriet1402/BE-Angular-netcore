using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using be_angular_project.Models;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace be_angular_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DB_ShoeStoreContext _context;


        public CategoriesController(DB_ShoeStoreContext context)
        {
            _context = context;
           
        }
  


        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
    


            CategoryDTO mess = new CategoryDTO()
                {

                    success = true,
                    message = "Thao tác thành công",
                    cate = _context.Categories.OrderByDescending(x=>x.IdCategory).ToList(),
                    total = _context.Categories.ToList().Count()
                };
   
       
          

            return Ok(mess);

            //return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);   

            if (category == null)
            {
                Message mess = new Message() { success = false, message = "Không tìm thấy loại giày" };
                return NotFound(mess);
            }
            else{
                CategoryDTO mess = new CategoryDTO()
                {

                    success = true,
                    cate = _context.Categories.Where(c=>c.IdCategory==id).ToList(),
                    total = _context.Categories.Where(c => c.IdCategory == id).ToList().Count()
                };
                return Ok(mess);
            }

            
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.IdCategory)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Message mess = new Message() { success = true, message = "Thao tác thành công" };
            return Ok(mess);
        }



        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            Message mess = new Message() { success = true, message = "Thao tác thành công" };

            return CreatedAtAction("GetCategory", new { id = category.IdCategory }, mess    );
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            try
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                Message mess = new Message();
                if (!CategoryExists(id))
                {
                     mess = new Message() { success = true, message = "Thao tác thành công" };
                   
                }
                return Ok(mess);

            }
            catch{
                Message mess = new Message() { success = false, message = "Dữ liệu này có tồn tại dữ liệu phụ thuộc" };
                return Ok(mess);
            }
                
          

          


        }


       

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.IdCategory == id);
        }
    }
}

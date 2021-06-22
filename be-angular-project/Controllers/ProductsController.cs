using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using be_angular_project.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace be_angular_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DB_ShoeStoreContext _context;
        private readonly IHostingEnvironment _webHostEnvironment;
        public ProductsController(DB_ShoeStoreContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }
        

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
           
                ProductDTO mess = new ProductDTO()
                {

                    success = true,
                    product = _context.Products.OrderByDescending(x=>x.IdProduct).ToList(),
                    total = _context.Products.ToList().Count()
                };
   
            

            return Ok(mess);
        }
        [HttpGet("/api/getProductOnCate/{id}")]
        public async Task<ActionResult<Product>> getProductOnCate(int id)
        {
         
     
       
                ProductDTO mess = new ProductDTO()
                {

                    success = true,
                    product = _context.Products.Where(c => c.IdCategory == id).ToList(),
                    total = _context.Products.Where(c => c.IdCategory == id).ToList().Count()
                };
                return Ok(mess);
          
        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                Message mess = new Message() { success = false, message = "Không tìm thấy loại giày" };
                return NotFound(mess);
            }
            else
            {
                ProductDTO mess = new ProductDTO()
                {

                    success = true,
                    product = _context.Products.Where(c => c.IdProduct == id).ToList(),
                    total = _context.Products.Where(c => c.IdProduct == id).ToList().Count()
                };
                return Ok(mess);
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.IdProduct)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.IdProduct }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                Message mess = new Message();
                if (!ProductExists(id))
                {
                    mess = new Message() { success = true, message = "Thao tác thành công" };

                }
                return Ok(mess);

            }
            catch
            {
                Message mess = new Message() { success = false, message = "Dữ liệu này có tồn tại dữ liệu phụ thuộc" };
                return Ok(mess);
            }

   

        }

        [HttpPut("{id}/Upload")]
        public async Task<ActionResult> Upload(int id, IFormFile file)
        {
            var pro = new Product() { IdProduct = id };

            try
            {
                if (file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        pro.Images = "/upload/" + file.FileName;
                        _context.Entry(pro).Property("Images").IsModified = true;
                        _context.SaveChanges();
                        Message mess = new Message() { success = true, message = "Upload hình ảnh thành công" };

                        return Ok(mess);
                    }
                }
                else
                {
                    Message mess = new Message() { success = false, message = "Không thể upload hình ảnh" };

                    return Ok(mess);
                }
            }
            catch (Exception e)
            {
                Message mess = new Message() { success = false, message = "Không thể upload hình ảnh" };

                return Ok(mess);
            }

        }
        [HttpPut("{id}/Upload1")]
        public async Task<ActionResult> Upload1(int id, IFormFile file)
        {
            var pro = new Product() { IdProduct = id };

            try
            {
                if (file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        pro.Images1 = "/upload/" + file.FileName;
                        _context.Entry(pro).Property("Images1").IsModified = true;
                        _context.SaveChanges();
                        Message mess = new Message() { success = true, message = "Upload hình ảnh thành công" };

                        return Ok(mess);
                    }
                }
                else
                {
                    Message mess = new Message() { success = false, message = "Không thể upload hình ảnh" };

                    return Ok(mess);
                }
            }
            catch (Exception e)
            {
                Message mess = new Message() { success = false, message = "Không thể upload hình ảnh" };

                return Ok(mess);
            }

        }
        [HttpPut("{id}/Upload2")]
        public async Task<ActionResult> Upload2(int id, IFormFile file)
        {
            var pro = new Product() { IdProduct = id };

            try
            {
                if (file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        pro.Images2 = "/upload/" + file.FileName;
                        _context.Entry(pro).Property("Images2").IsModified = true;
                        _context.SaveChanges();
                        Message mess = new Message() { success = true, message = "Upload hình ảnh thành công" };

                        return Ok(mess);
                    }
                }
                else
                {
                    Message mess = new Message() { success = false, message = "Không thể upload hình ảnh" };

                    return Ok(mess);
                }
            }
            catch (Exception e)
            {
                Message mess = new Message() { success = false, message = "Không thể upload hình ảnh" };

                return Ok(mess);
            }

        }
        [HttpPut("{id}/Upload3")]
        public async Task<ActionResult> Upload3(int id, IFormFile file)
        {
            var pro = new Product() { IdProduct = id };

            try
            {
                if (file.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + file.FileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        pro.Images3 = "/upload/" + file.FileName;
                        _context.Entry(pro).Property("Images3").IsModified = true;
                        _context.SaveChanges();
                        Message mess = new Message() { success = true, message = "Upload hình ảnh thành công" };

                        return Ok(mess);
                    }
                }
                else
                {
                    Message mess = new Message() { success = false, message = "Không thể upload hình ảnh" };

                    return Ok(mess);
                }
            }
            catch (Exception e)
            {
                Message mess = new Message() { success = false, message = "Không thể upload hình ảnh" };

                return Ok(mess);
            }

        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.IdProduct == id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProductDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly MasterContext _masterContext;

        public ProductsController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IEnumerable<Product>> GetProducts ()
        {
            return await _masterContext.Products.ToListAsync();
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<Product> AddProduct(Product objProduct)
        {
            _masterContext.Products.Add(objProduct);
            await _masterContext.SaveChangesAsync();
            return objProduct;
        }
        [HttpPatch]
        [Route("UpdateProduct/{id}")]
        public async Task<Product> UpdateProduct(Product objProduct)
        {
            _masterContext.Entry(objProduct).State = EntityState.Modified;
            await _masterContext.SaveChangesAsync();
            return objProduct;
        }
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public bool DeleteProduct(int id)
        {

            bool a = false;
            var product = _masterContext.Products.Find(id);

           if(product != null)
            {
                a = true;
                _masterContext.Entry(product).State = EntityState.Deleted;
                _masterContext.SaveChangesAsync();
            } 
                  
            return a;
        }
    }
}

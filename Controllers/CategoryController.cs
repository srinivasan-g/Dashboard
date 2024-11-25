using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProductDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MasterContext _masterContext;
        public CategoryController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }
        [HttpGet]
        [Route("GetCategory")]
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _masterContext.Categories.ToListAsync();
        }
        [HttpPost]
        [Route("AddCategory")]
        public async Task<Category> AddCategory(Category objCategory)
        {
            _masterContext.Categories.Add(objCategory);
            await _masterContext.SaveChangesAsync();
            return objCategory;
        }
        [HttpPatch]
        [Route("UpdateCategory/{id}")]
        public async Task<Category> UpdateCategory(Category objCategory)
        {
            _masterContext.Entry(objCategory).State = EntityState.Modified;
            await _masterContext.SaveChangesAsync();
            return objCategory;
        }
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public bool DeleteCategory(int id)
        {

            bool a = false;
            var product = _masterContext.Categories.Find(id);

            if (product != null)
            {
                a = true;
                _masterContext.Entry(product).State = EntityState.Deleted;
                _masterContext.SaveChangesAsync();
            }

            return a;
        }
    }
}

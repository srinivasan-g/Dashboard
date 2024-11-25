using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProductDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MasterContext _masterContext;
        public CustomerController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }
        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
          
                var employeesList = await _masterContext.Customers.ToListAsync();

                return employeesList;
           
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<Customer> AddCustomer(Customer objCustomer)
        {
            _masterContext.Customers.Add(objCustomer);
            await _masterContext.SaveChangesAsync();
            return objCustomer;
        }
        [HttpPatch]
        [Route("UpdateCustomer/{id}")]
        public async Task<Customer> UpdateCustomer(Customer objCustomer)
        {
            _masterContext.Entry(objCustomer).State = EntityState.Modified;
            await _masterContext.SaveChangesAsync();
            return objCustomer;
        }
        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public bool DeleteCustomer(int id)
        {

            bool a = false;
            var product = _masterContext.Customers.Find(id);

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

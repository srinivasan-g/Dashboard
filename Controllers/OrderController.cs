using System;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static ProductDashboard.Controllers.OrderController;

namespace ProductDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MasterContext _masterContext;
        public OrderController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }
        public interface IResult<TSuccess, TError> { }
        [HttpGet]
        [Route("GetOrder")]
        public async Task<IEnumerable<Order>> GetOrder(int year)
        {
            var minYear =  year;
            //if (id == 0)
            //{
            //    var yearList = _masterContext.Orders.Select(p => p.OrderDate.Value.Year).Distinct();
            //   minYear = yearList.Min();  
            //} 

            return await _masterContext.Orders.Where(p => p.OrderDate.Value.Year == minYear).ToListAsync();
            
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<Order> AddOrder(Order objOrder)
        {
            _masterContext.Orders.Add(objOrder);
            await _masterContext.SaveChangesAsync();
            return objOrder;
        }
        [HttpPatch]
        [Route("UpdateOrder/{id}")]
        public async Task<Order> UpdateOrder(Order objOrder)
        {
            _masterContext.Entry(objOrder).State = EntityState.Modified;
            await _masterContext.SaveChangesAsync();
            return objOrder;
        }
        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public bool DeleteOrder(int id)
        {

            bool a = false;
            var product = _masterContext.Orders.Find(id);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LJCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILakeJacksonBL repo;
        public OrdersController(ILakeJacksonBL oInfo)
        {
            repo = oInfo;
        }

        // GET: api/Orders/5
        [HttpGet("GetStoreHistory")]
        public IActionResult GetStoreHistory([FromQuery] int storeid,int eID,string pass)
        {
            if(repo.IsAdmin(eID,pass))
            {
                return Ok(repo.GetStoreHistory(storeid));
            }
            else
            {
                return NotFound("please enter a store id ex:1");
            }
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult PlaceOrder([FromQuery] int customerID, int storeID, List<ItemLines> _cart, double totalPrice,int eID,string pass)
        {
            if(repo.IsAdmin(eID,pass))
            {
                return Ok(repo.PlaceOrder(customerID,storeID, _cart, totalPrice));
            }
            else
            {
                return NotFound("Please Try again");
            }
        }
       
    }
}

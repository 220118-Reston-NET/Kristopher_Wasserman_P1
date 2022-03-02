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

       /// <summary>
       /// This will get the order history for a single store. But Manager permission will be needed
       /// </summary>
       /// <param name="storeid"></param>
       /// <param name="eID"></param>
       /// <param name="pass"></param>
       /// <returns></returns>
        [HttpGet("GetStoreHistory")]
        public IActionResult GetStoreHistory([FromQuery] int storeid,int eID,string pass)
        {
            if(repo.IsAdmin(eID,pass))
            {
                Log.Information("The Manager has accessed order history for the store");
                return Ok(repo.GetStoreHistory(storeid));
            }
            else
            {
                Log.Error("The manager did not make a vaild selection");
                return NotFound("please enter a store id ex:1");
            }
        }

        /// <summary>
        /// This will place an order with the customerid,storeid are needed. Manger permissions are also needed
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="storeID"></param>
        /// <param name="_cart"></param>
        /// <param name="totalPrice"></param>
        /// <param name="eID"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PlaceOrder([FromQuery] int customerID, int storeID, List<ItemLines> _cart, double totalPrice,int eID,string pass)
        {
            if(repo.IsAdmin(eID,pass))
            {
                Log.Information("A manager place a new order for a customer");
                return Ok(repo.PlaceOrder(customerID,storeID, _cart, totalPrice));
            }
            else
            {
                Log.Error("Manager has made an error");
                return NotFound("Please Try again");
            }
        }
       
    }
}

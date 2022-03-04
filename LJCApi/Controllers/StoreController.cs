using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LakeJacksonCyclingBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LJCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class StoreController : ControllerBase
    { 
        private readonly ILakeJacksonBL _repo;
        public StoreController(ILakeJacksonBL p_cInfoBL)
        {
            _repo = p_cInfoBL;
        } 
       
        // GET: api/Stroe/5

        /// <summary>
        /// This will get all Stores within the company and display them with the addresses and phone numbers
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllStores")]
        public IActionResult GetAllStoreFronts()
        {
            try
            {
                Log.Information("Customer looked up all stores within company");
                return Ok(_repo.GetAllStoreFront());
            }
            catch (System.Exception)
            {
                Log.Error("the customer made an error");
                throw new Exception("Could not find.Please try again");
            }
        }

        /// <summary>
        /// get store information for a curtian store.
        /// </summary>
        /// <param name="storeid"></param>
        /// <returns></returns>
        [HttpGet("GetAllStoresByID")]
        public IActionResult GetAllStoresByID([FromQuery] int storeid)
        {
            try
            {
                Log.Information("Customer looked up a store information");
                return Ok(_repo.GetAllInventoryByStoreId(storeid));
            }
            catch (System.Exception)
            {
                Log.Error("The customer made an error");
                throw new Exception("Please try again");
            }
        }
    }
}

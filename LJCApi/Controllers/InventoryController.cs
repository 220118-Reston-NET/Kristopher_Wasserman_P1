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
    public class InventoryController : ControllerBase
    {
        private readonly ILakeJacksonBL _repo;
        public InventoryController(ILakeJacksonBL p_cInfoBL)
        {
            _repo = p_cInfoBL;
        } 
        // GET: api/Inventory
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// This will let a user get all the inventory with in the company. No special permission needed
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllInventory")]
        public IActionResult GetAllInventory()
        {
            Log.Information("User has looked up the Inventory of the company");
            try
            {
                return Ok(_repo.GetAllInventory());
            }
            catch (Exception ex)
            {
                Log.Error("The user made an error");
                return StatusCode(422,ex.Message);
            }
        }

    /// <summary>
    /// This will get the inventory of a single store.
    /// </summary>
    /// <param name="storeid"></param>
    /// <returns></returns>
        [HttpGet("GetInventoryByStoreID")]
        public IActionResult GetInventoryByStoreID([FromQuery] int storeid)
        {
            Log.Information("user looked up the inventory for a store");
            try
            {
                return Ok(_repo.GetAllInventoryByStoreId(storeid));
            }
            catch (Exception ex)
            {
                Log.Error("the user did not select a store");
                return StatusCode(422, ex.Message);
            }
        }
    }
}

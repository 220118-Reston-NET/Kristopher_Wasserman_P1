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
        [HttpGet("GetAllStores")]
        public IActionResult GetAllStoreFronts()
        {
            try
            {
                return Ok(_repo.GetAllStoreFront());
            }
            catch (System.Exception)
            {
                
                throw new Exception("Could not find.Please try again");
            }
        }

        
        [HttpGet("GetAllStoresByID")]
        public IActionResult GetAllStoresByID([FromBody] int storeid)
        {
            try
            {
                return Ok(_repo.GetAllInventoryByStoreId(storeid));
            }
            catch (System.Exception)
            {
                
                throw new Exception("Please try again");
            }
        }
    }
}

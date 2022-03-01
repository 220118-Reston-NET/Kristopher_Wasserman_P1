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
    
    
    public class ProductsController : ControllerBase
    {
        private readonly ILakeJacksonBL _repo;
        public ProductsController(ILakeJacksonBL p_name)
        {
            _repo = p_name;
        } 
        
        // GET: api/Products/5
        [HttpGet("GetAllProducts")]
        
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_repo.GetAllProducts());
            }
            catch (Exception ex)
            {
                
             return StatusCode(422, ex.Message);
            }
        }

        // POST: api/Products
        [HttpPost("AddProduct")]
        public  IActionResult AddProducts([FromQuery] Products p_name,int eID,string password)
        { 
            if(_repo.IsAdmin(eID,password) == true)
            {
                try
                {
                    return Created("Product has been added!",_repo.AddProduct(p_name));
                }
                catch (Exception ex)
                {
                    
                    return StatusCode(422,ex.Message);
                }
            }
            else
            {
                return StatusCode(401, "Please try again");
            }
        }

        [HttpGet("GetProductsByStoreID")]
        public  IActionResult AddProductsByStoreID([FromQuery] int storeid)
        { 
            try
            {
                return Ok(_repo.GetAllProductsByStoreID(storeid));
            }
            catch (Exception ex)
            {
                
                return StatusCode(422,ex.Message);
            }
        }
        // PUT: api/Products/5
        [HttpPut("ReplinishInventory")]
        public IActionResult ReplemishInventory([FromQuery] int storeid,[FromQuery] int productid,[FromQuery] int quantity)
        {
            
                try
                {
                    return Ok(_repo.ReplemishInventory(storeid, productid,quantity));
                }
                catch (Exception ex)
                {
                    
                    return StatusCode(422, ex.Message);
                }
           
        }
    }
}

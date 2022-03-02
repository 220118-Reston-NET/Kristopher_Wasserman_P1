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
        /// <summary>
        /// Gets all products from the Company
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProducts")]
        
        public IActionResult GetAllProducts()
        {
            
            try
            {
                Log.Information("user has looked up the products of the company");
                return Ok(_repo.GetAllProducts());
            }
            catch (Exception ex)
            {
              Log.Error("The user did nothing");  
             return StatusCode(422, ex.Message);
            }
        }

        // POST: api/Products
        /// <summary>
        /// This will add a product to the company
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="eID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("AddProduct")]
        public  IActionResult AddProducts([FromQuery] Products p_name,int eID,string password)
        { 
            if(_repo.IsAdmin(eID,password) == true)
            {
                try
                {
                    Log.Information("the manager added more products");
                    return Created("Product has been added!",_repo.AddProduct(p_name));
                }
                catch (Exception ex)
                {
                    Log.Error("The manager made a mistake");
                    return StatusCode(422,ex.Message);
                }
            }
            else
            {
                return StatusCode(401, "Please try again");
            }
        }

        /// <summary>
        /// This will get the products from a partiular store
        /// </summary>
        /// <param name="storeid"></param>
        /// <returns></returns>
        [HttpGet("GetProductsByStoreID")]
        public  IActionResult AddProductsByStoreID([FromQuery] int storeid)
        { 
            try
            {
                Log.Information("The user looked up products of a store");
                return Ok(_repo.GetAllProductsByStoreID(storeid));
            }
            catch (Exception ex)
            {
                Log.Error("The user made an error. Error: " + ex.Message);
                return StatusCode(422,ex.Message);
            }
        }
        // PUT: api/Products/5
        /// <summary>
        /// This will remplenish the inventory of store
        /// </summary>
        /// <param name="storeid"></param>
        /// <param name="productid"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPut("ReplinishInventory")]
        public IActionResult ReplemishInventory([FromQuery] int storeid,[FromQuery] int productid,[FromQuery] int quantity)
        {
            
                try
                {
                    Log.Information("The user replienished the store.");
                    return Ok(_repo.ReplemishInventory(storeid, productid,quantity));
                }
                catch (Exception ex)
                {
                    Log.Error("the user made an error:" + ex.Message);
                    return StatusCode(422, ex.Message);
                }
           
        }
    }
}

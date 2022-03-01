using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class CustomersController : ControllerBase
    {
        private readonly ILakeJacksonBL repo;

        /// <summary>
        /// adds a customer via an api
        /// </summary>
        /// <param name="p_cInfoBL"></param>

        public CustomersController(ILakeJacksonBL p_cInfoBL)
        {
            repo = p_cInfoBL;
        } 
        // GET: api/Customer
        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers([FromQuery]int eID,string pass)
        {
            
                try
                {
                    return Ok(repo.GetAllCustomers());
                }
                catch (SqlException)
                {
                    
                    return NotFound();
                }
            
            
            
        }

        // GET: api/Customer/5
        [HttpGet("GetCustomerByID")]
        public IActionResult GetCustomer([FromQuery] int cId)
        {
            try
            {
                return Ok(repo.GetCustomerById(cId));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
        }

        // POST: api/Customer
        [HttpPost("Add")]
        public IActionResult AddCustomer([FromQuery] Customers p_Name, int eID,string pass)
        {
            if(repo.IsAdmin(eID,pass))
            {
                try
                {
                    return Created("Customer Added Successfully!", repo.AddCustomer(p_Name));
                }
                catch (System.Exception ex)
                {
                    
                    return Conflict(ex.Message);
                }
            }
            else{
                return StatusCode(404);
            }
        }
    }
}

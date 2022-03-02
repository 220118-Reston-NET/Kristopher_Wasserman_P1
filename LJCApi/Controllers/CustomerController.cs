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

        /// <summary>
        /// This Method will get all customers from the database with admin powers
        /// </summary>
        /// <param name="eID"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers([FromQuery]int eID,string pass)
        {
            
            if(repo.IsAdmin(eID,pass))
            {
                Log.Information("A manager enter GetAllCustomer");
                try
                {
                    return Ok(repo.GetAllCustomers());
                }
                catch (SqlException)
                {
                    Log.Error("The manager made a mistake");
                    return NotFound();
                }
            }
            else
            {
                return NotFound("Not Autherized to enter this area");
            }
            
            
            
        }

        // GET: api/Customer/5
        /// <summary>
        /// This method will get all customers by a given id
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        [HttpGet("GetCustomerByID")]
        public IActionResult GetCustomer([FromQuery] int cId)
        {
            Log.Information("User looked up all customers by a id");
            try
            {
                return Ok(repo.GetCustomerById(cId));
            }
            catch (Exception ex)
            {
                Log.Error("The user made an error at getcustomerbyid" + ex.Message);
                return NotFound();
            }
        }

        /// <summary>
        /// Adds a customer to the database with admin powers needed
        /// </summary>
        /// <param name="p_Name"></param>
        /// <param name="eID"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public IActionResult AddCustomer([FromQuery] Customers p_Name, int eID,string pass)
        {
            if(repo.IsAdmin(eID,pass))
            {
                Log.Information("A Manager has added a new customer to the company. Money!");
                try
                {
                    return Created("Customer Added Successfully!", repo.AddCustomer(p_Name));
                }
                catch (System.Exception ex)
                {
                    Log.Error("The manager made an mistake in adding a customer. Error: " + ex.Message);
                    return Conflict(ex.Message);
                }
            }
            else{
                return StatusCode(404);
            }
        }
    }
}

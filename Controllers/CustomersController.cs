using CustomersCrud.Interfaces;
using CustomersCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomersCrud.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

 

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {           
            try
            {
                var result = await _customerService.GetAllEntitiesAsync();
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return BadRequest();
            }

           
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(Customers request)
        {      
            try
            {
                request.created_at = DateTime.Now.ToString();
                var result = await _customerService.CreateEntityAsync(request);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(Customers request)
        {            

            try
            {
                var result = await _customerService.UpdateEntityAsync(request);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(Customers request)
        {
            try
            {
                await _customerService.DeleteEntityAsync(request.Id);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
            return Ok();
        }
    }
}

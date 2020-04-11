using CarRent.Core.Models;
using CarRent.Core.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace CarRent.Controllers
{
    public class CalculatorController : ApiController
    {
        CalculatorService calculatorService = new CalculatorService();

        [HttpPost]
        public IHttpActionResult Calculate(List<CalculatorRequest> calculatorRequests)
        {
            return Ok(calculatorService.Calculate(calculatorRequests));
        }
    }
}

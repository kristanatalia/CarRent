using CarRent.Core.Services.Calculator;
using CarRent.Core.Services.Calculator.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CarRent.Controllers.api
{
    public class CalculatorController : ApiController
    {
        private CalculatorService calculatorService = new CalculatorService();

        [HttpPost]
        public IHttpActionResult Calculate(List<CalculatorRequest> calculatorRequests)
        {
            return Ok(calculatorService.Calculate(calculatorRequests));
        }
    }
}

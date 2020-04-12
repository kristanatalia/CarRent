using CarRent.Core.Services.Car;
using CarRent.Core.Services.Car.Models;
using System;
using System.Web.Http;

namespace CarRent.Controllers.api
{
    public class CarController : ApiController
    {
        private CarService carService = new CarService();

        public CarController()
        {

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(carService.GetList());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(CarInsertRequest carInsertRequest)
        {
            try
            {
                carService.Insert(carInsertRequest);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(CarUpdateRequest carUpdateRequest)
        {
            try
            {
                carService.Update(carUpdateRequest);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(CarDeleteRequest carDeleteRequest)
        {
            try
            {
                carService.Delete(carDeleteRequest);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}

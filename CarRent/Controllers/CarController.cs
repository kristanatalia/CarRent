using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using CarRent.Core.Models;
using CarRent.Core.Services;

namespace CarRent.Controllers
{
    public class CarController : ApiController
    {
        CarService carService = new CarService();

        public CarController()
        {

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(carService.GetList());
        }

        [HttpPut]
        public IHttpActionResult Put(CarInsertRequest carInsertRequest)
        {
            carService.Insert(carInsertRequest);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Post(CarUpdateRequest carUpdateRequest)
        {
            carService.Update(carUpdateRequest);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(CarDeleteRequest carDeleteRequest)
        {
            carService.Delete(carDeleteRequest);
            return Ok();
        }
    }
}

using CarRent.Core.Models;
using CarRent.Database.Models;
using CarRent.Database.Repository;
using System;
using System.Collections.Generic;

namespace CarRent.Core.Services
{
    public class CarService
    {
        CarRepository carRepository = new CarRepository();
        public List<CarResponse> GetList()
        {
            List<CarModel> carModel = carRepository.GetData();

            List<CarResponse> carResponse = new List<CarResponse>();

            foreach (var item in carModel)
            {
                carResponse.Add(new CarResponse() { Id = item.Id, Brand = item.Brand, Model = item.Model, Price = item.Price, ProdYear = item.ProdYear });
            }

            return carResponse;
        }

        public void Insert(CarInsertRequest carInsertRequest)
        {
            carRepository.Insert(carInsertRequest);
        }

        public void Update(CarUpdateRequest carUpdateRequest)
        {
            carRepository.Update(carUpdateRequest);
        }

        public void Delete(CarDeleteRequest carDeleteRequest)
        {
            carRepository.Delete(carDeleteRequest);
        }
    }
}

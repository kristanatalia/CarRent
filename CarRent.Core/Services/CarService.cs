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

        public int Insert(CarInsertRequest carInsertRequest)
        {
            Validate(carInsertRequest);

            return carRepository.Insert(carInsertRequest);
        }

        public int Update(CarUpdateRequest carUpdateRequest)
        {
            Validate(carUpdateRequest);

            return carRepository.Update(carUpdateRequest);
        }

        public int Delete(CarDeleteRequest carDeleteRequest)
        {
            return carRepository.Delete(carDeleteRequest);
        }

        private void Validate(dynamic request)
        {
            if (string.IsNullOrEmpty(request.Brand))
                throw new Exception("Brand is required");
            if (string.IsNullOrEmpty(request.Model))
                throw new Exception("Model is required");
            if (request.ProdYear <= 0)
                throw new Exception("Production Year is required");
            if (request.Price <= 0)
                throw new Exception("Rent Price is required");
        }
    }
}
using CarRent.Core.Models;
using CarRent.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CarRent.UnitTest
{
    [TestClass]
    public class CarUnitTest
    {
        private CarService carService = new CarService();

        [TestMethod]
        public void GetCar_ShouldMatchCount()
        {
            carService.SeedCar();
            var expected = carService.GetTestCar().Count;
            var actual = carService.GetList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void InsertCar_ShouldThrowException()
        {
            carService.Truncate();
            CarInsertRequest carInsertRequest = new CarInsertRequest() { Brand = "", Model = "Avanza", Price = 120000, ProdYear = 2010 };
            carService.Insert(carInsertRequest);
        }

        [TestMethod]
        public void InsertCar_ShouldMatchAllData()
        {
            carService.SeedCar();
            bool flag = true;
            var actualData = carService.GetList();
            var expectedData = carService.GetTestCar();
            for (int i = 0; i < expectedData.Count; i++)
            {
                var data = actualData[i];
                var data2 = expectedData[i];
                if(data.Brand != data2.Brand || data.Model != data2.Model || data.Price != data2.Price || data.ProdYear != data2.ProdYear)
                {
                    flag = false;
                    break;
                }
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UpdateCar_ShouldThrowException()
        {
            carService.SeedCar();
            CarUpdateRequest carUpdateRequest = new CarUpdateRequest() { Id = 1, Brand = "", Model = "Avanza", Price = 120000, ProdYear = 2010 };
            carService.Update(carUpdateRequest);
        }

        [TestMethod]
        public void UpdateCar_ShouldMatchAllData()
        {
            carService.SeedCar();
            carService.Update(CarUpdateRequest);
            bool flag = true;
            var expected = CarUpdateRequest;
            var actual = carService.GetList().First(e => e.Id == CarUpdateRequest.Id);
            if (actual.Brand != expected.Brand || actual.Model != expected.Model || actual.Price != expected.Price || actual.ProdYear != expected.ProdYear)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void DeleteCar_ShouldDeleteSuccessfully()
        {
            carService.SeedCar();
            carService.Delete(new CarDeleteRequest { Id = 3 });
            Assert.IsNull(carService.GetList().FirstOrDefault(e => e.Id == 3));
        }

        private CarUpdateRequest CarUpdateRequest =
                new CarUpdateRequest()
                {
                    Id = 2,
                    Brand = "Nissan",
                    Model = "Grand Livina A/T",
                    Price = 250000,
                    ProdYear = 2015
                };
    }
}

using CarRent.Core.Services.Calculator;
using CarRent.Core.Services.Calculator.Models;
using CarRent.Core.Services.Car;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CarRent.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        private CarService carService = new CarService();
        private CalculatorService calculatorService = new CalculatorService();

        [TestMethod]
        public void Calculate_WithoutDiscount_ShouldMatchGrandTotal()
        {
            carService.SeedCar();
            var carList = new List<CalculatorRequest>();
            carList.Add(new CalculatorRequest { CarId = 4, Days = 1 });
            var result = calculatorService.Calculate(carList);
            var expected = 350000;
            var actual = result.GrandTotal;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculate_DaysDiscount_ShouldMatchGrandTotal()
        {
            carService.SeedCar();
            var carList = new List<CalculatorRequest>();
            carList.Add(new CalculatorRequest { CarId = 4, Days = 3 });
            var result = calculatorService.Calculate(carList);
            var expected = 997500;
            var actual = result.GrandTotal;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculate_ProdYearDiscount_ShouldMatchGrandTotal()
        {
            carService.SeedCar();
            var carList = new List<CalculatorRequest>();
            carList.Add(new CalculatorRequest { CarId = 1, Days = 1 });
            var result = calculatorService.Calculate(carList);
            var expected = 139500;
            var actual = result.GrandTotal;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculate_DaysProdYearDiscount_ShouldMatchGrandTotal()
        {
            carService.SeedCar();
            var carList = new List<CalculatorRequest>();
            carList.Add(new CalculatorRequest { CarId = 1, Days = 5 });
            var result = calculatorService.Calculate(carList);
            var expected = 662625;
            var actual = result.GrandTotal;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculate_DaysCountCarDiscount_ShouldMatchGrandTotal()
        {
            carService.SeedCar();
            var carList = new List<CalculatorRequest>();
            carList.Add(new CalculatorRequest { CarId = 2, Days = 5 });
            carList.Add(new CalculatorRequest { CarId = 4, Days = 1 });
            var result = calculatorService.Calculate(carList);
            var expected = 1084500;
            var actual = result.GrandTotal;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculate_ProdYearCountCarDiscount_ShouldMatchGrandTotal()
        {
            carService.SeedCar();
            var carList = new List<CalculatorRequest>();
            carList.Add(new CalculatorRequest { CarId = 1, Days = 1 });
            carList.Add(new CalculatorRequest { CarId = 4, Days = 1 });
            var result = calculatorService.Calculate(carList);
            var expected = 440550;
            var actual = result.GrandTotal;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Calculate_DaysProdYearCountCarDiscount_ShouldMatchGrandTotal()
        {
            carService.SeedCar();
            var carList = new List<CalculatorRequest>();
            carList.Add(new CalculatorRequest { CarId = 1, Days = 5 });
            carList.Add(new CalculatorRequest { CarId = 4, Days = 1 });
            var result = calculatorService.Calculate(carList);
            var expected = 911362.5m;
            var actual = result.GrandTotal;
            Assert.AreEqual(expected, actual);
        }

    }
}

using CarRent.Core.Models;
using CarRent.Database.Models;
using CarRent.Database.Repository;
using System;
using System.Collections.Generic;

namespace CarRent.Core.Services
{
    public class CalculatorService
    {
        CarRepository carRepository = new CarRepository();
        public CalculatorTotalResponse Calculate(List<CalculatorRequest> calculatorRequests)
        {
            List<CarModel> carModel = carRepository.GetData();
            CalculatorTotalResponse calculatorTotalResponse = new CalculatorTotalResponse();
            List<CalculatorResponse> calculatorResponse = new List<CalculatorResponse>();
            int index = 0;
            decimal subTotal = 0;
            decimal discountTotal = 0;
            decimal grandTotal = 0;

            foreach (var calc in calculatorRequests)
            {
                Int64 id = calc.CarId;
                CarModel car = carModel.Find(item => item.Id == calc.CarId);
                decimal discount = 0;
                decimal price = car.Price * calc.Days;
                decimal priceAfterDiscount = price;

                if (calc.Days >= 3)
                {
                    discount = priceAfterDiscount * 5 / 100;
                    priceAfterDiscount = price - discount;
                }

                if(car.ProdYear < 2010)
                {
                    discount += priceAfterDiscount * 7 / 100;
                    priceAfterDiscount = price - discount;
                }

                subTotal += priceAfterDiscount;

                calculatorResponse.Add(new CalculatorResponse() {
                    Id = ++index,
                    CarId = car.Id,
                    Car = car.Brand + " - " + car.Model,
                    ProdYear = car.ProdYear,
                    Price = car.Price,
                    Days = calc.Days,
                    PriceBeforeDiscount = price,
                    Discount = discount,
                    PriceAfterDiscount = priceAfterDiscount
                });
            }

            grandTotal = subTotal;

            if(calculatorRequests.Count >= 2)
            {
                discountTotal = subTotal * 10 / 100;
                grandTotal = grandTotal - discountTotal;
            }

            calculatorTotalResponse.SubTotal = subTotal;
            calculatorTotalResponse.Discount = discountTotal;
            calculatorTotalResponse.GrandTotal = grandTotal;
            calculatorTotalResponse.CalculatorResponse = calculatorResponse;

            return calculatorTotalResponse;
        }
    }
}

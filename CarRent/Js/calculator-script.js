var carData = [];
var rentList = [];
var table = null;
var id = 1;

$(document).ready(function () {
    GetCarData();
    GetRentList();

    $("#btnClear").click(function (e) {
        e.preventDefault();
        rentList = [];
        GetRentList();
        id = 1;
        $("#btnAddCar").prop('disabled', false);
        $("#carTable td.subTotal").text("");
        $("#carTable td.discountTotal").text("");
        $("#carTable td.grandTotal").text("");
    });

    $("#btnAddCar").click(function (e) {
        e.preventDefault();
        var car = $('#car :selected').text();
        var carId = $('#car :selected').val();
        var index = carData.findIndex(car => car.Id == carId);
        var carPrice = carData[index].Price;

        rentList.push({
            Id: id++,
            CarId: carId,
            Car: car,
            ProdYear: carData[index].ProdYear,
            Price: carPrice,
            Days: $("#days").val(),
            PriceBeforeDiscount: 0,
            Discount: 0,
            PriceAfterDiscount: 0
        });

        $("#carForm")[0].reset();
        GetRentList();
    });

    $("#carTable").on("click", "a.Delete", function (e) {
        e.preventDefault();
        if (confirm("Do you want to delete this row?")) {
            var currentRow = $(this).parents('tr')[0];
            var data = table.row(currentRow).data();
            rentList = rentList.filter(function (value) { return value.Id != data.Id });
            GetRentList();
        }
    });

    $("#btnCalculate").click(function (e) {
        e.preventDefault();
        if (rentList.length == 0)
            return;
        var uri = "/api/calculator/calculate";
        var data = [];
        for (i = 0; i < rentList.length; i++)
        {
            data.push({
                CarId: rentList[i].CarId,
                Days: rentList[i].Days
            });
        }
        ajaxPost(uri, data).then(function (response) {
            console.log(response);
            rentList = response.CalculatorResponse;
            GetRentList();
            $("#carTable td.subTotal").text(FormatCurrency(response.SubTotal));
            $("#carTable td.discountTotal").text(FormatCurrency(response.Discount));
            $("#carTable td.grandTotal").text(FormatCurrency(response.GrandTotal));
            $("#carTable a.Delete").hide();
            $("#btnAddCar").prop('disabled', true);
        });
    });
});

function FormatCurrency(a) {
    return (a).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
}

function GetCarData() {
    var uri = "/api/car/get";
    var myDropDownList = $("#car");
    ajaxGet(uri).then(function (response) {
        console.log(response);
        carData = response;
        myDropDownList.empty(); 
        for (i = 0; i < response.length; i++)
        {
            var car = response[i];
            myDropDownList.append(new Option(car.Brand + ' - ' + car.Model, car.Id));
        }
    }).fail(function () {
    });
}

function GetRentList() {
    table = $('#carTable').DataTable({
        data: rentList,
        destroy: true,
        dataSrc: "",
        searching: false,
        lengthChange: false,
        paginate: false,
        info: false,
        pageLength: 100,
        columns: [
            {
                data: "_",
                render: function () {
                    return "<a class='Delete' href=''>Delete</a>";
                }
            },
            { data: "Id"},
            { data: "CarId" },
            { data: "Car" },
            { data: "ProdYear" },
            {
                data: "Price",
                render: function (data) {
                    return FormatCurrency(data);
                }
            },
            { data: "Days" },
            {
                data: "PriceBeforeDiscount",
                render: function (data) {
                    return FormatCurrency(data);
                }
            },
            {
                data: "Discount",
                render: function (data) {
                    return FormatCurrency(data);
                }
            },
            {
                data: "PriceAfterDiscount",
                render: function (data) {
                    return FormatCurrency(data);
                }
            }
        ]
    });
}
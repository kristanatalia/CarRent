// Call the dataTables jQuery plugin
var table = null;
$(document).ready(function () {
    GetCarData();
    $("#carForm").submit(function (e) {
        e.preventDefault();
    });

    $("#addCar").click(function (e) {
        e.preventDefault();
        $("#carForm")[0].reset();
        var myModal = $('#carFormModal');
        $('#idCar', myModal).val('');
        $('h4.modal-title', myModal).text('Add New Car');
    });

    $("#btnAddCar").click(function () {
        if ($("#brand").val() == "")
        {
            alert("Brand cannot be empty");
            return;
        }
        if ($("#model").val() == "") {
            alert("Model cannot be empty");
            return;
        }
        if ($("#prodYear").val() == "") {
            alert("Production Year cannot be empty");
            return;
        }
        if ($("#price").val() == "") {
            alert("Rent Price cannot be empty");
            return;
        }
        if ($("#idCar").val() == "") {
            var data = {
                Brand: $("#brand").val(),
                Model: $("#model").val(),
                ProdYear: $("#prodYear").val(),
                Price: $("#price").val()
            };
            var uri = "/api/car/put";
            ajaxPut(uri, data).then(function () {
                GetCarData();
            });
        }
        else
        {
            var data = {
                Id: $("#idCar").val(),
                Brand: $("#brand").val(),
                Model: $("#model").val(),
                ProdYear: $("#prodYear").val(),
                Price: $("#price").val()
            };
            var uri = "/api/car/post";
            ajaxPost(uri, data).then(function () {
                GetCarData();
            });
        }
        
    });

    $("#carTable").on("click", "a.Edit", function (e) {
        e.preventDefault();
        var myModal = $('#carFormModal');
        var currentRow = $(this).parents('tr')[0];
        var data = table.row(currentRow).data();

        $('h4.modal-title', myModal).text('Edit Car');
        $('#idCar', myModal).val(data.Id);
        $('#brand', myModal).val(data.Brand);
        $('#model', myModal).val(data.Model);
        $('#prodYear', myModal).val(data.ProdYear);
        $('#price', myModal).val(data.Price);
        myModal.modal({ show: true });
        return false;
    });

    $("#carTable").on("click", "a.Delete", function (e) {
        e.preventDefault();
        if (confirm("Do you want to delete this row?")) {
            var currentRow = $(this).parents('tr')[0];
            var data = table.row(currentRow).data();
            var uri = "/api/car/delete";
            var data = {
                Id: data.Id
            };
            ajaxDelete(uri, data).then(function () {
                GetCarData();
            });
        }
    });
});

function FormatCurrency(a) {
    return (a).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
}

function GetCarData() {
    var uri = "/api/car/get";
    
    ajaxGet(uri).then(function (response) {
        console.log(response);
        table = $('#carTable').DataTable({
            data: response,
            destroy: true,
            dataSrc: "",
            columns: [
                {
                    data: "_",
                    render: function () {
                        return "<a class='Edit' href=''>Edit</a> <a class='Delete' href=''>Delete</a>";
                    }
                },
                { data: "Id" },
                { data: "Brand" },
                { data: "Model" },
                { data: "ProdYear" },
                {
                    data: "Price",
                    render: function (data) {
                        return FormatCurrency(data);
                    }
                }
            ]
        });
    }).fail(function () {
    });
}
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
        var data = {
            Brand: $("#brand").val(),
            Model: $("#model").val(),
            ProdYear: $("#prodYear").val(),
            Price: $("#price").val()
        };

        if ($("#idCar").val() == "") {
            var uri = "/api/car/put";
            ajaxPut(uri, data).then(function () {
                GetCarData();
                var myModal = $('#carFormModal');
                myModal.modal("toggle");
                alert("Data has been inserted");
            }).fail(function (err) {
                alert(err.responseJSON.ExceptionMessage);
            });
        }
        else
        {
            data.Id = $("#idCar").val();
            var uri = "/api/car/post";
            ajaxPost(uri, data).then(function () {
                GetCarData();
                var myModal = $('#carFormModal');
                myModal.modal("toggle");
                alert("Data has been updated");
            }).fail(function (err) {
                alert(err.responseJSON.ExceptionMessage);
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
        myModal.modal("toggle");
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
                alert("Data has been deleted");
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
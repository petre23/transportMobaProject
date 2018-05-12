/// <reference path="../jsgrid/jsgrid.js" />
/// <reference path="../jsgrid/jsgrid.min.js" />

var truckController =
    {
        selectedTruck: "",
        getTrucks: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Truck/GetTrucks",
                success: function (res) {
                    truckController.initGrid(res.trucks);
                },
                error: function (jqXHR, textStatus, exception, errorThrown) {
                    $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                    $("#errorDialog").dialog("open");
                }
            });
        },
        initGrid: function (trucks)
        {
            $("#trucksGrid").jsGrid({
                width: "100%",
                height: "600px",

                inserting: false,
                editing: false,
                sorting: true,
                paging: false,
                rowClick: function (args) {
                    $("#trucksGrid tr").removeClass("selected-row")
                    $selectedRow = $(args.event.target).closest("tr");
                    $selectedRow.addClass("selected-row");

                    truckController.selectedTruck = args.item.Id;

                    $("#editButton").prop('disabled', false);
                },
                data: trucks,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css:"hide" },
                    { name: "RegistrationNumber", title: 'Nr. Inmatriculare', type: "text", width: 100 },
                    { name: "BrandName", title: 'Marca', type: "text", width: 100 },
                    { name: "ManufacturingYearString", title: 'An fabricatie', type: "text", width: 100 },
                    { name: "ITPExpirationDateString", title: 'Data expirare ITP', type: "text", width: 100 },
                    { name: "VignetteExpirationDateString", title: 'Data expirare Vignette', type: "text", width: 100 },
                    { name: "InsuranceExpirationDateString", title: 'Data expirare asigurare', type: "text", width: 100 }
                ]
            });
        },
        addNewTruck: function (){
            window.location = "/Truck/EditTruck";
        },
        editTruck: function () {
            if (truckController.selectedTruck) {
                window.location = "/Truck/EditTruck?truckId=" + truckController.selectedTruck;
            }
        },
    };
truckController.getTrucks();
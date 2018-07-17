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
            $("#editButton").prop('disabled', true);
            $("#deleteButton").prop('disabled', true);

            $("#trucksGrid").jsGrid({
                width: "100%",
                height: "80vh",

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
                    $("#deleteButton").prop('disabled', false);
                },
                data: trucks,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css:"hide" },
                    { name: "RegistrationNumber", title: 'Numar Inmatriculare', type: "text", width: 80 },
                    { name: "BrandName", title: 'Marca', type: "text", width: 80 },
                    { name: "ManufacturingYearString", title: 'An fabricatie', type: "text", width: 60 },
                    { name: "ITPExpirationDateString", title: 'Data expirare ITP', type: "text", width: 80 },
                    { name: "VignetteExpirationDateUKString", title: 'Data expirare vignette UK', type: "text", width: 100 },
                    { name: "VignetteExpirationDateROString", title: 'Data expirare vignette UK', type: "text", width: 100 },
                    { name: "VignetteExpirationDateNLString", title: 'Data expirare vignette NL', type: "text", width: 100 },
                    { name: "InsuranceExpirationDateString", title: 'Data expirare asigurare', type: "text", width: 100 },
                    { name: "TachographExpirationDateString", title: 'Data expirare tahograf', type: "text", width: 100 },
                    { name: "ConformCopyExpirationDateString", title: 'Data expirare copie confirma', type: "text", width: 100 },
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
        deleteTruck: function () {
            if (this.confirmDeleteTruck()) {
                $.ajax({
                    type: 'post',
                    dataType: 'json',
                    url: "/Truck/DeleteTruck",
                    data: { truckId: truckController.selectedTruck },
                    success: function (res) {
                        truckController.getTrucks();
                    },
                    error: function (jqXHR, textStatus, exception, errorThrown) {
                        $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                        $("#errorDialog").dialog("open");
                    }
                });
            }
        },
        confirmDeleteTruck: function () {
            var txt;
            var r = confirm("Sunteti sigur ca vreti sa stergeti acest camion?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }
    };
truckController.getTrucks();
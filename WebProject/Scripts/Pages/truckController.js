/// <reference path="../jsgrid/jsgrid.js" />
/// <reference path="../jsgrid/jsgrid.min.js" />


var truckController =
    {
        getTrucks: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Truck/GetTrucks",
            }).done(function (res) {
                truckController.initGrid(res.trucks);
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
                rowClick: function () { alert("click"); },
                data: trucks,
                fields: [
                    { name: "RegistrationNumber", title: 'Nr. Inmatriculare', type: "text", width: 100 },
                    { name: "BrandName", title: 'Marca', type: "text", width: 100 },
                    { name: "ManufacturingYearString", title: 'An fabricatie', type: "text", width: 100 },
                    { name: "ITPExpirationDateString", title: 'Data expirare ITP', type: "text", width: 100 },
                    { name: "VignetteExpirationDateString", title: 'Data expirare Vignette', type: "text", width: 100 },
                    { name: "InsuranceExpirationDateString", title: 'Data expirare asigurare', type: "text", width: 100 },
                    { type: "control" }
                ]
            });
        },
        saveTruck: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Truck/SaveTruck",
                success: function (res) {

                }
            });
        },
        getTruck: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Truck/GetTruck",
                success: function (res) {

                }
            });
        }
    };
truckController.getTrucks();
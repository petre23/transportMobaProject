/// <reference path="../jsgrid/jsgrid.js" />
/// <reference path="../jsgrid/jsgrid.min.js" />


var truckController =
    {
        getTrucks: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Truck/GetTrucks",
            }).done(function (trucks) {
                truckController.initGrid(trucks);
            });
        },
        initGrid: function (trucks)
        {
            $("#trucksGrid").jsGrid({
                width: "100%",
                height: "400px",

                inserting: false,
                editing: false,
                sorting: true,
                paging: false,
                rowClick: function () { alert("click");},
                data: trucks,
                fields: [
                    { name: "RegistrationNumber", type: "text", width: 150},
                    { name: "BrandName", type: "text", width: 50 },
                    { name: "ManufacturingYear", type: "text", width: 100 },
                    { name: "ITPExpirationDate", type: "text", width: 100 },
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
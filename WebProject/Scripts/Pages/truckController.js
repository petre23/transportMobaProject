/// <reference path="../jsgrid/jsgrid.js" />
/// <reference path="../jsgrid/jsgrid.min.js" />

var truckController =
    {
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
                    var truckId = args.item.Id;
                    window.location = "/Truck/EditTruck?truckId="+truckId;
                },
                data: trucks,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css:"hide" },
                    { name: "RegistrationNumber", title: 'Nr. Inmatriculare', type: "text", width: 100 },
                    { name: "BrandName", title: 'Marca', type: "text", width: 100 },
                    { name: "ManufacturingYearString", title: 'An fabricatie', type: "text", width: 100 },
                    { name: "ITPExpirationDateString", title: 'Data expirare ITP', type: "text", width: 100 },
                    { name: "VignetteExpirationDateString", title: 'Data expirare Vignette', type: "text", width: 100 },
                    { name: "InsuranceExpirationDateString", title: 'Data expirare asigurare', type: "text", width: 100 },
                    { type: "control" }
                ]
            });
        }
    };
truckController.getTrucks();
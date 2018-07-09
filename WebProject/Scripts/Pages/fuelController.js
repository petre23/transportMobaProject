/// <reference path="../jsgrid/jsgrid.js" />
/// <reference path="../jsgrid/jsgrid.min.js" />

var fuelController =
    {
        selectedFuel: "",
        getFuel: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Fuel/GetFuelInfo",
                success: function (res) {
                    fuelController.initGrid(res.fuelData);
                },
                error: function (jqXHR, textStatus, exception, errorThrown) {
                    $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                    $("#errorDialog").dialog("open");
                }
            });
        },
        initGrid: function (fuel) {
            $("#editFuelButton").prop('disabled', true);
            $("#deleteFuelButton").prop('disabled', true);

            $("#fuelGrid").jsGrid({
                width: "100%",
                height: "80vh",

                inserting: false,
                editing: false,
                sorting: true,
                paging: false,
                rowClick: function (args) {
                    $("#fuelGrid tr").removeClass("selected-row")
                    $selectedRow = $(args.event.target).closest("tr");
                    $selectedRow.addClass("selected-row");

                    fuelController.selectedFuel = args.item.Id;

                    $("#editFuelButton").prop('disabled', false);
                    $("#deleteFuelButton").prop('disabled', false);
                },
                data: fuel,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css: "hide" },
                    { name: "WorkerName", title: 'Sofer', type: "text", width: 80 },
                    { name: "DateString", title: 'Data', type: "text", width: 80},
                    { name: "GPSInitialConsumption", title: 'Consum GPS Initial', type: "text", width: 80 },
                    { name: "GPSFinalConsumption", title: 'Consum GPS Final', type: "text", width: 80 },
                    { name: "GPSConsumption", title: 'Consum GPS', type: "text", width: 60 },
                    { name: "FueledKM", title: 'Km la Alimentare', type: "text", width: 80 },
                    { name: "FueledDieseKMLitersString", title: 'Alimentare Diesel EW litrii', type: "text", width: 100 },
                    { name: "DieselValue", title: 'Valoare Diesel', type: "text", width: 100 },
                    { name: "RealConsumption", title: 'Consum Real', type: "text", width: 100 },
                    { name: "AdblueLiters", title: 'Adblue Litri', type: "text", width: 100 },
                    { name: "AdblueValue", title: 'Valoare Adblue', type: "text", width: 100 },
                    { name: "EstimatedConsumption", title: 'Consum estimat', type: "text", width: 100 },
                    { name: "TruckRegistrationNumber", title: 'Nr. Inmatriculare Camion', type: "text", width: 100 }
                ]
            });
        },
        addNewFuel: function () {
            window.location = "/Fuel/EditFuel";
        },
        editFuel: function () {
            if (fuelController.selectedFuel) {
                window.location = "/Fuel/EditFuel?fuelId=" + fuelController.selectedFuel;
            }
        },
        deleteFuel: function () {
            if (this.confirmDeleteFuel()) {
                $.ajax({
                    type: 'post',
                    dataType: 'json',
                    url: "/Fuel/DeleteFuel",
                    data: { fuelId: fuelController.selectedFuel },
                    success: function (res) {
                        fuelController.getFuel();
                    },
                    error: function (jqXHR, textStatus, exception, errorThrown) {
                        $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                        $("#errorDialog").dialog("open");
                    }
                });
            }
        },
        confirmDeleteFuel: function () {
            var txt;
            var r = confirm("Sunteti sigur ca vreti sa stergeti acesta alimentare?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }
    };
fuelController.getFuel();
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
                data: fuel,
                rowRenderer: function (item) {
                    var $row = $("<tr>");
                    var $cell = $("<td style='border:1px solid lightgrey'>");

                    var $drivesGrid = $("<div id='fuelGroupingGrid'>").addClass("nested-grid");
                    $drivesGrid.jsGrid({
                        width: "100%",
                        height: "auto",
                        data: item.FuelData,
                        heading: true,
                        sorting: true,
                        fields: [
                            { name: "Id", title: 'Id', type: "text", css: "hide" },
                            { name: "DateString", title: 'Data', type: "text", width: 80 },
                            { name: "GPSInitialConsumption", title: 'Consum GPS Initial', type: "text", width: 80 },
                            { name: "GPSFinalConsumption", title: 'Consum GPS Final', type: "text", width: 80 },
                            { name: "GPSConsumption", title: 'Consum GPS', type: "text", width: 70 },
                            { name: "FueledKM", title: 'Km la Alimentare', type: "text", width: 85 },
                            { name: "FueledDieseKMLiters", title: 'Alimentare Diesel EW litrii', type: "text", width: 90 },
                            { name: "DieselValue", title: 'Valoare Diesel', type: "text", width: 85 },
                            { name: "RealConsumption", title: 'Consum Real', type: "text", width: 85 },
                            { name: "AdblueLiters", title: 'Adblue Litri', type: "text", width: 85 },
                            { name: "AdblueValue", title: 'Valoare Adblue', type: "text", width: 85 },
                            { name: "EstimatedConsumption", title: 'Consum estimat', type: "text", width: 85 },
                            { name: "TruckRegistrationNumber", title: 'Nr. Inmatriculare Camion', type: "text", width: 100 }
                        ],
                        rowClick: function (args) {
                            $("#fuelGroupingGrid tr").removeClass("selected-row")
                            $selectedRow = $(args.event.target).closest("tr");
                            $selectedRow.addClass("selected-row");

                            fuelController.selectedFuel = args.item.Id;

                            $("#editFuelButton").prop('disabled', false);
                            $("#deleteFuelButton").prop('disabled', false);
                        },
                    });

                    var $link = $("<a>").html("Sofer: " + item.Worker + "&emsp; KM la alimentare:" + item.KM + "&emsp; Consum Real mediu: " + item.RealConsumptionAvg + "&emsp; Total Valoare diesel: " + item.TotalDisel + "&emsp; Total Valoare AdBlue: " + item.TotalAdBlue)
                        .prop("href", "#")
                        .click(function () {
                            $drivesGrid.toggle();
                        });

                    $cell.append($link)
                        .append($drivesGrid);

                    return $row.append($cell);
                },
                fields: [
                    { title: 'Alimentari', type: "text", width: 100 }
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
        initExportControls: function () {
            $("#startDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });
            $("#endDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });
            $("#startDateTruck").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });
            $("#endDateTruck").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });
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
fuelController.initExportControls();
/// <reference path="../jsgrid/jsgrid.js" />
/// <reference path="../jsgrid/jsgrid.min.js" />

var fuelController =
    {
        selectedFuel: "",
        getFuel: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Fuel/GetFuel",
                success: function (res) {
                    fuelController.initGrid(res.fuel);
                },
                error: function (jqXHR, textStatus, exception, errorThrown) {
                    $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                    $("#errorDialog").dialog("open");
                }
            });
        },
        initGrid: function (fuel) {
            $("#editButton").prop('disabled', true);
            $("#deleteButton").prop('disabled', true);

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

                    $("#editButton").prop('disabled', false);
                    $("#deleteButton").prop('disabled', false);
                },
                data: fuel,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css: "hide" },
                    { name: "ConsumGPSInitial", title: 'Consum GPS Initial', type: "text", width: 80 },
                    { name: "ConsumGPSFinal", title: 'Consum GPS Final', type: "text", width: 80 },
                    { name: "ConsumGPS", title: 'Consum GPS', type: "text", width: 60 },
                    { name: "KMAlimentati", title: 'Km la Alimentare', type: "text", width: 80 },
                    { name: "AlimentareDieselEWlitrii", title: 'Alimentare Diesel EW litrii', type: "text", width: 100 },
                    { name: "ValoareDiesel", title: 'Valoare Diesel', type: "text", width: 100 },
                    { name: "ConsumReal", title: 'Consum Real', type: "text", width: 100 },
                    { name: "AdblueLitri", title: 'Adblue Litri', type: "text", width: 100 },
                    { name: "ValoareAdblue", title: 'Valoare Adblue', type: "text", width: 100 },
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
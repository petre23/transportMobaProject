var editFuelController = {
    fuelId: null,
    saveFuel: function (fuel) {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Fuel/SaveFuel",
            data: fuel,
            success: function (res) {
                window.location = "/Fuel/Index";
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                setTimeout(function () { $("#errorDialog").dialog("open"); }, 1000);
            }
        });
    },
    getFuel: function () {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Fuel/GetFuelById",
            data: {
                fuelId: this.getParameterByName("fuelId", new URL(window.location.href)),
            },
            success: function (res) {
                editFuelController.fuelId = res.fuel.Id;
                var fuel = res.fuel;
                editFuelController.setFuelDetails(fuel);
                editFuelController.initControls();
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                $("#errorDialog").dialog("open");
            }
        });
    },
    setFuelDetails: function (fuel) {
        $("#GPSInitialConsumption").val(fuel.GPSInitialConsumption);
        $("#GPSFinalConsumption").val(fuel.GPSFinalConsumption);
        $("#GPSConsumption").val(fuel.GPSConsumption);
        $("#estimatedConsumption").val(fuel.EstimatedConsumption);
        $("#FueledKM").val(fuel.FueledKM);
        $("#fueledDieseEWLiters").val(fuel.FueledDieseKMLiters);
        $("#dieselValue").val(fuel.DieselValue);
        $("#realConsumption").val(fuel.RealConsumption);
        $("#adblueLiters").val(fuel.AdblueLiters);
        $("#adblueValue").val(fuel.AdblueValue);
        $("#worker").val(fuel.Worker);
        $("#date").val(fuel.DateString);
        $("#KMGPS").val(fuel.DistanceGPS);
        $("#truck").val(fuel.Truck);
    },
    getCorrectDateFormat: function (dateString) {
        var parts = dateString.split("/");
        var date = new Date(parts[2], parts[1] - 1, parts[0]);
        if (date) {
            return date.toISOString();
        }
        return "";
    },
    setupNewFuelInfo: function () {
        this.fuelId = null;
        $("#GPSInitialConsumption").val("");
        $("#GPSFinalConsumption").val("");
        $("#GPSConsumption").val("");
        $("#estimatedConsumption").val("");
        $("#FueledKM").val("");
        $("#fueledDieseEWLiters").val("");
        $("#dieselValue").val("");
        $("#realConsumption").val("");
        $("#adblueLiters").val("");
        $("#adblueValue").val("");
        $("#worker").val("");
        $("#date").val("");
        $("#KMGPS").val("");
        $("#truck").val("");
    },
    initFuel: function () {
        var url = new URL(window.location.href);
        var fuelId = editFuelController.getParameterByName("fuelId", url);
        if (fuelId) {
            editFuelController.getFuel();
        } else {
            editFuelController.setupNewFuelInfo();
            setTimeout(function () { editFuelController.initControls(); }, 0);
        }
    },
    getParameterByName: function (name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    },
    initControls: function () {
        $("#date").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });

        $("#saveFuel").on("submit", function () {
            return false;
        });
    },
    cancelEdit: function () {
        if (this.confirmCancel()) {
            window.location = "/Fuel/Index";
        }
    },
    validateAndSaveFuel: function () {
        var fuelInfo = {
            Id: this.fuelId,
            GPSInitialConsumptionString: $("#GPSInitialConsumption").val(),
            GPSFinalConsumptionString: $("#GPSFinalConsumption").val(),
            GPSConsumptionString: $("#GPSConsumption").val(),
            EstimatedConsumptionString: $("#estimatedConsumption").val(),
            FueledKMString: $("#FueledKM").val(),
            FueledDieseKMLitersString: $("#fueledDieseEWLiters").val(),
            DieselValueString: $("#dieselValue").val(),
            RealConsumptionString: $("#realConsumption").val(),
            AdblueLitersString: $("#adblueLiters").val(),
            AdblueValueString: $("#adblueValue").val(),
            Worker: $("#worker").val(),
            Date: $("#date").val(),
            DistanceGPSString: $("#KMGPS").val(),
            Truck: $("#truck").val()
        };
        this.saveFuel(fuelInfo);
    },
    confirmCancel: function () {
        var txt;
        var r = confirm(" Sunteti sigur ca vreti sa anulati aceasta operatie? \r\n Toate modificarile for fi pierdute!");
        if (r == true) {
            return true;
        } else {
            return false;
        }
    },
    calculateDifference: function () {
        var GPSFinal = parseInt($("#GPSFinalConsumption").val());
        var GPSInitial = parseInt($("#GPSInitialConsumption").val());
        var difference = GPSFinal - GPSInitial;

        $("#GPSConsumption").val(difference);
        if (difference < 0) {
            $("#GPSConsumption").addClass("red-border");
        }
        else {
            $("#GPSConsumption").removeClass("red-border");
        }
    },
};
editFuelController.initFuel();
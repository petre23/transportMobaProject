var editDriveController = {
    driveId: null,
    saveDrive: function (drive) {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Drive/SaveDrive",
            data: drive,
            success: function (res) {
                window.location = "/Drive/Index";
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                setTimeout(function () { $("#errorDialog").dialog("open"); }, 1000);
            }
        });
    },
    getDrive: function () {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Drive/GetDrive",
            data: {
                idDrive: this.getIdFromUrl()
            },
            success: function (res) {
                editDriveController.driveId = res.drive.Id;
                var drive = res.drive;
                editDriveController.setDriveDetails(drive);
                editDriveController.initControls();
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                $("#errorDialog").dialog("open");
            }
        });
    },
    setDriveDetails: function (drive) {
        $("#driver").val(drive.Worker);
        $("#truck").val(drive.Truck);
        $("#date").val(drive.DateString);
        $("#vlaplan").val(drive.Vlaplan);
        $("#vlaref").val(drive.Vlaref);
        $("#loadingPlace").val(drive.LoadingPlace);
        $("#destination").val(drive.Destination);
        $("#KMGpsInitiali").val(drive.InitialGPSKM);
        $("#KMGpsFinal").val(drive.FinalGPSKM);
        $("#KMGps").val(drive.DistanceGPS);
        $("#KMGpl").val(drive.DistanceGpl);
        $("#KMDFSD").val(drive.DistanceDFDS);
        $("#difference").val(drive.Difference);
        $("#reason").val(drive.Reason);
        $("#tons").val(drive.WeightInTons);
        $("#workerCosts").val(drive.WorkerCosts);
        $("#costsSpecifications").val(drive.CostsSpecification);
        $("#payedCosts").val(drive.PayedCosts);
        $("#settlementCosts").val(drive.SettlementCosts);
        $("#totalCosts").val(drive.TotalPayments);
        $("#GPSInitialConsumption").val(drive.GPSInitialConsumption);
        $("#GPSFinalConsumption").val(drive.GPSFinalConsumption);
        $("#GPSConsumption").val(drive.GPSConsumption);
        $("#etimatedConsumption").val(drive.EstimatedConsumption);
        $("#FueledKM").val(drive.FueledKM);
        $("#fueledDieseEWLiters").val(drive.FueledDieseKMLiters);
        $("#dieselValue").val(drive.DieselValue);
        $("#realConsumption").val(drive.RealConsumption);
        $("#adblueLiters").val(drive.AdblueLiters);
        $("#adblueValue").val(drive.AdblueValue);
    },
    getCorrectDateFormat: function (dateString) {
        var parts = dateString.split("/");
        var date = new Date(parts[2], parts[1] - 1, parts[0]);
        if (date) {
            return date.toISOString();
        }
        return "";
    },
    getIdFromUrl: function () {
        var url = new URL(window.location.href);
        var driveId = url.searchParams.get("driveId");
        return driveId;
    },
    setupNewDriveInfo: function () {
        this.driveId = null;
        $("#driver").val("");
        $("#truck").val("");
        $("#date").val("");
        $("#vlaplan").val("");
        $("#vlaref").val("");
        $("#loadingPlace").val("");
        $("#destination").val("");
        $("#KMGpsInitiali").val("");
        $("#KMGpsFinal").val("");
        $("#KMGps").val("");
        $("#KMGpl").val("");
        $("#KMDFSD").val("");
        $("#difference").val("");
        $("#reason").val("");
        $("#tons").val("");
        $("#workerCosts").val("");
        $("#costsSpecifications").val("");
        $("#payedCosts").val("");
        $("#settlementCosts").val("");
        $("#totalCosts").val("");
        $("#GPSInitialConsumption").val("");
        $("#GPSFinalConsumption").val("");
        $("#GPSConsumption").val("");
        $("#etimatedConsumption").val("");
        $("#FueledKM").val("");
        $("#fueledDieseEWLiters").val("");
        $("#dieselValue").val("");
        $("#realConsumption").val("");
        $("#adblueLiters").val("");
        $("#adblueValue").val("");
    },
    initDrive: function () {
        var url = new URL(window.location.href);
        var driveId = url.searchParams.get("driveId");
        if (driveId) {
            editDriveController.getDrive();
        } else {
            editDriveController.setupNewDriveInfo();
            setTimeout(function () { editDriveController.initControls(); }, 0);
        }
    },
    initControls: function () {
        $("#date").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });
    },
    cancelEdit: function () {
        if (this.confirmCancel()) {
            window.location = "/Drive/Index";
        }
    },
    getCorrectDateFormat: function (dateString) {
        var parts = dateString.split("/");
        var date = new Date(parts[2], parts[1] - 1, parts[0]);
        if (date) {
            return date.toISOString();
        }
        return "";
    },
    validateAndSaveDrive: function () {
        var driveInfo = {
            Id: this.driveId,
            Worker: $("#driver").val(),
            Truck: $("#truck").val(),
            Date: this.getCorrectDateFormat($("#date").val()),
            Vlaplan: $("#vlaplan").val(),
            Vlaref: $("#vlaref").val(),
            LoadingPlace: $("#loadingPlace").val(),
            Destination: $("#destination").val(),
            InitialGPSKM: $("#KMGpsInitiali").val(),
            FinalGPSKM: $("#KMGpsFinal").val(),
            DistanceGPS: $("#KMGps").val(),
            DistanceGpl: $("#KMGpl").val(),
            DistanceDFDS: $("#KMDFSD").val(),
            Difference: $("#difference").val(),
            Reason: $("#reason").val(),
            WeightInTons: $("#tons").val(),
            WorkerCosts: $("#workerCosts").val(),
            CostsSpecification: $("#costsSpecifications").val(),
            PayedCosts: $("#payedCosts").val(),
            SettlementCosts: $("#settlementCosts").val(),
            TotalPayments: $("#totalCosts").val(),
            GPSInitialConsumption: $("#GPSInitialConsumption").val(),
            GPSFinalConsumption: $("#GPSFinalConsumption").val(),
            GPSConsumption: $("#GPSConsumption").val(),
            EstimatedConsumption: $("#etimatedConsumption").val(),
            FueledKM: $("#FueledKM").val(),
            FueledDieseKMLiters: $("#fueledDieseEWLiters").val(),
            DieselValue: $("#dieselValue").val(),
            RealConsumption: $("#realConsumption").val(),
            AdblueLiters: $("#adblueLiters").val(),
            AdblueValue: $("#adblueValue").val(),
        };
        debugger;
        this.saveDrive(JSON.stringify(driveInfo));
    },
    confirmCancel: function () {
        var txt;
        var r = confirm(" Sunteti sigur ca vreti sa anulati aceasta operatie? \r\n Toate modificarile for fi pierdute!");
        if (r == true) {
            return true;
        } else {
            return false;
        }
    }
}
editDriveController.initDrive();
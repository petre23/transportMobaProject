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
                idDrive: this.getParameterByName("driveId", new URL(window.location.href))
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
        $("#KMGgl").val(drive.DistanceGgl);
        $("#KMDFSD").val(drive.DistanceDFDS);
        $("#difference").val(drive.Difference);
        $("#reason").val(drive.Reason);
        $("#tons").val(drive.WeightInTons);
        $("#workerCosts").val(drive.WorkerCosts);
        $("#workerCostsPounds").val(drive.WorkerCostsPounds);
        $("#costsSpecifications").val(drive.CostsSpecification);
        $("#payedCosts").val(drive.PayedCosts);
        $("#payedCostsPounds").val(drive.PayedCostsPounds);
        $("#settlementCosts").val(drive.SettlementCosts);
        $("#settlementCostsPounds").val(drive.SettlementCostsPounds);
        $("#totalCosts").val(drive.TotalPayments);
        $("#totalCostsPounds").val(drive.TotalPaymentsPounds);
        $("#trailer").val(drive.Trailer);
        $("#driveStatus").val(drive.DriveStatus);
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
        $("#KMGgl").val("");
        $("#KMDFSD").val("");
        $("#difference").val("");
        $("#reason").val("");
        $("#tons").val("");
        $("#workerCosts").val("");
        $("#workerCostsPounds").val("");
        $("#costsSpecifications").val("");
        $("#payedCosts").val("");
        $("#payedCostsPounds").val("");
        $("#settlementCosts").val("");
        $("#settlementCostsPounds").val("");
        $("#totalCosts").val("");
        $("#totalCostsPounds").val("");
        $("#trailer").val("");
        $("#driveStatus").val("");
    },
    initDrive: function () {
        var url = new URL(window.location.href);
        var driveId = editDriveController.getParameterByName("driveId", new URL(window.location.href));
        if (driveId) {
            editDriveController.getDrive();
        } else {
            editDriveController.setupNewDriveInfo();
            setTimeout(function () { editDriveController.initControls(); }, 0);
        }
    },
    initControls: function () {
        $("#date").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });

        $("#saveDrive").on("submit", function () {
            return false;
        });

        if ($("#difference").val() < 0)
        {
            $("#difference").addClass("red-border");
        }
    },
    cancelEdit: function () {
        if (this.confirmCancel()) {
            window.location = "/Drive/Index";
        }
    },
    getCorrectDateFormat: function (dateString) {
        if (dateString) {
            var parts = dateString.split("/");
            var date = new Date(parts[2], parts[1] - 1, parts[0]);
            if (date) {
                return date.toISOString();
            }
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
            InitialGPSKMString: $("#KMGpsInitiali").val(),
            FinalGPSKMString: $("#KMGpsFinal").val(),
            DistanceGPSString: $("#KMGps").val(),
            DistanceGglString: $("#KMGgl").val(),
            DistanceDFDSString: $("#KMDFSD").val(),
            DifferenceString: $("#difference").val(),
            Reason: $("#reason").val(),
            WeightInTonsString: $("#tons").val(),
            WorkerCostsString: $("#workerCosts").val(),
            WorkerCostsPoundsString: $("#workerCostsPounds").val(),
            CostsSpecification: $("#costsSpecifications").val(),
            PayedCostsPoundsString: $("#payedCostsPounds").val(),
            PayedCostsString: $("#payedCosts").val(),
            SettlementCostsString: $("#settlementCosts").val(),
            SettlementCostsPoundsString: $("#settlementCostsPounds").val(),
            TotalPaymentsString: $("#totalCosts").val(),
            TotalPaymentsPoundsString: $("#totalCostsPounds").val(),
            Trailer: $("#trailer").val(),
            DriveStatus: $("#driveStatus").val()
        };
        this.saveDrive(driveInfo);
    },
    setTruckForWorker: function () {
        var truckId = $("#" + $("#driver").val()).attr("truck-id");
        $("#truck").val(truckId);
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
    calculateDifference: function ()
    {
        var GPSkm = parseInt($("#KMGps").val());
        var DFSDkm = parseInt($("#KMDFSD").val());
        var difference = DFSDkm - GPSkm;

        $("#difference").val(difference);
        if (difference < 0)
        {
            $("#difference").addClass("red-border");
        }
        else
        {
            $("#difference").removeClass("red-border");
        }
    },
    calculateTotalCosts: function (isEuro)
    {
        var totalCosts = 0;
        var workerCosts = 0;
        var payedCosts = 0;
        var settlementCosts = 0;

        if (isEuro) {
            workerCosts = $("#workerCosts").val() !== null && $("#workerCosts").val() !== "" ? parseFloat($("#workerCosts").val()) : 0;
            payedCosts = $("#payedCosts").val() !== null && $("#payedCosts").val() !== "" ? parseFloat($("#payedCosts").val()) : 0;
            settlementCosts = $("#settlementCosts").val() !== null && $("#settlementCosts").val() !== "" ? parseFloat($("#settlementCosts").val()) : 0;

            totalCosts = workerCosts + payedCosts + settlementCosts;
            $("#totalCosts").val(totalCosts);
        }
        else {
            workerCosts = $("#workerCostsPounds").val() !== null && $("#workerCostsPounds").val() !== "" ? parseFloat($("#workerCostsPounds").val()) : 0;
            payedCosts = $("#payedCostsPounds").val() !== null && $("#payedCostsPounds").val() !== "" ? parseFloat($("#payedCostsPounds").val()) : 0;
            settlementCosts = $("#settlementCostsPounds").val() !== null && $("#settlementCostsPounds").val() !== "" ? parseFloat($("#settlementCostsPounds").val()) : 0;

            totalCosts = workerCosts + payedCosts + settlementCosts;
            $("#totalCostsPounds").val(totalCosts);
        }
    }
}
editDriveController.initDrive();
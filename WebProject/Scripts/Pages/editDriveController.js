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
                editDriveController.initControls(drive);
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                $("#errorDialog").dialog("open");
            }
        });
    },
    verifyIfVlarefExists: function () {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Drive/VerifyIfVlarefIsAlreadyUsed",
            data: {
                vlaref: $("#vlaref").val()
            },
            success: function (res) {
                var url = new URL(window.location.href);
                var driveId = editDriveController.getParameterByName("driveId", new URL(window.location.href));

                if (res.vlarefExists === false || driveId) {
                    editDriveController.validateAndSaveDrive();
                } else
                {
                    alert("Cursa cu acest Vlaref exista deja!");
                }
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
        $("#driveType").val(drive.DriveType);
        $("#estimatedConsumption").val(drive.EstimatedConsumption);
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
        $("#driveType").val("");
        $("#estimatedConsumption").val("");
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
    initControls: function (drive) {
        $("#date").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });

        $('#saveDrive').on('submit', function (e) {
            e.preventDefault();
        });

        if ($("#difference").val() < 0)
        {
            $("#difference").addClass("red-border");
        }
        var driveCosts = drive !== null && drive !== undefined ? drive.DriveCosts : [];
        this.initDriveCostsGrid(driveCosts);
    },
    initDriveCostsGrid: function (driveCosts) {
        $("#driveCosts").jsGrid({
            height: "200px",
            width: "100%",
            editing: true,
            sorting: true,
            paging: true,
            inserting: true,
            scroling:true,
            data: driveCosts,
            deleteConfirm: "Doriti sa stergeti aceasta inregistrare?",
            fields: [
                { name: "Id", type: "text", css: "hide", width: 150 },
                { name: "CostEuro", title: "Cost €", type: "decimal", width: 50 },
                { name: "CostPounds", title: "Cost £", type: "decimal", width: 50 },
                { type: "control" }
            ]
        });
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
            DriveStatus: $("#driveStatus").val(),
            DriveType: $("#driveType").val(),
            EstimatedConsumptionString: $("#estimatedConsumption").val(),
            DriveCosts: $("#driveCosts").jsGrid("option", "data")
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
    calculateEstimatedConsumption: function () {
        var GPSkm = parseInt($("#KMGps").val());
        var tonaj = parseInt($("#tons").val());

        if (GPSkm && tonaj)
        {
            var estimatedConsumption = (parseInt(GPSkm) * (25 + 0.5 * parseInt(tonaj)) / 100).toFixed(2);
            $("#estimatedConsumption").val(estimatedConsumption.toFixed(2));
        }
    },
    calculateKMGPS: function () {
        var KMInitiali = parseInt($("#KMGpsInitiali").val());
        var KMFinali = parseInt($("#KMGpsFinal").val());
        if (KMInitiali && KMFinali) {
            var difference = parseInt(KMFinali) - parseInt(KMInitiali);
            $("#KMGps").val(difference.toFixed(2));
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

    DecimalField: function (config) {
        jsGrid.NumberField.call(this, config);
    },
    config: function () {
        editDriveController.DecimalField.prototype = new jsGrid.NumberField({

            itemTemplate: function (value) {
                return value !== null && value !== undefined ? value.toFixed(2) : 0;
            },

            filterValue: function () {
                return parseFloat(this.filterControl.val() || 0);
            },

            insertValue: function () {
                return parseFloat(this.insertControl.val() || 0);
            },

            editValue: function () {
                return parseFloat(this.editControl.val() || 0);
            }

        });

        jsGrid.fields.decimal = editDriveController.DecimalField;
    }
}
editDriveController.initDrive();
editDriveController.config();
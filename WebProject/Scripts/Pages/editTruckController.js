﻿var editTruckController = {
    truckId : null,
    saveTruck: function (truck) {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Truck/SaveTruck",
            data: truck,
            success: function (res) {
                window.location = "/Truck/Index";
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                setTimeout(function () { $("#errorDialog").dialog("open"); }, 1000);
            }
        });
    },
    getTruck: function () {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Truck/GetTruck",
            data: {
                idTruck: this.getIdFromUrl()
            },
            success: function (res) {
                editTruckController.truckId = res.truck.Id;
                var truck = res.truck;
                editTruckController.setTruckDetails(truck);
                editTruckController.initControls();
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                $("#errorDialog").dialog("open");
            }
        });
    },
    setTruckDetails: function (truck) {
        $("#registrationNumber").val(truck.RegistrationNumber);
        $("#brands").val(truck.BrandDropDownValue);
        $("#registrationYear").val(truck.ManufacturingYearString);
        $("#ITPExpirationDate").val(truck.ITPExpirationDateString);
        $("#insuranceExpirationDate").val(truck.InsuranceExpirationDateString);
        $("#tachographExpirationDate").val(truck.TachographExpirationDateString);
        $("#vignetteExpirationDate").val(truck.VignetteExpirationDateString);
        $("#conformCopyExpirationDate").val(truck.ConformCopyExpirationDateString);
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
        var truckId = url.searchParams.get("truckId");
        return truckId;
    },
    setupNewTruckInfo: function () {
        this.truckId = null;
        $("#registrationNumber").val("");
        $("#brands").val("");
        $("#registrationYear").val("");
        $("#ITPExpirationDate").val("");
        $("#insuranceExpirationDate").val("");
        $("#tachographExpirationDate").val("");
        $("#vignetteExpirationDate").val("");
        $("#conformCopyExpirationDate").val("");
    },
    initTruck: function ()
    {
        var url = new URL(window.location.href);
        var truckId = url.searchParams.get("truckId");
        if (truckId) {
            editTruckController.getTruck();
        } else {
            editTruckController.setupNewTruckInfo();
            setTimeout(function () { editTruckController.initControls(); }, 0);
        }
    },
    initControls: function () {
        $("#ITPExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#insuranceExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#tachographExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#vignetteExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#conformCopyExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
    },
    cancelEdit: function () {
        if (this.confirmCancel()) {
            window.location = "/Truck/Index";
        }
    },
    validateAndSaveTruck: function () {
        var truckInfo = {
            Id: this.truckId,
            RegistrationNumber : $("#registrationNumber").val(),
            BrandDropDownValue : $("#brands").val(),
            ManufacturingYear: new Date($("#registrationYear").val()).toISOString(),
            ITPExpirationDate: this.getCorrectDateFormat($("#ITPExpirationDate").val()),
            InsuranceExpirationDate: this.getCorrectDateFormat($("#insuranceExpirationDate").val()),
            TachographExpirationDate: this.getCorrectDateFormat($("#tachographExpirationDate").val()),
            VignetteExpirationDate: this.getCorrectDateFormat($("#vignetteExpirationDate").val()),
            ConformCopyExpirationDate: this.getCorrectDateFormat($("#conformCopyExpirationDate").val())
        };
        this.saveTruck(truckInfo);
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
};
editTruckController.initTruck();
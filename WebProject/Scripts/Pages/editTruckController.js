var editTruckController = {
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
                idTruck: this.getParameterByName("truckId", new URL(window.location.href)),
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
        $("#vignetteExpirationDateUK").val(truck.VignetteExpirationDateUKString);
        $("#vignetteExpirationDateNL").val(truck.VignetteExpirationDateNLString);
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
    setupNewTruckInfo: function () {
        this.truckId = null;
        $("#registrationNumber").val("");
        $("#brands").val("");
        $("#registrationYear").val("");
        $("#ITPExpirationDate").val("");
        $("#insuranceExpirationDate").val("");
        $("#tachographExpirationDate").val("");
        $("#vignetteExpirationDateUK").val("");
        $("#vignetteExpirationDateNL").val("");
        $("#conformCopyExpirationDate").val("");
    },
    initTruck: function ()
    {
        var url = new URL(window.location.href);
        var truckId = editTruckController.getParameterByName("truckId", url);
        if (truckId) {
            editTruckController.getTruck();
        } else {
            editTruckController.setupNewTruckInfo();
            setTimeout(function () { editTruckController.initControls(); }, 0);
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
        $("#registrationYear").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#ITPExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#insuranceExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#tachographExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#vignetteExpirationDateUK").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#vignetteExpirationDateNL").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#conformCopyExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });

        $("#saveTruck").on("submit", function () {
            return false;
        });
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
            ManufacturingYear: this.getCorrectDateFormat($("#registrationYear").val()),
            ITPExpirationDate: this.getCorrectDateFormat($("#ITPExpirationDate").val()),
            InsuranceExpirationDate: this.getCorrectDateFormat($("#insuranceExpirationDate").val()),
            TachographExpirationDate: this.getCorrectDateFormat($("#tachographExpirationDate").val()),
            VignetteExpirationDateUK: this.getCorrectDateFormat($("#vignetteExpirationDateUK").val()),
            VignetteExpirationDateNL: this.getCorrectDateFormat($("#vignetteExpirationDateNL").val()),
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
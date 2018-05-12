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
                $("#errorDialog").dialog("open");
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
        $("#ITPExpirationDate").val(this.getValidDate(truck.ITPExpirationDateString));
        $("#insuranceExpirationDate").val(this.getValidDate(truck.InsuranceExpirationDateString));
        $("#tachographExpirationDate").val(this.getValidDate(truck.TachographExpirationDateString));
        $("#vignetteExpirationDate").val(this.getValidDate(truck.VignetteExpirationDateString));
        $("#conformCopyExpirationDate").val(this.getValidDate(truck.ConformCopyExpirationDateString));
    },
    getValidDate: function (dateString) {
        var parts = dateString.split("/");
        var date = new Date(parts[2], parts[1] - 1, parts[0]);
        if (date) {
            return date.toISOString().substring(0, 10);
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
        }
    },
    cancelEdit: function () {
        window.location = "/Truck/Index";
    },
    validateAndSaveTruck: function () {
        var truckInfo = {
            Id: this.truckId,
            RegistrationNumber : $("#registrationNumber").val(),
            BrandDropDownValue : $("#brands").val(),
            ManufacturingYear: new Date($("#registrationYear").val()).toISOString(),
            ITPExpirationDate: new Date($("#ITPExpirationDate").val()).toISOString(),
            InsuranceExpirationDate: new Date($("#insuranceExpirationDate").val()).toISOString(),
            TachographExpirationDate: new Date($("#tachographExpirationDate").val()).toISOString(),
            VignetteExpirationDate: new Date($("#vignetteExpirationDate").val()).toISOString(),
            ConformCopyExpirationDate: new Date($("#conformCopyExpirationDate").val()).toISOString()
        };

        this.saveTruck(truckInfo);
    }
};
editTruckController.initTruck();
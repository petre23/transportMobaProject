var editTruckController = {
    saveTruck: function () {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Truck/SaveTruck",
            success: function (res) {

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
        $("#truckRegistrationNumber").val(truck.RegistrationNumber);
        $("#brand").val(truck.BrandName);
        $("#manufacteringYear").val(truck.ManufacturingYearString);
    },
    getIdFromUrl: function () {
        var url = new URL(window.location.href);
        var truckId = url.searchParams.get("truckId");
        return truckId;
    }
};
editTruckController.getTruck();
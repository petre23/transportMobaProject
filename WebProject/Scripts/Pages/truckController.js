var truckController =
    {
        getTrucks: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Truck/GetTrucks",
                success: function (res) {
                    alert(res.test);
                }
            });
        },
        saveTruck: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Truck/SaveTruck",
                success: function (res) {

                }
            });
        },
        getTruck: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Truck/GetTruck",
                success: function (res) {

                }
            });
        }
    };
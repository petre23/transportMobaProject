var driveController =
    {
        getDrives: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Drive/GetDrives",
                success: function (res) {
                    alert(res.test);
                }
            });
        },
        saveDrive: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Drive/SaveDrive",
                success: function (res) {

                }
            });
        },
        getDrive: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Drive/GetDrive",
                success: function (res) {

                }
            });
        }
    };
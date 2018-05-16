var editDriveController = {
    driveId: null,
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
}
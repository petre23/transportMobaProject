var workerController =
    {
        getWorkers: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Worker/GetWorkers",
                success: function (res) {
                    alert(res.test);
                }
            });
        },
        saveWorker: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Worker/SaveWorker",
                success: function (res) {

                }
            });
        },
        getWorker: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Worker/GetWorker",
                success: function (res) {

                }
            });
        }
    };
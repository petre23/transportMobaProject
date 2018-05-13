var workerController =
    {
        getWorkers: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Worker/GetWorkers",
                success: function (res) {
                    workerController.initGrid(res.workers);
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
        },
        initGrid: function (workers) {
            $("#editButton").prop('disabled', true);
            $("#deleteButton").prop('disabled', true);

            $("#workerGrid").jsGrid({
                width: "100%",
                height: "80vh",

                inserting: false,
                editing: false,
                sorting: true,
                paging: false,
                rowClick: function (args) {
                    $("#workerGrid tr").removeClass("selected-row")
                    $selectedRow = $(args.event.target).closest("tr");
                    $selectedRow.addClass("selected-row");

                    truckController.selectedTruck = args.item.Id;

                    $("#editButton").prop('disabled', false);
                    $("#deleteButton").prop('disabled', false);
                },
                data: workers,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css: "hide" },
                    { name: "RegistrationNumber", title: 'Nume', type: "text", width: 80 },
                    { name: "BrandName", title: 'Prenume', type: "text", width: 80 },
                    { name: "ManufacturingYearString", title: 'Data nasterii', type: "text", width: 60 },
                    { name: "ITPExpirationDateString", title: 'Firma', type: "text", width: 80 },
                    { name: "VignetteExpirationDateUKString", title: 'Camion', type: "text", width: 100 },
                    { name: "VignetteExpirationDateNLString", title: 'Data angajarii', type: "text", width: 100 },
                    { name: "InsuranceExpirationDateString", title: 'Act identitate', type: "text", width: 100 },
                    { name: "TachographExpirationDateString", title: 'Data expirarii', type: "text", width: 100 },
                    { name: "ConformCopyExpirationDateString", title: 'Permis', type: "text", width: 100 },
                    { name: "InsuranceExpirationDateString", title: 'Card tahograf', type: "text", width: 100 },
                    { name: "TachographExpirationDateString", title: 'Atestat', type: "text", width: 100 },
                    { name: "ConformCopyExpirationDateString", title: 'Analize medicale', type: "text", width: 100 },
                ]
            });
        },
    };


workerController.getWorkers();

var workerController =
    {
        selectedWorker: "",
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

                    workerController.selectedWorker = args.item.Id;

                    $("#editButton").prop('disabled', false);
                    $("#deleteButton").prop('disabled', false);
                },
                data: workers,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css: "hide" },
                    { name: "WorkerName", title: 'Nume', type: "text", width: 80 },
                    { name: "BirthDayString", title: 'Data nasterii', type: "text", width: 70 },
                    { name: "EmployerName", title: 'Firma', type: "text", width: 180 },
                    { name: "TruckRegistrationNumber", title: 'Camion', type: "text", width: 80 },
                    { name: "EmploymentDateString", title: 'Data angajarii', type: "text", width: 90 },
                    { name: "IdentityDocument", title: 'Act identitate', type: "text", width: 90 },
                    { name: "DrivingLicenseExpirationDateString", title: 'Data expirare permis', type: "text", width: 100 },
                    { name: "TachographCardExpirationDateString", title: 'Data expirare card tahograf', type: "text", width: 100 },
                    { name: "CertificateExpirationDateString", title: 'Data expirare atestat', type: "text", width: 100 },
                    { name: "MedicalTestsExpirationDateString", title: 'Data expirare analize medicale', type: "text", width: 100 }
                ]
            });
        },
        addNewWorker: function () {
            window.location = "/Worker/EditWorker";
        },
        editWorker: function () {
            if (workerController.selectedWorker) {
                window.location = "/Worker/EditWorker?workerId=" + workerController.selectedWorker;
            }
        },
        deleteWorker: function () {
            if (this.confirmDeleteWorker()) {
                $.ajax({
                    type: 'post',
                    dataType: 'json',
                    url: "/Worker/DeleteWorker",
                    data: { workerId: workerController.selectedWorker },
                    success: function (res) {
                        workerController.getWorkers();
                    },
                    error: function (jqXHR, textStatus, exception, errorThrown) {
                        $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                        $("#errorDialog").dialog("open");
                    }
                });
            }
        },
        confirmDeleteWorker: function () {
            var txt;
            var r = confirm("Sunteti sigur ca vreti sa stergeti acest camion?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }
    };


workerController.getWorkers();

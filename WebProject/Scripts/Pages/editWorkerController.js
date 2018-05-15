var editWorkerController = {
    workerId: null,
    saveWorker: function (worker) {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Worker/SaveWorker",
            data: worker,
            success: function (res) {
                window.location = "/Worker/Index";
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                setTimeout(function () { $("#errorDialog").dialog("open"); }, 1000);
            }
        });
    },
    getWorker: function () {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Worker/GetWorker",
            data: {
                idWorker: this.getIdFromUrl()
            },
            success: function (res) {
                editWorkerController.workerId = res.worker.Id;
                var worker = res.worker;
                editWorkerController.setWorkerDetails(worker);
                editWorkerController.initControls();
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                $("#errorDialog").dialog("open");
            }
        });
    },
    setWorkerDetails: function (worker) {
        $("#firstName").val(worker.FirstName);
        $("#surname").val(worker.Surname);
        $("#employer").val(worker.EmployerDropDownValue);
        $("#truck").val(worker.Truck);
        $("#cnp").val(worker.CNP);
        $("#identityDocument").val(worker.IdentityDocument);
        $("#birthDay").val(worker.BirthDayString);
        $("#employmentDate").val(worker.EmploymentDateString);
        $("#drivingLicenseExpirationDate").val(worker.DrivingLicenseExpirationDateString);
        $("#certificateExpirationDate").val(worker.CertificateExpirationDateString);
        $("#tachographCardExpirationDate").val(worker.TachographCardExpirationDateString);
        $("#medicalTestsExpirationDate").val(worker.MedicalTestsExpirationDateString);
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
        var workerId = url.searchParams.get("workerId");
        return workerId;
    },
    setupNewWorkerInfo: function () {
        this.workerId = null;
        $("#firstName").val("");
        $("#surname").val("");
        $("#employer").val("");
        $("#truck").val("");
        $("#cnp").val("");
        $("#identityDocument").val("");
        $("#birthDay").val("");
        $("#employmentDate").val("");
        $("#drivingLicenseExpirationDate").val("");
        $("#certificateExpirationDate").val("");
        $("#tachographCardExpirationDate").val("");
        $("#medicalTestsExpirationDate").val("");
    },
    initWorker: function () {
        var url = new URL(window.location.href);
        var workerId = url.searchParams.get("workerId");
        if (workerId) {
            editWorkerController.getWorker();
        } else {
            editWorkerController.setupNewWorkerInfo();
            setTimeout(function () { editWorkerController.initControls(); }, 0);
        }
    },
    initControls: function () {
        $("#birthDay").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#employmentDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#drivingLicenseExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#certificateExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#tachographCardExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
        $("#medicalTestsExpirationDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: false, changeYear: true });
    },
    cancelEditWorker: function () {
        if (this.confirmCancelWorker()) {
            window.location = "/Worker/Index";
        }
    },
    validateAndSaveWorker: function () {
        var workerInfo = {
            Id: this.workerId,
            FirstName: $("#firstName").val(),
            Surname: $("#surname").val(),
            EmployerDropDownValue: $("#employer").val(),
            Truck: $("#truck").val(),
            CNP: $("#cnp").val(),
            IdentityDocument: $("#identityDocument").val(),
            BirthDay: this.getCorrectDateFormat($("#birthDay").val()),
            EmploymentDate: this.getCorrectDateFormat($("#employmentDate").val()),
            DrivingLicenseExpirationDate: this.getCorrectDateFormat($("#drivingLicenseExpirationDate").val()),
            CertificateExpirationDate: this.getCorrectDateFormat($("#certificateExpirationDate").val()),
            TachographCardExpirationDate: this.getCorrectDateFormat($("#tachographCardExpirationDate").val()),
            MedicalTestsExpirationDate: this.getCorrectDateFormat($("#medicalTestsExpirationDate").val())
        };
        this.saveWorker(workerInfo);
    },
    confirmCancelWorker: function () {
        var txt;
        var r = confirm(" Sunteti sigur ca vreti sa anulati aceasta operatie? \r\n Toate modificarile for fi pierdute!");
        if (r == true) {
            return true;
        } else {
            return false;
        }
    }
};
editWorkerController.initWorker();
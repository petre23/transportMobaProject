var driveController =
    {
        selectedDrive: "",
        page: 1,
        pageSize: 30,
        initGrid: function (drives) {
            $("#editDriveButton").prop('disabled', true);
            $("#deleteDriveButton").prop('disabled', true);

            $("#driveGrid").jsGrid({
                width: "100%",
                height: "80vh",

                inserting: false,
                editing: false,
                sorting: true,
                paging: true,
                autoload: true,
                pageLoading: true,
                pageSize: driveController.pageSize,
                pageIndex: driveController.page,
                rowClick: function (args) {
                    $("#driveGrid tr").removeClass("selected-row")
                    $selectedRow = $(args.event.target).closest("tr");
                    $selectedRow.addClass("selected-row");

                    driveController.selectedDrive = args.item.Id;

                    $("#editDriveButton").prop('disabled', false);
                    $("#deleteDriveButton").prop('disabled', false);
                },
                controller: {
                    loadData: function (filter) {
                        var deferred = $.Deferred();
                        $.ajax({
                            type: "post",
                            url: "/Drive/GetDrives",
                            data: filter,
                            dataType: "json",
                            success: function (res) {
                                var dataForDrives = {
                                    data: res.drives,
                                    itemsCount: res.drives && res.drives.length > 0 ? res.drives[0].TotalRows : 0
                                }

                                deferred.resolve(dataForDrives);
                            }
                        });
                        return deferred.promise();
                    }
                },
                fields: [
                    { name: "Id", title: 'Id', type: "text", css: "hide" },
                    { name: "WorkerName", title: 'Sofer', type: "text", width: 80 },
                    { name: "TruckRegistrationNumber", title: 'Camion', type: "text", width: 80 },
                    { name: "DateString", title: 'Data', type: "text", width: 60 },
                    { name: "Vlaplan", title: 'Vlaplan', type: "text", width: 80 },
                    { name: "Vlaref", title: 'Vlaref', type: "text", width: 100 },
                    { name: "LoadingPlace", title: 'Locatie incarcare', type: "text", width: 100 },
                    { name: "Destination", title: 'Destinatie', type: "text", width: 100 },
                    { name: "WeightInTons", title: 'Tonaj', type: "text", width: 100 },
                    { name: "LastUpdateByUserName", title: 'Ultima modificare facuta de', type: "text", width: 150 },
                ]
            });
        },
        addNewDrive: function () {
            window.location = "/Drive/EditDrive";
        },
        editDrive: function () {
            if (driveController.selectedDrive) {
                window.location = "/Drive/EditDrive?driveId=" + driveController.selectedDrive;
            }
        },
        deleteDrive: function () {
            if (this.confirmDeleteDrive()) {
                $.ajax({
                    type: 'post',
                    dataType: 'json',
                    url: "/Drive/DeleteDrive",
                    data: { driveId: driveController.selectedDrive },
                    success: function (res) {
                        driveController.initGrid();
                    },
                    error: function (jqXHR, textStatus, exception, errorThrown) {
                        $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                        $("#errorDialog").dialog("open");
                    }
                });
            }
        },
        confirmDeleteDrive: function () {
            var txt;
            var r = confirm("Sunteti sigur ca vreti sa stergeti acest camion?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }
    };
driveController.initGrid();
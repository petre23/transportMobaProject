﻿var driveController =
    {
        selectedDrive: "",
        page: 1,
        pageSize: 50,
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
                        filter.searchText = $("#searchText").val();
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
                    { name: "Trailer", title: 'Remorca', type: "text", width: 90 },
                    { name: "DriveStatusName", title: 'Status', type: "text", width: 90 },
                    { name: "DateString", title: 'Data', type: "text", width: 85 },
                    { name: "Vlaplan", title: 'Vlaplan', type: "text", width: 80 },
                    { name: "Vlaref", title: 'Vlaref', type: "text", width: 80},
                    { name: "LoadingPlace", title: 'Locatie incarcare', type: "text", width: 170 },
                    { name: "Destination", title: 'Destinatie', type: "text", width: 170 },
                    { name: "WeightInTons", title: 'Tonaj', type: "text", width: 50 },
                    { name: "KMGpsInitiali", title: 'KM Gps Initiali', type: "text", width: 50 },
                    { name: "KMGpsFinal", title: 'KM Gps Finali', type: "text", width: 50 },
                    { name: "KMGps", title: 'KM Gps', type: "text", width: 50 },
                    { name: "KMGgl", title: 'KM Ggl', type: "text", width: 50 },
                    { name: "KMDFSD", title: 'KMDFSD', type: "text", width: 80 },
                    { name: "EstimatedConsumption", title: 'Consum estimat', type: "text", width: 80 },
                    { name: "Difference", title: 'Diferenta', type: "text", width: 80 },
                    { name: "Reason", title: 'Motiv', type: "text", width: 100 },
                    { name: "WorkerCosts", title: 'Cheltuieli Sofer €', type: "text", width: 90 },
                    { name: "WorkerCostsPounds", title: 'Cheltuieli Sofer £', type: "text", width: 90 },
                    { name: "CostsSpecification", title: 'Specificatie cheltuieli', type: "text", width: 90 },
                    { name: "PayedCosts", title: 'Cheltuieli platite €', type: "text", width: 90 },
                    { name: "PayedCostsPounds", title: 'Cheltuieli platite £', type: "text", width: 90 },
                    { name: "SettlementCosts", title: 'Cheltuieli de decontat €', type: "text", width: 90 },
                    { name: "SettlementCostsPounds", title: 'Cheltuieli de decontat £', type: "text", width: 90 },
                    { name: "TotalPayments", title: 'Total Plati €', type: "text", width: 90 }, 
                    { name: "TotalPaymentsPounds", title: 'Total Plati £', type: "text", width: 90 }, 
                    { name: "LastUpdateByUserName", title: 'Modificat de', type: "text", width: 100 }
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
        },
        initExportControls: function ()
        {
            $("#startDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });
            $("#endDate").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true });
        },
        initDrivePage: function ()
        {
            this.initGrid();
            this.initExportControls();
        }
    };
driveController.initDrivePage();
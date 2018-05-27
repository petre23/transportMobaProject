var userController =
    {
        selectedUser: "",
        getUser: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/User/GetUser",
                success: function (res) {
                    userController.initGrid(res.user);
                }
            });
        },
        initGrid: function (user) {
            $("#editButton").prop('disabled', true);
            $("#deleteButton").prop('disabled', true);

            $("#userGrid").jsGrid({
                width: "100%",
                height: "80vh",

                inserting: false,
                editing: false,
                sorting: true,
                paging: false,
                rowClick: function (args) {
                    $("#userGrid tr").removeClass("selected-row")
                    $selectedRow = $(args.event.target).closest("tr");
                    $selectedRow.addClass("selected-row");

                    userController.selectedWorker = args.item.Id;

                    $("#editButton").prop('disabled', false);
                    $("#deleteButton").prop('disabled', false);
                },
                data: user,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css: "hide" },
                    { name: "UserName", title: 'Nume', type: "text", width:140 },
                    { name: "Prenume", title: 'Prenume', type: "text", width: 140 },
                    { name: "Email", title: 'Email', type: "text", width: 140 }
                ]
            });
        },
        addNewUser: function () {
            window.location = "/User/EditUser";
        },
        editUser: function () {
            if (workerController.selectedWorker) {
                window.location = "/User/EditUser?userId=" + userController.selectedUser;
            }
        },
        deleteUser: function () {
            if (this.confirmDeleteUser()) {
                $.ajax({
                    type: 'post',
                    dataType: 'json',
                    url: "/User/DeleteUser",
                    data: { userId: userController.selectedUser },
                    success: function (res) {
                        userController.getUser();
                    },
                    error: function (jqXHR, textStatus, exception, errorThrown) {
                        $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                        $("#errorDialog").dialog("open");
                    }
                });
            }
        },
        confirmDeleteUser: function () {
            var txt;
            var r = confirm("Sunteti sigur ca vreti sa stergeti acest user?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }
    };


userController.getUser();

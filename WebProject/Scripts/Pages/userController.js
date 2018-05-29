var userController =
    {
        selectedUser: "",
        getUsers: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Users/GetUsers",
                success: function (res) {
                    userController.initGrid(res.users);
                }
            });
        },
        initGrid: function (users) {
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
                    $("#editButton").prop('disabled', true);
                    $("#deleteButton").prop('disabled', true);

                    $("#userGrid tr").removeClass("selected-row")
                    $selectedRow = $(args.event.target).closest("tr");
                    $selectedRow.addClass("selected-row");

                    userController.selectedUser = args.item.Id;

                    $("#editButton").prop('disabled', false);
                    if (!args.item.HasAdminRole) {
                        $("#deleteButton").prop('disabled', false);
                    }
                },
                data: users,
                fields: [
                    { name: "Id", title: 'Id', type: "text", css: "hide" },
                    { name: "Username", title: 'Email', type: "text", width:140 },
                    { name: "FullName", title: 'Nume', type: "text", width: 140 },
                    { name: "HasAdminRole", title: 'HasAdminRole', align: "center", type: "checkbox", width: 140 }
                ]
            });
        },
        addNewUser: function () {
            window.location = "/Users/EditUser";
        },
        editUser: function () {
            if (userController.selectedUser) {
                window.location = "/Users/EditUser?userId=" + userController.selectedUser;
            }
        },
        deleteUser: function () {
            if (this.confirmDeleteUser()) {
                $.ajax({
                    type: 'post',
                    dataType: 'json',
                    url: "/Users/DeleteUser",
                    data: { userId: userController.selectedUser },
                    success: function (res) {
                        userController.getUsers();
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


userController.getUsers();

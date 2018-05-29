var editUserController = {
    userId: null,
    saveUser: function (user) {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Users/SaveUser",
            data: user,
            success: function (res) {
                window.location = "/Users/Index";
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                setTimeout(function () { $("#errorDialog").dialog("open"); }, 1000);
            }
        });
    },
    getUser: function () {
        $.ajax({
            type: 'post',
            dataType: 'json',
            url: "/Users/GetUser",
            data: {
                userId: this.getParameterByName("userId", new URL(window.location.href)),
            },
            success: function (res) {
                editUserController.userId = res.user.Id;
                var user = res.user;
                editUserController.setUserDetails(user);
                editUserController.initControls();
            },
            error: function (jqXHR, textStatus, exception, errorThrown) {
                $("#errorDialog").html(JSON.parse(jqXHR.responseText).error);
                $("#errorDialog").dialog("open");
            }
        });
    },
    setUserDetails: function (user) {
        $("#username").val(user.Username);
        $("#firstName").val(user.FirstName);
        $("#surName").val(user.SurName);
        $("#password").val(user.Password);
        $("#confirmPassword").val(user.Password);
        $("#hasAdminRole").prop('checked',user.HasAdminRole);
    },
    setupNewUserInfo: function () {
        this.userId = null;
        $("#username").val("");
        $("#firstName").val("");
        $("#surName").val("");
        $("#password").val("");
        $("#hasAdminRole").val("");
    },
    initUser: function () {
        var url = new URL(window.location.href);
        var userId = editUserController.getParameterByName("userId", url);
        if (userId) {
            editUserController.getUser();
        } else {
            editUserController.setupNewUserInfo();
            setTimeout(function () { editUserController.initControls(); }, 0);
        }
    },
    getParameterByName: function (name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    },
    initControls: function () {
        $("#saveUser").on("submit", function () {
            return false;
        });
    },
    cancelEdit: function () {
        if (this.confirmCancel()) {
            window.location = "/Users/Index";
        }
    },
    validateAndSaveUser: function () {
        if ($("#password").val() != $("#confirmPassword").val())
        {
            alert("Parola si Confirma parola trebuie sa fie identice!");
        }
        else
        {
            var userInfo = {
                Id: this.userId,
                Username: $("#username").val(),
                FirstName: $("#firstName").val(),
                SurName: $("#surName").val(),
                Password: $("#password").val(),
                HasAdminRole: $("#hasAdminRole").prop('checked')
            };
            this.saveUser(userInfo);
        }
    },
    confirmCancel: function () {
        var txt;
        var r = confirm(" Sunteti sigur ca vreti sa anulati aceasta operatie? \r\n Toate modificarile for fi pierdute!");
        if (r == true) {
            return true;
        } else {
            return false;
        }
    }
};
editUserController.initUser();
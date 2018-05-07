var loginController =
    {
        login: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                data: {
                    Username: $("#email").val(),
                    Password: $("#password").val()
                },
                url: "/Login/Login",
                success: function (res) {
                    if (res.userName && res.userName != '') {
                        window.location = '/Truck/Index';
                    } else
                    {
                        alert('Email sau parola invalide');
                    }
                }
            });
        },
        validateLogin: function ()
        {
            if (loginForm.checkValidity())
            {
                this.login();
            }
        },
        logout: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Login/Logout",
                success: function (res) {
                   
                }
            });   
        }
    };
var loginController =
    {
        login: function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: "/Login/Login",
                success: function (res) {
                    alert(res.test);
                }
            });   
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
// LOGIN JS

$(document).ready(function () {
    var webAPIUrlBase = "http://localhost:19422/api/";

    $('#login-submit').on('click', function () {

        let loginForm = $('#login-form');
        let email = $(loginForm).find('#email').val();
        let password = $(loginForm).find('#password').val();

        let userDTO = {
            'Email': email,
            'Password': password,
            'DisplayName': '',
            'Token"': '',
            'Biography': ''
        }

        let url = webAPIUrlBase + 'users/login';
        let stringifiedData = JSON.stringify(userDTO);

        $.ajax({
            url: url,
            data: stringifiedData,
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function (data) {
                console.log('logged in');
                console.log(data);
                writeTokenToStorage(data.Token);
            },
            error: function (xhr, error) {
                console.log('xhr', xhr);
                console.log('error --- ', error);
            }
        });

    })

    function loginWithToken() {
        let userDTO = {
            'Email': '',
            'Password': '',
            'DisplayName': '',
            'Token"': getTokenFromLocalStorage(),
            'Biography': ''
        }
        console.log(userDTO);

        let url = webAPIUrlBase + 'users/token-login';
        let stringifiedData = JSON.stringify(userDTO);
        console.log(userDTO);
        $.ajax({
            url: url,
            data: stringifiedData,
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            beforeSend: function (xhr) {   //Include the bearer token in header
                xhr.setRequestHeader("Authorization", 'Bearer ' + getTokenFromLocalStorage());
            },
            success: function (data) {
                console.log(data);
            },
            error: function (xhr, error) {
                console.log('xhr', xhr);
                console.log('error --- ', error);
            }
        });
    }

    function writeTokenToStorage(token) {
        localStorage.token = token;
        Cookies.set('token', token);
    }

    function getTokenFromLocalStorage() {
        return localStorage.getItem('token');
    }

});

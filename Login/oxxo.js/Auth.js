$(document).ready(function () {

    $("#btnAuth").click(function () {

        user = $("#username").val();
        pass = $("#password").val();
        if (user == null || user == '') {
            alert("Ingresa tu Usuario por favor.");
        }
        if (pass == null || pass == '') {
            alert("Ingresa tu contraseña por favor.");
        }
        if (user != null && user != '' && pass != null && pass != '') {
            console.log("Declaramos los valores de Usuario " + user + " y contraseña " + pass);
            submit();
            //window.location.href = 'admin.html';
        }
    });


});

function submit() {

    authInfo = user + ":" + pass;
    authInfo = window.btoa(authInfo);

    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "http://localhost:52766/api/auth/token",
        "method": "POST",
        "headers": {
            "Authorization": "Basic " + authInfo,
            "Cache-Control": "no-cache"
        }
    }

    /*
    
    var settings = {
        data: { "user": user, "pass": pass },
        dataType: "json",
        "async": true,
        "crossDomain": true,
        "url": "http://localhost:52766/api/auth/token",
        "method": "POST"
    }
    */

    $.ajax(settings).done(function (response) {
        console.log(response);
        $.session.set('user', user);
        $.session.set('token', response);
        window.location.href = 'admin.html';
    });

}
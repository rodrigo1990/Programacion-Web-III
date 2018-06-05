function validarFormularioDeRegistroUsuario() {
    
    var nombre = $("#Nombre").val();
    var apellido = $("#Apellido").val();
    var email = $("#Email").val();
    var pass = $("#Contrasenia").val();
    var confirmPass = $("#confirm-pass").val();

    var emailValido = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var letrasNumerosMayusculaMinuscula = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]+$/;


    if (nombre.length > 50 || nombre.length < 1) {
        if ($("#nombre-error").hasClass("none-opacity")) {
            $("#nombre-error").removeClass("none-opacity");
            $("#nombre-error").addClass("full-opacity");

            setTimeout(function () {
                $("#nombre-error").removeClass("full-opacity");
                $("#nombre-error").addClass("none-opacity");
            }, 5000);

        } else {
            $("#nombre-error").addClass("full-opacity");

            setTimeout(function () {
                $("#nombre-error").removeClass("full-opacity");
                $("#nombre-error").addClass("none-opacity");
            }, 5000);
        }
    } else if (apellido.length > 50 || apellido.length < 1) {
        if ($("#apellido-error").hasClass("none-opacity")) {
            $("#apellido-error").removeClass("none-opacity");
            $("#apellido-error").addClass("full-opacity");

            setTimeout(function () {
                $("#apellido-error").removeClass("full-opacity");
                $("#apellido-error").addClass("none-opacity");
            }, 5000);
        } else {
            $("#apellido-error").addClass("full-opacity");

            setTimeout(function () {
                $("#apellido-error").removeClass("full-opacity");
                $("#apellido-error").addClass("none-opacity");
            }, 5000);
        }
    
    } else if (email.length == 0 || email.search(emailValido)) {
        if ($("#email-error").hasClass("none-opacity")) {
            $("#email-error").removeClass("none-opacity");
            $("#email-error").addClass("full-opacity");

            setTimeout(function () {
                $("#email-error").removeClass("full-opacity");
                $("#email-error").addClass("none-opacity");
            }, 5000);
        } else {
            $("#email-error").addClass("full-opacity");

            setTimeout(function () {
                $("#email-error").removeClass("full-opacity");
                $("#email-error").addClass("none-opacity");
            }, 5000);

        }

    
    } else if (pass.length == 0 || pass.search(letrasNumerosMayusculaMinuscula)) {
        if ($("#pass-error").hasClass("none-opacity")) {
            $("#pass-error").removeClass("none-opacity");
            $("#pass-error").addClass("full-opacity");

            setTimeout(function () {
                $("#pass-error").removeClass("full-opacity");
                $("#pass-error").addClass("none-opacity");
            }, 5000);
        } else {
            $("#pass-error").addClass("full-opacity");

            setTimeout(function () {
                $("#pass-error").removeClass("full-opacity");
                $("#pass-error").addClass("none-opacity");
            }, 5000);
        }

    
    } else if (confirmPass != pass)
    {
        if ($("#pass-confirm-error").hasClass("none-opacity"))
        {
            $("#pass-confirm-error").removeClass("none-opacity");
            $("#pass-confirm-error").addClass("full-opacity");

            setTimeout(function ()
            {
                $("#pass-confirm-error").removeClass("full-opacity");
                $("#pass-confirm-error").addClass("none-opacity");
            }, 5000);
        }
        else
        {
            $("#pass-confirm-error").addClass("full-opacity");

            setTimeout(function () {
                $("#pass-confirm-error").removeClass("full-opacity");
                $("#pass-confirm-error").addClass("none-opacity");
            }, 5000);
        }
    } else if (grecaptcha.getResponse() == "") {

        if ($("captcha-error").hasClass("none-opacity")) {
            $("#captcha-error").removeClass("none-opacity");
            $("#captcha-error").addClass("full-opacity");

            setTimeout(function () {
                $("#captcha-error").removeClass("full-opacity");
                $("#captcha-error").addClass("none-opacity");
            }, 5000);
        }
        else {
            $("#captcha-error").addClass("full-opacity");

            setTimeout(function () {
                $("#captcha-error").removeClass("full-opacity");
                $("#captcha-error").addClass("none-opacity");
            }, 5000);
        }

        $("#captcha-error").css("display", "block");
    } else {

        $("#captcha-error").css("display", "none");

        $("#registrar-usuario-form").submit();

    }

    

    
}

function validarCaptcha() {

    if (grecaptcha.getResponse() == "") {

        $("#captcha-error").show();

    }
    else {
        $("#captcha-error").hide();
    }


}
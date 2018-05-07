function validarFormularioDeLoginDeUsuario(){
    var email = $("#user").val();
    var pass = $("#login-pass").val();

    var emailValido = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (email.length >= 50 || email.search(emailValido)) {
        if ($("#login-email-error").hasClass("none-opacity")) {
            $("#login-email-error").removeClass("none-opacity");
            $("#login-email-error").addClass("full-opacity");

            setTimeout(function () {
                $("#login-email-error").removeClass("full-opacity");
                $("#login-email-error").addClass("none-opacity");
            }, 5000);
        } else {
            $("#login-email-error").addClass("full-opacity");

            setTimeout(function () {
                $("#login-email-error").removeClass("full-opacity");
                $("#login-email-error").addClass("none-opacity");
            }, 5000);

        }
    } else if (pass.length >= 20 || pass.length == 0) {
        if ($("#login-pass-error").hasClass("none-opacity")) {
            $("#login-pass-error").removeClass("none-opacity");
            $("#login-pass-error").addClass("full-opacity");

            setTimeout(function () {
                $("#login-pass-error").removeClass("full-opacity");
                $("#login-pass-error").addClass("none-opacity");
            }, 5000);
        } else {
            $("#login-pass-error").addClass("full-opacity");

            setTimeout(function () {
                $("#login-pass-error").removeClass("full-opacity");
                $("#login-pass-error").addClass("none-opacity");
            }, 5000);
        }

    }
}
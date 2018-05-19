var slide2 = 0;
$(".ir-slide-1").click(
    function () {
        if (slide2 == 1) {
            $(".form-error").hide();
            $("#slider").removeClass("slide2");
            $("#slider").addClass("slide1");
            slide = 0;
        } else {
            $("#slider").addClass("slide1");
        }
    }
);

$(".ir-slide-2").click(
    function () {
        $(".form-error").hide();
        $("#slider").removeClass("slide1");
        $("#slider").addClass("slide2");


        slide2 = 1;

        setTimeout(function () {
            $(".form-error").show();
        }, 2000)
    }

);



    $(document).ready(function () {
        $("#myModal").modal('show');
});


function mostrarModal() {
    $("#myModal").modal('show');
}

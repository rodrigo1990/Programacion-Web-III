
$("document").ready(function(){
    $(".navbar-sub").hide();
});


$("#mis-tareas").mouseover(function(){

    $("#mis-tareas-sub").show();

});


$("#mis-tareas-sub").mouseleave(function () {

    $("#mis-tareas-sub").hide();

});


$("#mis-carpetas").mouseover(function () {

    $("#mis-carpetas-sub").show();

});


$("#mis-carpetas-sub").mouseleave(function () {

    $("#mis-carpetas-sub").hide();

});
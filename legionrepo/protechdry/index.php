<?php 
require_once("clases/Producto.php");
require_once("clases/Session.php");
require_once("clases/BaseDatos.php");
require_once("clases/Usuario.php");
session_start();
$usuario=new Usuario();
?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	
	<!-- BOOTSTRAP -->
	<link rel="stylesheet" href="bootstrap-3.3.7-dist/css/bootstrap.min.css" media="screen">
	<!-- ESTILOS PROPIOS -->
	<link rel="stylesheet" type="text/css" href="estilos_css/fuentes.css">
	<link rel="stylesheet" href="estilos_css/estilos.css">
	<link rel="stylesheet" type="text/css" href="estilos_css/estilos2.css">
	<!-- MATERIAL ICONS -->
	<link href="https://fonts.googleapis.com/icon?family=Material+Icons"rel="stylesheet">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
	<!-- OWL CARROUSEL -->
	<link rel="stylesheet" href="owlcarousel/dist/assets/owl.carousel.min.css">
	<link rel="stylesheet" href="owlcarousel/dist/assets/owl.theme.default.min.css">

	<!-- ANIMATED.CSS -->
<link rel="stylesheet" href="estilos_css/animate.css">


		<title>PROTECH</title>

</head>
<body>

	<?php 
	include("include/menu.php");
	 ?>
	

	<!-- Set up your HTML -->
	<div class="owl-carousel" style="">
	  <div><img src="banners/banner_1.png"  width="100%" alt="Protech Dry"></div>
	  <div><img src="banners/banner_2.jpg"  width="100%" alt="Protech Dry"></div>
	  <div><img src="banners/banner_3.jpg"  width="100%" alt="Protech Dry"></div>
	</div>

	<!-- Slider -->
		<div class="slider-info text-center" style="position:absolute;left:50%;" >
			<div style="position:relative;left:-50%;top:50%;z-index: 2000;">
				<h2>Ropa interior de algodón</h2>
				<h1>RECOMENDADA PARA INCONTINENCIA MODERADA</h1>
				<br>
				<a class='slider-button' href="todosLosProductos.php">COMPRAR</a>
			</div>
		</div>

<!-- CARRITO DE COMPRAS !! -->
 <!-- CARRITO DE COMPRAS !! -->
<div id="carrito" class="animated slideInDown carrito-ver-mas" style="    margin-top: -37%">

	<i id="carrito-close" class="material-icons"  onClick="cerrarVentanaCarrito();">close</i>
	<ul id="carrito-lista">
		<?php 

		$bd=new BaseDatos();
		$usuario->mostrarCarrito();

		?>
	</ul>
</div>
<?php $bd->listarProductos(); ?>




<!-- MODAL COMPRAR -->
<?php 
include("include/modal-comprar.php");
 ?>








	


<!--End of Zendesk Chat Script-->

<!-- FUNCIONES JS -->
<script src="jquery/jquery-3.2.1.min.js"></script>
<script type="text/javascript">
var $jQuery_3_2_1 = $.noConflict();
</script>
<script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>

<!-- MENU FIXED  -->
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="js/jquery.sticky.js"></script>
<script type="text/javascript" src="js/script.js"></script>
<script type="text/javascript" src="js/carrito.js"></script>
<script type="text/javascript" src="js/validaciones-modal.js"></script>
<script src="owlcarousel/docs/assets/vendors/jquery.min.js"></script>
<script type="text/javascript">
	var $jQueryOwl = $.noConflict();
</script>
<script src="owlcarousel/dist/owl.carousel.js"></script>
<script src="https://secure.mlstatic.com/sdk/javascript/v1/mercadopago.js"></script>
<script>
  $jQueryOwl('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    autoplay:true,
    autoplayTimeout:4000,
    nav:false,
    dots:true,
    items:3,
    responsive:{
        0:{
            items:1
        },
        1200:{
            items:1
        }
    }
})
</script>
</body>


</html>

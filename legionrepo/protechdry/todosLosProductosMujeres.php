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
	<script src="jquery/jquery-3.2.1.min.js"></script>
	<script type="text/javascript">
	var $jQuery_3_2_1 = $.noConflict();
	</script>
	<!-- BOOTSTRAP -->
	<link rel="stylesheet" href="bootstrap-3.3.7-dist/css/bootstrap.min.css" media="screen">
	<script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
	<!-- ESTILOS PROPIOS -->
	<link rel="stylesheet" type="text/css" href="estilos_css/fuentes.css">
	<link rel="stylesheet" type="text/css" href="estilos_css/estilos2.css">
	<link rel="stylesheet" type="text/css" href="estilos_css/estilos.css">
	<!-- MATERIAL ICONS -->
	<link href="https://fonts.googleapis.com/icon?family=Material+Icons"rel="stylesheet">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
	<!-- MENU FIXED  -->
	<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
	<script type="text/javascript" src="js/jquery.sticky.js"></script>
	<!-- ANIMATED.CSS -->
<link rel="stylesheet" href="estilos_css/animate.css">


		<title>PROTECH</title>

</head>
<body>

	<?php 
	include("include/menu.php");
	 ?>


<!-- CARRITO DE COMPRAS !! -->
 <!-- CARRITO DE COMPRAS !! -->
<div id="carrito" class="animated slideInDown carrito-ver-mas" style="margin-top: -2%;left: 57%;display: block;">

	<i id="carrito-close" class="material-icons"  onClick="cerrarVentanaCarrito();">close</i>
	<ul id="carrito-lista">
		<?php 

		$bd=new BaseDatos();
		$usuario->mostrarCarrito();

		?>
	</ul>
</div>
<?php $bd->listarProductosMujeres(); ?>




<!-- MODAL COMPRAR -->
<?php 
include("include/modal-comprar.php");
 ?>








	


<!--End of Zendesk Chat Script-->

	<!-- FUNCIONES JS -->
<script type="text/javascript" src="js/script.js"></script>
<script type="text/javascript" src="js/carrito.js"></script>
<script type="text/javascript" src="js/validaciones-modal.js"></script>


<script src="https://secure.mlstatic.com/sdk/javascript/v1/mercadopago.js"></script>

</body>


</html>

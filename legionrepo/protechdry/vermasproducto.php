<?php
require_once("clases/BaseDatos.php");
require_once("clases/Producto.php");
require_once("clases/Session.php");
require_once("clases/Usuario.php");

session_start();
//session_destroy();
$session = new Session();
$session->controlarTiempoDeSesion();

$_SESSION['login']=FALSE;
$_SESSION['login-cliente']=FALSE;


$bd=new BaseDatos();
$usuario=new Usuario();

   if(!isset($_GET['id']) OR $_GET['id']==''){

			header('Location: index.php');

	}

 ?>
<!DOCTYPE html>
<html lang="en">
<head>
	<title>Oeste Neumaticos</title>
	<meta http-equiv="Content-type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="width=device-width" />
	<!-- JQUERY -->
	<script src="jquery/jquery-3.2.1.min.js"></script>
	<script type="text/javascript">
	var $jQuery_3_2_1 = $.noConflict();
	</script>
	<!-- BOOTSTRAP -->
	<link rel="stylesheet" href="bootstrap-3.3.7-dist/css/bootstrap.min.css" media="screen">
	<script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
	<!-- ESTILOS PROPIOS -->
	<link rel="stylesheet" type="text/css" href="estilos_css/fuentes.css"> 
	<!--  --> <link rel="stylesheet" type="text/css" href="estilos_css/estilos.css">
	<link rel="stylesheet" type="text/css" href="estilos_css/estilos2.css">
	<!-- MATERIAL ICONS -->
	<link href="https://fonts.googleapis.com/icon?family=Material+Icons"rel="stylesheet">
	<!-- MENU FIXED  -->
	<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>	
	<script type="text/javascript" src="js/jquery.sticky.js"></script>
	<!-- ANIMATED.CSS -->
	<link rel="stylesheet" href="estilos_css/animate.css">
	<!-- FANCY BOX -->
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.3.4/jquery.fancybox.min.css" />

</head>


<body>
<!-- MENU -->
<?php 
include ("include/menu.php");
 ?>



 <!-- CARRITO DE COMPRAS !! -->
<div class="container">
<div id="carrito" class="animated slideInDown carrito-ver-mas">

	<i id="carrito-close" class="material-icons"  onClick="cerrarVentanaCarrito();">close</i>
	<ul id="carrito-lista">
		<?php 

		$bd=new BaseDatos();
		$usuario->mostrarCarrito();

		?>
	</ul>
</div>
</div>

<div class="row ver-mas-row " style='margin-top:5%'>

	<div class="container">

		<div class="hidden-xs col-sm-8 col-md-8 col-lg-8">
			<?php $bd->listarImagenes($_GET['id']);?>
		</div><!-- col -->

		<div class="producto-ver-mas col-xs-12 col-sm-4 col-md-4 col-lg-4">
			<?php


				$bd->listarUnSoloProducto($_GET['id']);

					





			 ?>	
		</div><!-- col -->

			<?php $bd->listarImagenesXs($_GET['id']);?>


	 </div><!-- container -->

</div><!-- row -->


<?php $bd->listarImagenesSm($_GET['id']) ?>




<!-- MODAL COMPRAR -->
<?php 
include("include/modal-comprar.php");
 ?>

 <!-- modal mis pedidos -->
<?php include("include/modal-mis-pedidos.php") ?>





<!-- FUNCIONES JS -->
<script type="text/javascript" src="js/script.js"></script>
<script type="text/javascript" src="js/carrito.js"></script>
<script type="text/javascript" src="js/validaciones-modal.js"></script>


<!-- STYLABLE SPINNER -->
<script src="https://code.jquery.com/jquery-1.11.3.min.js"integrity="sha256-7LkWEzqTdpEfELxcZZlS6wAx5Ff13zZ83lYO2/ujj7g=" crossorigin="anonymous"></script>
<script type="text/javascript">
var $jQuery_1_11_3 = $.noConflict();
</script>
<script type="text/javascript" src="js/jquery.numble.min.js"></script>

<!-- ELEVATE ZOOM -->
<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>	
<script type="text/javascript">
var $jQuery_1_8_3 = $.noConflict();
</script>
<script type="text/javascript" src="js/jquery.elevatezoom.js"></script>

<!-- Fancybox -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.3.4/jquery.fancybox.min.js"></script>





<script>
   	$jQuery_1_8_3('#img-zoom').elevateZoom();
   	$jQuery_1_11_3("input[type=number]").numble({minValue:1,maxValue:30,initialValue:1,allowNegative:false});

</script>
<script src="https://secure.mlstatic.com/sdk/javascript/v1/mercadopago.js"></script>



<!--End of Zendesk Chat Script-->
</body>
</html>
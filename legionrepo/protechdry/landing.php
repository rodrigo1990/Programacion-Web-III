<?php 
session_start();
require_once("clases/Producto.php");
require_once("clases/BaseDatos.php");
require_once("clases/Mail.php");

if(isset($_GET['collection_id'])){
$BaseDatos=new BaseDatos();
$mail = new Mail();

	if ($_GET['collection_status']=='approved'){

	$BaseDatos->actualizarIdMpEnVenta($_GET['collection_id'],$_SESSION['referencia'],1,2);
		
		//$mail->enviarComprobantePagoExitosoMercadoPago();

	}else if($_GET['collection_status']=='pending'){

	$BaseDatos->actualizarIdMpEnVenta($_GET['collection_id'],$_SESSION['referencia'],1,1);
	//$mail->enviarComprobantePagoPendienteMercadoPago();
	}


session_destroy(); 
}else{
	header("location: index.php");
}
 ?>
 <!DOCTYPE html>
 <html lang="en">
 <head>
 	<meta charset="UTF-8">
 	<title>Document</title>

 		<meta name="viewport" content="width=device-width, initial-scale=1">
	<script src="jquery/jquery-3.2.1.min.js"></script>
	<!-- BOOTSTRAP -->
	<link rel="stylesheet" href="bootstrap-3.3.7-dist/css/bootstrap.min.css" media="screen">
	<script src="bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
	<!-- ESTILOS PROPIOS -->
	<link rel="stylesheet" type="text/css" href="estilos_css/fuentes.css">
	<link rel="stylesheet" type="text/css" href="estilos_css/estilos.css">
	<!-- MATERIAL ICONS -->
	<link href="https://fonts.googleapis.com/icon?family=Material+Icons"rel="stylesheet">
	<!-- MENU FIXED  -->
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
	<script type="text/javascript" src="js/jquery.sticky.js"></script>
	<!-- ANIMATED.CSS -->
	<link rel="stylesheet" href="estilos_css/animate.css">


	<!-- FUNCIONES JS -->
	<script type="text/javascript" src="js/script.js"></script>
	<link rel="apple-touch-icon" sizes="57x57" href="favicon/apple-icon-57x57.png">
		<link rel="apple-touch-icon" sizes="60x60" href="favicon/apple-icon-60x60.png">
		<link rel="apple-touch-icon" sizes="72x72" href="favicon/apple-icon-72x72.png">
		<link rel="apple-touch-icon" sizes="76x76" href="favicon/apple-icon-76x76.png">
		<link rel="apple-touch-icon" sizes="114x114" href="favicon/apple-icon-114x114.png">
		<link rel="apple-touch-icon" sizes="120x120" href="favicon/apple-icon-120x120.png">
		<link rel="apple-touch-icon" sizes="144x144" href="favicon/apple-icon-144x144.png">
		<link rel="apple-touch-icon" sizes="152x152" href="favicon/apple-icon-152x152.png">
		<link rel="apple-touch-icon" sizes="180x180" href="favicon/apple-icon-180x180.png">
		<link rel="icon" type="favicon/png" sizes="192x192"  href="favicon/android-icon-192x192.png">
		<link rel="icon" type="favicon/png" sizes="32x32" href="favicon/favicon-32x32.png">
		<link rel="icon" type="favicon/png" sizes="96x96" href="favicon/favicon-96x96.png">
		<link rel="icon" type="favicon/png" sizes="16x16" href="favicon/favicon-16x16.png">
		<link rel="manifest" href="favicon/manifest.json">
		<meta name="msapplication-TileColor" content="#ffffff">
		<meta name="msapplication-TileImage" content="/ms-icon-144x144.png">
		<meta name="theme-color" content="#ffffff">
 </head>
 <body>

<!-- MENU -->
<?php 
	include("include/menu-checkout.php");
 ?>







<div class="row">

	<div class="landing-cont col-xs-12 col-sm-12 col-md-12 col-lg-12">
	 	<h1><b>Te hemos enviado un mail con los detalles de la compra</b</h1>

	 	<h3><a href="index.php"><b>Sigue comprando y enterandote de nuestras ofertas</b></a></h3>
	 	<img src="elementos_separados/logo.png" alt="" class="img-reponsive">
	</div>


</div>


<!-- modal mis pedidos -->
<?php include("include/modal-mis-pedidos.php") ?>

 <!-- FOOTER -->
<?php 
include("include/footer.php");
 ?>


 </body>
 </html>
<?php 
require_once("../clases/BaseDatos.php");
require_once("../clases/Usuario.php");
require_once("../clases/Administrador.php");
require_once("../clases/Session.php");


session_start();
$session = new Session();
$session->controlarTiempoDeSesion();

$baseDatos=new BaseDatos();


if($_SESSION['login']==FALSE){
	header("Location:../index.php");
}

$admin=new Administrador();


 ?>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<script src="../jquery/jquery-3.2.1.min.js"></script>
	<!-- BOOTSTRAP -->
	<link rel="stylesheet" href="../bootstrap-3.3.7-dist/css/bootstrap.min.css" media="screen">
	<script src="../bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
<!-- ESTILOS PROPIOS -->
	<link rel="stylesheet" type="text/css" href="../estilos_css/fuentes.css">
	<link rel="stylesheet" type="text/css" href="../estilos_css/estilos.css">
	<link rel="stylesheet" type="text/css" href="../estilos_css/estilos2.css">
	<!-- MATERIAL ICONS -->
	<link href="https://fonts.googleapis.com/icon?family=Material+Icons"rel="stylesheet">
	<!-- MENU FIXED  -->
	<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
	<script type="text/javascript" src="../js/jquery.sticky.js"></script>
	<!-- ANIMATED.CSS -->
	<link rel="stylesheet" href="../estilos_css/animate.css">

	<!-- FUNCIONES JS -->
	<script type="text/javascript" src="../js/script.js"></script>
</head>

<body>
	<!-- Menu -->
<?php include("include/menu-admin.php");?>

<div class="link-admin-home-cont row" style='text-align:center;'>
	<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
		<a href='usuario-admin-ventas.php'><i><h1 class='link-admin-home'>VER LISTADO DE VENTAS</h1></i></a>
	</div>
</div>
<div class="link-admin-home-cont row" style='text-align:center;'>
	<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
		<a href='usuario-admin-listar-usuarios.php'><i><h1 class='link-admin-home'>VER LISTADO DE USUARIOS</h1></i></a>
	</div>
</div>



<script src="https://secure.mlstatic.com/sdk/javascript/v1/mercadopago.js"></script>



</body>
</html>
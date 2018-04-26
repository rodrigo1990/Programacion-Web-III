<div class="row menu" style="padding: 2%;">
	<div class="container">
		<div class="col-lg-3 col-md-3 col-sm-2 col-xs-12">
			<a href="index.php">
				<img src="elementos_separados/logo.png" class="logo img-responsive" alt="" style="">
			</a>
		</div>

		<div class="col-lg-6 col-md-6 hidden-sm hidden-xs">
		 <a href="sobreNosotros.php"><h4>SOBRE PROTECH DRY</h4></a>
			<a href="todosLosProductosHombres.php"><h4>HOMBRES</h4></a>
			<a href="todosLosProductosMujeres.php"><h4>MUJERES</h4></a>
		</div>

		<div class="hidden-lg hidden-md col-sm-8 hidden-xs">
		 <a href="sobreNosotros.php"><h4>SOBRE PROTECH DRY</h4></a>
			<a href="todosLosProductosHombres.php"><h4>HOMBRES</h4></a>
			<a href="todosLosProductosMujeres.php"><h4>MUJERES</h4></a>
		</div>

	

		<div class="col-lg-3 col-md-2 col-sm-2 hidden-xs">
			<div style="">
				<div class="element-menu-carrito" id="mostrar-total-menu" style="float:left;">
						<p id="menu-total"><?php $usuario->mostrarSubtotal();?>$</p>

					</div><!-- mostrar-total-menu -->

					<div id="btn-carrito" class="element-menu-carrito" style="cursor:pointer;">
						 
						<div   class="icon-shopping-cart"><span id="cantidad"> <strong id="cantidad-strong"><?php $usuario->mostrarCantidad();?></strong></span> </div>
					</div>
			</div>
		</div>


	</div>
</div>
	<?php
	include("conexion.inc.php");
	$flujo=$_GET["flujo"];
	$proceso=$_GET["proceso"];
	$sql="select * from flujo where flujo='".$flujo."' and proceso='".$proceso."'";
	$resultado=mysqli_query($conn, $sql);
	$fila=mysqli_fetch_array($resultado);
	// print_r ($fila);
	include ("cabecera.php");
	?>
	<div class="divContainer">
		<div class="divForm">
			<form action="motorFlujo.php" method="GET">
				<?php include $fila['Formulario'];?>
				<br>
				<input type="hidden" value="<?php echo $fila['Formulario'];?>" name="formulario"/>
				<input type="hidden" value="<?php echo $flujo?>" name="flujo"/>
				<input type="hidden" value="<?php echo $proceso?>" name="proceso"/>
				<div class="divBtn">
					<input class="button4" type="submit" value="Anterior" name="Anterior"/>
					<input class="button5" type="submit" value="Siguiente" name="Siguiente"/>
				</div>
			</form>
		</div>
	</div>
	<?php include("footer.php");?>
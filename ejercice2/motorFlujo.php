<?php
	include "conexion.inc.php";
	$flujo=$_GET["flujo"];
	$proceso=$_GET["proceso"];
	$formulario=$_GET["formulario"];
    if(isset($_GET["Siguiente"])){
        $sql="select * from flujo where flujo='".$flujo."' and proceso='".$proceso."'";
        $resultado=mysqli_query($conn, $sql);
        $fila=mysqli_fetch_array($resultado);
        $procSig = $fila['proceso_sig'];
        if ($procSig=='')
		{
			$sql="select * from flujo_condicional where flujo='".$flujo."' and proceso='".$proceso."'";
			$resultado2=mysqli_query($conn, $sql);
			$fila2=mysqli_fetch_array($resultado2);
			if ($pregunta=='si')
				$procSig=$fila2["verdad"];
			else 
				$procSig=$fila2["falso"];
		}
        header("Location:desflujo.php?flujo=".$flujo."&proceso=".$procSig);
    }else{
        $sql="select * from flujo where flujo='".$flujo."' and proceso_sig='".$proceso."'";
        $resultado=mysqli_query($conn, $sql);
        $fila=mysqli_fetch_array($resultado);
        $proc = $fila['proceso'];
        header("Location:desflujo.php?flujo=".$flujo."&proceso=".$proc);
    }
	
?>

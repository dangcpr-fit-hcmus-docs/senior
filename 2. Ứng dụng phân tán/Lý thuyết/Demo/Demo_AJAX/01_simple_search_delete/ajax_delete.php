<?php
	require("dbconnect.php");
	$mysqli = connect();
    $mysqli->query("SET NAMES utf8");
    $q = $_REQUEST["q"];
    $query = "DELETE FROM SINHVIEN WHERE MSSV = '$q'";
    echo $query;
    $result = $mysqli->query($query);	
	$mysqli->close();
	
	//echo "HELLO";
?>
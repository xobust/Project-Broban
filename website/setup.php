<?php
requre("config.php");

$mysql = new PDO("mysql:host=$DB_HOST", $DB_USER, $DB_PASSWORD); 
$pstatement = $mysql->prepare("CREATE DATABASE IF NOT EXISTS $dbname");
$pstatment->execute();

$database = new PDO("mysql:host=.$DB_HOST;dbname=$DB_NAME", $DB_USER, $DB_PASSWORD); 


?>

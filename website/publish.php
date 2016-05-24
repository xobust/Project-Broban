<?php

require("config.php");

if( !isset($_POST["name"]) || !isset($_POST["time"]))
{
    exit("Incorrect post parameters");
}

$name = $_POST["name"];
$time = $_POST["time"];

$database = new PDO("mysql:host=".DB_HOST.";dbname=".DB_NAME, DB_USER, DB_PASSWORD); 
$stmt = $database->prepare("INSERT INTO highscore (Name, Time) values (:name, :time)");
$stmt->bindParam(':name', $name);
$stmt->bindParam(':time', $time);

$stmt->execute();


?>

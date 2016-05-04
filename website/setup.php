<?php
/**
* This script sets up the databese configured in config.php
*
* Author: Alexander Bladh
* Date: 2016-05-04 
*/
require("config.php");

$mysql = new PDO("mysql:host=$DB_HOST", $DB_USER, $DB_PASSWORD); 
$pstatement = $mysql->prepare("CREATE DATABASE IF NOT EXISTS $dbname");
$pstatment->execute();

$database = new PDO("mysql:host=.$DB_HOST;dbname=$DB_NAME", $DB_USER, $DB_PASSWORD); 
$table= "highscore";
$columns = "ID INT( 11 ) AUTO_INCREMENT PRIMARY KEY, Name VARCHAR(15) NOT NULL, Time INT(10) NOT NULL";

$createTable = $db->exec("CREATE TABLE IF NOT EXISTS $DB_NAME.$table ($columns)");
if ($createTable) 
{
    echo "Table $table - Created!<br /><br />";
}    
else 
{ 
    echo "Table $table not successfully created! <br /><br />";
}
?>

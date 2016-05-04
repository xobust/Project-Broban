<!DOCTYPE HTML>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>Project Broban - Scoreboard</title>
<?php require("head.php") ?>
</head>

<body class="Scoreboard">
    <nav>
        <ul class="menu">
            <li><a href="index.php">Home</a></li>
            <li><a href="download.php">Download</a></li>
            <li><a href="scoreboard.php" class="current">Scoreboard</a></li>
        </ul>
    </nav>
    <section class="scoreTable">
        <h1>Scoreboard</h1>
        <table class="scoreTable">
            <tr>
                <th>Name</th>
                <th>Time</th>
            </tr>
            <?php
                require("config.php");
                $database = new PDO("mysql:host=.$DB_HOST;dbname=$DB_NAME", $DB_USER, $DB_PASSWORD); 
                $stmt = $database->prepare("SELECT * FROM highscore ORDER BY Time");
                $stmt->execute();
                while ($row = $result->fetch(PDO::FETCH_ASSOC))
                {
                    echo "<tr>";
                    echo "<td>".$row["Name"]."</td>";
                    echo "<td>".$row["Time"]."</td>";
                    echo "</tr>";
                }
            ?>
        </table>
    </section>
</body>
</html>

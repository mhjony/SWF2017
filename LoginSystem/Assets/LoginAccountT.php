<?php
$Hostname = "localhost";
$DBName = "accounts";
$User = "root";
$PasswordP = "";

mysql_connect($Hostname, $User, $PasswordP) or die("Can't connect into database");
mysql_select_db($DBName) or die("Can't connect into database");

$Email = $_REQUEST["Email"];
$Password = $_REQUEST["Password"];

$result = mysql_query("select * from accounts where Email = '$Email' and Password = '$Password'")
			or die("Failed to query database".mysql_error());

$row = mysql_fetch_array($result);
if ($row['Email'] == $Email && $row['Password'] == $Password) {
	echo "Login success!! Congratulations";
}

else{
	echo "Login Fail";
}




mysql_close();

?>
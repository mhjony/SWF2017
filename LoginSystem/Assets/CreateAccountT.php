<?php
	//Email and password
$Email = $_REQUEST["Email"];
$Password = $_REQUEST["Password"];



	//php only
$Hostname = "localhost";
$DBName = "accounts";
$User = "root";
$PasswordP = "";

mysql_connect($Hostname, $User, $PasswordP) or die("can't connect to DB ");
mysql_select_db($DBName) or die("Can't connect to DB");

if (!$Email || !$Password) {
	echo "Empty";
}else{
	$SQL = "SELECT * FROM accounts WHERE Email = '". $Email ."'";
	$Result = @mysql_query($SQL) or die("DB Error");
	$Total = mysql_num_rows($Result);
	if ($Total == 0) {
		$insert = "INSERT INTO 'accounts' ('Email', 'Password') VALUES  ('" . $Email ."', '". $Password ."')";
		$SQL1 = mysql_query($insert);
		echo "Success";
	}else{
		echo "AlreadyUsed";
	}

}// End Main Else

//close mysql
mysql_close();



?>
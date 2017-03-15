<?php
$Hostname = "localhost";
$DBName = "accounts";
$User = "root";
$PasswordP = "";

mysql_connect($Hostname, $User, $PasswordP) or die("Can't connect into database");
mysql_select_db($DBName) or die("Can't connect into database");

$Email = $_REQUEST["Email"];
$Password = $_REQUEST["Password"];

if (!$Email || !$Password) 
	{
	# code...
	echo "Login or user can't be empty";
	}
	else
	{
	$SQL = "SELECT *FROM accounts WHERE Email = '" . $Email . "'";
	$result_id = @mysql_query($SQL) or die("Database Error");
	$total = mysql_num_rows($result_id);
	if ($total) 
	{
		# code...
		$datas = @mysql_fetch_array($result_id);
		if (strcmp($Password, $datas["Password"])) 
		{
			# code...
			$sql2 = "SELECT Characters FROM accounts WHERE Email = '" . $Email . "'";
			$result_id2 = @mysql_query($sql2) or die("Database error!");
			while ($row = mysql_fetch_array($result_id2)) 
			{
				# code...
				echo $row['Characters'];
				echo ":";
				echo "Sucess";
			}

		}
		else
		{
			echo "Wrong Password";
		}
	}
	
	else
	{
		echo "Name Does not exist";
	}
}


mysql_close();

?>
<?php
$Hostname = "localhost";
$DBName = "accounts";
$User = "root";
$PasswordP = "";

mysql_connect($Hostname, $User, $PasswordP) or die("Can't connect into database");
mysql_select_db($DBName) or die("Can't connect into database");

$Email = $_POST['Email'];
$Password = $_POST['Password'];

if (!$Email || !$Password) {
	# code...
	echo "Login or user can't be empty";
}else{
	if(isset($_POST["Email"], $_POST["Password"])) 
    {     

        $Email = $_POST["Email"]; 
        $Password = $_POST["Password"]; 

        $result1 = mysql_query("SELECT * FROM accounts WHERE Email = '".$Email."' AND  Password = '".$Password."'") or die(mysql_error());

       $check_username = "";
       $check_password = "";

       while($row=mysql_fetch_assoc($result1))
		{
			$check_username=$row['Email'];
			$check_password=$row['Password'];
		}

			if($Email == $check_username && $Password == $check_password){
			echo "Matches.";
			}

			else{
				echo "No match.";
			}
}
}


mysql_close();

?>
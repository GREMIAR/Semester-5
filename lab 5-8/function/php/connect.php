<?php
	$link;
	$result;
	function Connect()
	{
		global $link;
		$host = 'localhost';
		$database = 'articles';
		$user = 'root';
		$password = '';
		$link = mysqli_connect($host, $user, $password, $database)
		or die("Ошибка 1" . mysqli_error($link));
		$link->set_charset("utf8");
	}
	function Close()
	{
		global $link;
		mysqli_close($link);
	}
?>

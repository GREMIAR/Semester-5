<?php
$link;
$result;
function Connect()
{
	global $link;
	$host = 'localhost'; // адрес сервера 
	$database = 'NewGame'; // имя базы данных
	$user = 'root'; // имя пользователя
	$password = ''; // пароль
	$link = mysqli_connect($host, $user, $password, $database) 
	or die("Ошибка " . mysqli_error($link)); 
	$link->set_charset("utf8");
}
function Close()
{
	global $link;
	mysqli_close($link);
}
function SelectBD($nameTable)
{
	global $link,$result;
	$query ="SELECT * FROM" . $nameTable;
	$result = mysqli_query($link, $query) or die("Ошибка " . mysqli_error($link)); 
}
function GetString($num,$rows)
{
	global $result;
	for($i=1;$i<$rows;$i++)
	{
		$row = mysqli_fetch_row($result);
		if($i==$num)
		{
			return $row;
		}
	}
}
?>

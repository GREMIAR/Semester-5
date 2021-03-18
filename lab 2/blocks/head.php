<?php
if(isset($_POST['AboutGame']) or empty($_POST))
{
	echo '<meta charset="utf-8">
	<title>Об игре</title>
	<link type="text/css" href="style/style.css" rel="stylesheet">';
}
else if(isset($_POST['Counter']))
{
	echo '<meta charset="utf-8">
		<title>Обратный отсчёт</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<link  type="text/css" href="style/styleWithoutMenu.css"rel="stylesheet">';
}
else if(isset($_POST['Download']))
{
	echo '<meta charset="utf-8">
		<title>Скачать</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<link  type="text/css" href="style/styleWithoutMenu.css"rel="stylesheet">';
}?>
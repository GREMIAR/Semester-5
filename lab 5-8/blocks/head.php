<?php
	if(isset($_GET['News']) or empty($_GET))
	{
		echo '
		<meta charset="utf-8">
		<title>Новости</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">';
	}
	else if(isset($_GET['Counter']))
	{
		echo '
		<meta charset="utf-8">
		<title>Обратный отсчёт</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<link  type="text/css" href="style/styleWithoutMenu.css"rel="stylesheet">';
	}
	else if(isset($_GET['Download']))
	{
		echo '
		<meta charset="utf-8">
		<title>Скачать</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<link  type="text/css" href="style/styleWithoutMenu.css"rel="stylesheet">';
	}
?>
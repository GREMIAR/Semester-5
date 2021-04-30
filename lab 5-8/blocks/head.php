<?php
	if(isset($_GET['News']) or empty($_GET))
	{
		echo '
		<meta charset="utf-8">
		<title>Новости</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<script type="text/javascript" src="function/js/script.js"></script>';
	}
	else if(isset($_GET['Counter']))
	{
		echo '
		<meta charset="utf-8">
		<title>Обратный отсчёт</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<link  type="text/css" href="style/styleWithoutMenu.css"rel="stylesheet">
		<script type="text/javascript" src="function/js/Counter.js"></script>';
	}
	else if(isset($_GET['Download']))
	{
		echo '
		<meta charset="utf-8">
		<title>Скачать</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<link  type="text/css" href="style/styleWithoutMenu.css"rel="stylesheet">';
	}
	else if(isset($_GET['Add']) or isset($_GET['Edit']) or isset($_GET['Del']))
	{
		echo '
		<meta charset="utf-8">
		<title>Конструктор</title>
		<link type="text/css" href="style/designer.css" rel="stylesheet">';
	}
?>
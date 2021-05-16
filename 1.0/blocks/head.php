<?php
	if(isset($_POST["Edit"]))
	{
		echo '
		<meta charset="utf-8">
		<title>Конструктор</title>
		<link type="text/css" href="style/designer.css" rel="stylesheet">';
	}
	else if(isset($_POST["News"]) or empty($_POST))
	{
		echo '
		<meta charset="utf-8">
		<title>Новости</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<script src="function/jQuery/jquery-3.6.0.min.js"></script>
		<script type="text/javascript" src="function/js/script.js"></script>';
	}
	else if(isset($_POST["Counter"]))
	{
		echo '
		<meta charset="utf-8">
		<title>Обратный отсчёт</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<link  type="text/css" href="style/styleWithoutMenu.css"rel="stylesheet">';
	}
	else if(isset($_POST["Download"]))
	{
		echo '
		<meta charset="utf-8">
		<title>Скачать</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
		<link  type="text/css" href="style/styleWithoutMenu.css"rel="stylesheet">';
	}
	else if(isset($_POST["Add"]) or isset($_POST["Del"]))
	{
		echo '
		<meta charset="utf-8">
		<title>Конструктор</title>
		<link type="text/css" href="style/designer.css" rel="stylesheet">';
	}
?>
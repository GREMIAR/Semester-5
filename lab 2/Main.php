<?php
if($_SERVER["REQUEST_URI"]==$Counter  )
{
	$FileWithText = @file("text.php");
	$TitlePage = trim(stripslashes($FileWithText[0]));
}
echo "";
?>
<!DOCTYPE html>
<html lang=ru>
	<head>
		<meta charset="utf-8">
		<title>Об игре</title>
		<link type="text/css" href="style/style.css" rel="stylesheet">
	</head>
	<body>
		<a name="Start"></a>
		<header>NewGame</header>
		<section>
			<menu class="NavBar">
				<form method="POST">
					<li><a class="CurrentPlace" name = "AboutGame">Об игре</a>
					<li><a href="#" name="Counter">Обратный отсчёт</a>
					<li><a name="Download">Скачать</a>
				</from>
			</menu>
		</section>
		<menu class="menu">
			<li><div class = "menu_btn"><a href="#Start">Шапка</a></div>
			<li><div class = "menu_btn"><a href="#Mid">Середина</a></div>
			<li><div class = "menu_btn"><a href="#End">Авторы</a></div>
		</menu>
		<article class="ArticleMain">
			<?=$TitlePage;?>
  	</article>
  	<footer>
  		<p>Музалевский Никита<a href="https://github.com/GREBIAR-Git" target="_blank" name="End"><img src="image/gitL.png" width="50" height="50" alt="Музалевский Никита"></a>
  		<a href="https://github.com/mikhail01234" target="_blank"><img  src="image/gitR.png" width="50" height="50" alt="Аллянов Михаил"></a>Аллянов Михаил</p>
	</footer>
  </body>
</html>

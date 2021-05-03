<?php 
	if(isset($_GET["News"]) or empty($_GET))
	{
		echo '
		<menu class="menu">
		<li><div class = "menu_btn"><a href="#Start">Начало</a></div>
		<li><div class = "menu_btn"><a href="#Mid">Статьи</a></div>
		<li><div class = "menu_btn"><a href="#End">Авторы</a></div>
		</menu>';
	}
?>
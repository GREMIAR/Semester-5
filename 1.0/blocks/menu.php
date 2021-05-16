<?php 
	if (isset($_POST["Edit"])){}
	else if(isset($_POST["News"]) or empty($_POST))
	{
		echo '
		<menu class="menu">
		<li><div class = "menu_btn"><a href="#Start">Начало</a></div>
		<li><div class = "menu_btn"><a href="#Mid">Статьи</a></div>
		<li><div class = "menu_btn"><a href="#End">Авторы</a></div>
		</menu>';
	}
?>
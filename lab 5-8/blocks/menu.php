<?php 
	if(isset($_GET['AboutGame']) or empty($_GET))
	{
		echo '
		<menu class="menu">
		<li><div class = "menu_btn"><a href="#Start">Шапка</a></div>
		<li><div class = "menu_btn"><a href="#Mid">Середина</a></div>
		<li><div class = "menu_btn"><a href="#End">Авторы</a></div>
		</menu>';
	}
?>


<?php
if(!(isset($_GET['Add']) or isset($_GET['Edit']) or isset($_GET['Del'])))
{
	echo '
	<form action="#">
	<fieldset class="clearfixup">
		<button type="button" class="sign_in" id="sign_in1" onclick="sign_in();">Войти</button><a class="slash"> / </a>
		<button type="button" class="sign_up" id="sign_up1" onclick="sign_up();">Зарегистрироваться</button>
		<center><input name="sign" checked type="radio" value="in">
    	<input name="sign" type="radio" value="up"></center>
	</fieldset>
	<fieldset class="clearfix">
		<input class="login" type="text" name="lg" onBlur="" onFocus="" required placeholder="Логин" maxlength="28" minlength="6"">
		<input class="password" type="password" name="pswrd" onBlur="" required onFocus="" placeholder="Пароль" maxlength="20" minlength="6">
		<p>';
	/*if(isset($_GET["Next"]))
	{
	if(isset($_GET["News"]))
	{
		echo '<input type="hidden" name="News">';
	}
	else if (isset($_GET["Counter"]))
	{
		echo '<input type="hidden" name="Counter">';
	}
	else if (isset($_GET["Downloads"]))
	{
		echo '<input type="hidden" name="Downloads">';
	}
	}*/
	echo '<button class="sumbmit" type="sumbmit" name="next" onclick="Next();">Далее</button>
	</p>
	</fieldset>
	</form>';
}
?>

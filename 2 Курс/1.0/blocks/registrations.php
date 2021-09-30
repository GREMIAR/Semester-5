<?php
if (isset($_POST["Edit"])){}
else if(!(isset($_SESSION["role"])))
{
	echo '
	<form  method="post" class = "registration">
		<fieldset class="clearfixup">
			<button type="button" class="sign_in" id="sign_in1" onclick="sign_in();">Войти</button><a class="slash"> / </a>
			<button type="button" class="sign_up" id="sign_up1" onclick="sign_up();">Зарегистрироваться</button>
			<center><input name="sign" checked type="radio" value="in">
	    	<input name="sign" type="radio" value="up"></center>
		</fieldset>
		<fieldset class="clearfix">
			<input class="login" type="text" name="lg" onBlur="" required onFocus="" placeholder="Логин" maxlength="28" minlength="6">
			<input class="password" type="password" name="pswrd" required onBlur="" onFocus="" placeholder="Пароль" maxlength="20" minlength="6">
			<p>';
			if(isset($_POST["News"]))
			{
				echo '<input type="hidden" name="News">';
			}
			else if(isset($_POST["Counter"]))
			{
				echo '<input type="hidden" name="Counter">';
			}
			else if(isset($_POST["Download"]))
			{
				echo '<input type="hidden" name="Download">';
			}
			echo '
				<button class="sumbmit" type="sumbmit" name="next" onclick="Next();">Далее</button>
			</p>
		</fieldset>
	</form>';
}
else if (isset($_POST["News"]) or isset($_POST["Counter"]) or isset($_POST["Download"]))
{
	echo '
	<form  method="post" class = "registration">
		<fieldset class="clearfixup">
	    	<p class="textReg">Вы : ';
			echo $_SESSION['name'];
	    	echo '</p>
		</fieldset>
		<fieldset class="clearfix">';
			if(isset($_POST["News"]))
			{

				echo '<input type="hidden" name="exit"><button class="sumbmit" type="sumbmit" id="Exit" name="News">Выход</button>';
			}
			else if(isset($_POST["Counter"]))
			{
				echo '<input type="hidden" name="exit"><button class="sumbmit" type="sumbmit" id="Exit" name="Counter">Выход</button>';
			}
			else if(isset($_POST["Download"]))
			{
				echo '<input type="hidden" name="exit"><button class="sumbmit" type="sumbmit" id="Exit" name="Download">Выход</button>';
			}
		echo '</fieldset>
	</form>';
}
?>
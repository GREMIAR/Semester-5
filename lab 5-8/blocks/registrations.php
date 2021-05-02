<?php
if(!isset($_GET["IDP"]))
{
	echo '
	<form class = "registration">
		<fieldset class="clearfixup">
			<button type="button" class="sign_in" id="sign_in1" onclick="sign_in();">Войти</button><a class="slash"> / </a>
			<button type="button" class="sign_up" id="sign_up1" onclick="sign_up();">Зарегистрироваться</button>
			<center><input name="sign" checked type="radio" value="in">
	    	<input name="sign" type="radio" value="up"></center>
		</fieldset>
		<fieldset class="clearfix">
			<input class="login" type="text" name="lg" onBlur="" required onFocus="" placeholder="Логин" maxlength="28" minlength="6">
			<input class="password" type="password" name="pswrd" required onBlur="" onFocus="" placeholder="Пароль" maxlength="20" minlength="6">
			<p>
				<input type="hidden" name="News">
				<button class="sumbmit" type="sumbmit" name="next" onclick="Next();">Далее</button>
			</p>
		</fieldset>
	</form>';
}
else if (isset($_GET["News"]) or isset($_GET["Counter"]) or isset($_GET["Download"]))
{
	echo '
	<form class = "registration">
		<fieldset class="clearfixup">
	    	<p class="textReg">Вы : ';
	    	Connect();
			global $link;
			global $result;
			$IDP = htmlspecialchars($_GET["IDP"]);
			$sql = "SELECT * FROM `accounts` WHERE `IDP` = '$IDP'";
			$result = mysqli_query($link, $sql) or die("Ошибка " . mysqli_error($link));
			$rows = mysqli_num_rows($result);
			$row = mysqli_fetch_row($result);
			echo $row[2];
			Close();
	    	echo '</p>
		</fieldset>
		<fieldset class="clearfix">';
			if(isset($_GET["News"]))
			{
				echo '<button class="sumbmit" type="sumbmit" style="font-size:40px;" name="News">Выход</button>';
			}
			else if(isset($_GET["Counter"]))
			{
				echo '<button class="sumbmit" type="sumbmit" style="font-size:40px;" name="Counter">Выход</button>';
			}
			else if(isset($_GET["Download"]))
			{
				echo '<button class="sumbmit" type="sumbmit" style="font-size:40px;" name="Download">Выход</button>';
			}
		echo '</fieldset>
	</form>';
}
?>
<?php 
	require_once 'function/connect.php';
	$headstr;
	$headerstr;
	$menustr;
	$menubarstr;
	$articalstr;
	$footerstr;
	require_once 'function/function.php';
	ReactToPressedButton();
	echo '

	<!DOCTYPE html>
		<html lang=ru>
			<head>';
				require_once  ("blocks/head.php");
			echo '

			</head>
			<body>';
				require_once  ("blocks/header.php");
			    require_once  ("blocks/menubar.php");
			    require_once  ("blocks/menu.php");
			    echo '
				<fieldset class="clearfixup">
					<button type="button" class="sign_in" onclick="sign_in();">Войти</button><a class="slash"> / </a>
					<button type="button" class="sign_up" onclick="sign_up();">Зарегистрироваться</button>
				</fieldset>
				<fieldset class="clearfix">
					<input class="login" type="text" value="Логин" onBlur="" onFocus="">
					<input class="password" type="password" value="Пароль" onBlur="" onFocus="">
					<p><button class="sumbmit" type="button" id="elem" onclick="alerted();">
				Войти</button></p>
				</fieldset>';
				require_once  ("blocks/article.php");
				require_once  ("blocks/footer.php");
  			echo '
  			</body>
		</html>';
?>
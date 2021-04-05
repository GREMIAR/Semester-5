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
				require_once  ("blocks/article.php");
				require_once  ("blocks/footer.php");
  			echo '
  			</body>
		</html>';
?>
<!DOCTYPE html>
<?php
require_once 'function/php/connect.php';
require_once 'function/php/function.php';
EditBD();
?>
<html lang=ru>
	<head>
		<?php require_once  ("blocks/head.php");?>
	</head>
	<body>
	  	<?php
	  	require_once  ("blocks/header.php");
		require_once  ("blocks/menubar.php");
		require_once  ("blocks/menu.php");
		require_once  ("blocks/registrations.php");
		require_once  ("blocks/article.php");
		require_once  ("blocks/footer.php");
		?>
		</body>
</html>

<?php
	require_once 'function/connect.php'; // подключаем скрипт
	Connect();
	SelectBD("`menu item`");
	Close();    
?>

<form>
	<section>
		<menu class="NavBar">
			<?php 
			if(isset($_GET['AboutGame']) or empty($_GET))
			{
				$rows = mysqli_num_rows($result); 
			    $row = mysqli_fetch_row($result);
				echo $row[1];
				mysqli_free_result($result);
			}
			else if(isset($_GET['Counter']))
			{
				$rows = mysqli_num_rows($result);
				$row = mysqli_fetch_row($result);
			    $row = mysqli_fetch_row($result);
				echo $row[1];
				mysqli_free_result($result);
			}
			else if(isset($_GET['Download']))
			{
				$rows = mysqli_num_rows($result); 
				$row = GetString(3,$rows);
				echo $row[1];
				mysqli_free_result($result);
			}
			?>
		</menu>
	</section>		
</from>
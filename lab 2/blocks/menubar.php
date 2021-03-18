<form method="POST">
	<section>
		<menu class="NavBar">
			<?php 
			if(isset($_POST['AboutGame']) or empty($_POST))
			{
				echo '<li><button name = "AboutGame" class="CurrentPlace">Об игре</button>
				<li><button name="Counter">Обратный отсчёт</button>
				<li><button name="Download">Скачать</button>';
			}
			else if(isset($_POST['Counter']))
			{
				echo '<li><button name = "AboutGame">Об игре</button>
				<li><button name="Counter" class="CurrentPlace">Обратный отсчёт</button>
				<li><button name="Download">Скачать</button>';
			}
			else if(isset($_POST['Download']))
			{
				echo '<li><button name = "AboutGame">Об игре</button>
				<li><button name="Counter">Обратный отсчёт</button>
				<li><button name="Download" class="CurrentPlace">Скачать</button>';
			}
			?>
		</menu>
	</section>		
</from>
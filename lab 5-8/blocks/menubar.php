<form action="#">
	<section>
		<menu class="NavBar">
			<?php 
			if(isset($_GET['News']) or empty($_GET))
			{
				echo '
				<li><button name = "News" class="CurrentPlace">Новости</button>
				<li><button name="Counter">Обратный отсчёт</button>
				<li><button name="Download">Скачать</button>';
			}
			else if(isset($_GET['Counter']))
			{
				echo '
				<li><button name = "News">Новости</button>
				<li><button name="Counter" class="CurrentPlace">Обратный отсчёт</button>
				<li><button name="Download">Скачать</button>';
			}
			else if(isset($_GET['Download']))
			{
				echo '
				<li><button name = "News">Новости</button>
				<li><button name="Counter">Обратный отсчёт</button>
				<li><button name="Download" class="CurrentPlace">Скачать</button>';
			}
			else if(isset($_GET['Add']) or isset($_GET['Edit']) or isset($_GET['Del']))
			{
				
			}
			?>
		</menu>
	</section>		
</from>
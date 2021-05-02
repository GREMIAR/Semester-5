<section>
	<menu class="NavBar">
		<form action="#">
		<?php 
		if (isset($_GET["IDP"]))
		{
			echo '<input type="hidden" name="IDP" value="'; echo htmlspecialchars($_GET["IDP"]); echo'">';
		}
		if(isset($_GET["News"]) or empty($_GET))
		{
			echo '
			<li><button name = "News" class="CurrentPlace">Новости</button>
			<li><button name="Counter">Обратный отсчёт</button>
			<li><button name="Download">Скачать</button>
			';
		}
		else if(isset($_GET["Counter"]))
		{
			echo '
			<li><button name = "News">Новости</button>
			<li><button name="Counter" class="CurrentPlace">Обратный отсчёт</button>
			<li><button name="Download">Скачать</button>
			';
		}
		else if(isset($_GET["Download"]))
		{
			echo '
			<li><button name = "News">Новости</button>
			<li><button name="Counter">Обратный отсчёт</button>
			<li><button name="Download" class="CurrentPlace">Скачать</button>
			';
		}
		?>
		</form>
	</menu>
</section>
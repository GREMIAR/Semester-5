<section>
	<menu class="NavBar">
		<form  method="post" action="#">
		<?php
		if (isset($_POST["Edit"])){}
		else if(isset($_POST["News"]) or empty($_POST))
		{
			echo '
			<li><button name = "News" class="CurrentPlace">Новости</button>
			<li><button name="Counter">Обратный отсчёт</button>
			<li><button name="Download">Скачать</button>
			';
		}
		else if(isset($_POST["Counter"]))
		{
			echo '
			<li><button name = "News">Новости</button>
			<li><button name="Counter" class="CurrentPlace">Обратный отсчёт</button>
			<li><button name="Download">Скачать</button>
			';
		}
		else if(isset($_POST["Download"]))
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
<?php
	if(isset($_GET['News']) or empty($_GET))
	{
		echo '<center>
		<article class="ArticleMain">';
		ShowAllArticles();
		echo '</center>
		</article>';
	}
	else if(isset($_GET['Counter']))
	{
		require_once  ("blocks/modal.php");
		echo '
		<article class="ForCounter">

			<p>
				<br><div id="Modal"><a href="#" onclick="ModalOn()">До момента выхода оcталось</a></div></br>
				<br><center class="imgblock">
					<img src="image/ListC.png" alt="Дней" width="200" height="200">
					<span id="days"></span>
					<img src="image/ListC.png" alt="Часов" width="200" height="200">
					<span id="hours"></span>
					<img src="image/ListC.png" alt="Минут" width="200" height="200">
					<span id="minutes"></span>
					<img src="image/ListC.png" alt="Секунд" width="200" height="200">
					<span id="seconds"></span>
				</center>
			</p>
	  	</article>';
	}
	else if(isset($_GET['Download']))
	{
		echo '
		<article>
			<div class="ButtonDownload">
				<a href="https://github.com/GREBIAR-Git/NewGameSetup" target="_blank">
					<img src="image/download.png" alt="Скачать" width="50" height="50">Скачать для Windows
				</a>
			</div>
			<center><table>
				<caption><b style="font-size: 22px">Системные требования</b></caption>
				<tr>
					<th colspan="3">Минимальные</th>
					<th colspan="3">Рекомендуемые</th>
				</tr>
				<tr>
					<td colspan="2">ОС</td>
					<td>Windows 7/8/10 (64 bits)</td>
					<td colspan="2">ОС</td>
					<td>Windows 7/8/10 (64 bits)</td>
				</tr>
				<tr>
					<td rowspan="2">Процессор</td>
					<td>AMD</td>
					<td>FX-4100 (3.6 GHz)</td>
					<td rowspan="2">Процессор</td>
					<td>AMD</td>
					<td>FX-8350 (4.0 GHz)</td>
				</tr>
				<tr>
					<td>Intel</td>
					<td>Core i3-2125 (3.3 GHz)</td>
					<td>Intel</td>
					<td>Core i7-3820 (3.6 GHz)</td>
				</tr>
				<tr>
					<td colspan="2">ОЗУ</td>
					<td>4 GB RAM</td>
					<td colspan="2">ОЗУ</td>
					<td>8 GB RAM</td>
				</tr>
				<tr>
					<td rowspan="2">Видеокарта</td>
					<td>AMD</td>
					<td>Radeon R7 370</td>
					<td rowspan="2">Видеокарта</td>
					<td>AMD</td>
					<td>Radeon R9 280</td>
				</tr>
				<tr>
					<td>nVidia</td>
					<td>2 GB, GeForce GTX 660</td>
					<td>nVidia</td>
					<td>2 GB, GeForce GTX 760</td>
				</tr>
				<tr>
					<td colspan="2">Место на жёстком диске</td>
					<td>2 GB</td>
					<td colspan="2">Место на жёстком диске</td>
					<td>2 GB</td>
				</tr>
				</table>
			</center>
	  	</article>';
	}
	else if(isset($_GET['Add']))
	{
		echo'<article>';

		echo '<p>Заголовок</p><form action="#" class="navbar-form" role="search">
		<input type="text" name="pomogite" style = "width: 30%;">
		<p>Текст</p>
		<textarea name="hilfe" style = "resize: none;width: 30%;height:80px;" cols="91"></textarea>
		<p>Картинка</p>
		<input type="text" name="help" style = "width: 30%;">
		<br><br><button name="News" >Добавить</button></form>';
		echo'</article>';
	}
	else if (isset($_GET['Edit']))
	{
		echo'<article><p>Заголовок</p>';
		$row = SearchArticle($_GET['Edit'],'`article`');
		echo '<form action="#" class="navbar-form" role="search">
		<input type = "hidden" name = "ID" value ="';echo $row[0];echo'" >
		<input type="text" name="Heading" style = "width: 30%;" value="';echo $row[1];echo'" >
		<p>Текст</p>
		<textarea name="MainText" style = "resize: none;width: 30%;height:80px;" cols="91">';echo $row[2]; echo'</textarea>
		<p>Картинка</p>
		<input type="text" name="UrlImg" style = "width: 30%;"value="';echo $row[3];echo'">
		<br><br><button name="News" >Редактировать</button></form>';
		echo'</article>';
	}

?>

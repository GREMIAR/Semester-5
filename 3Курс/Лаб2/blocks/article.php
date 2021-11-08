<?php
	if (isset($_POST["Edit"]))
	{
		$row = SearchArticle($_POST["Edit"],"`article`");
		echo'
		<article>
			<form  method="post">
				<p>Заголовок</p>
				<input type="hidden" name="IDP"  style = "width: 30%;" value="';if (isset($_POST["IDP"])) echo htmlspecialchars($_POST["IDP"]);echo'" >
				<input type = "hidden" name = "ID" value ="';echo $row[0];echo'" >
				<input type="text" name="Heading" value="';echo $row[1];echo'" >
				<p>Текст</p>
				<textarea name="MainText" style = "resize: none;width: 30%;height:80px;" cols="91">';echo $row[2]; echo'</textarea>
				<p>Картинка</p>
				<input type="text" name="UrlImg" style = "width: 30%;"value="';echo $row[3];echo'">
				<br><br><button name="News" >Редактировать</button>
			</form>
		</article>';
	}
	else if(isset($_POST["News"]) or empty($_POST))
	{
		echo '
		<article class="ArticleMain">
			<center>';
			ShowAllArticles();
			echo '
			</center>
		</article>';
	}
	else if(isset($_POST["Counter"]))
	{
		require_once ("blocks/modal.php");
		echo '
		<article class="ForCounter">
			<br><div id="Modal"><a onclick="ModalOn()">До момента выхода оcталось</a></div></br>
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
	  	</article>
	  	<script type="text/javascript" src="function/js/Counter.js"></script>';
	}
	else if(isset($_POST["Download"]))
	{
		echo '
		<article>';
			if (isset($_SESSION["name"]))
			{
				echo '
				<div class="ButtonDownload">
					<a href="https://github.com/GREBIAR-Git/NewGameSetup" target="_blank">
						<img src="image/download.png" alt="Скачать" width="50" height="50">Скачать для Windows
					</a>
				</div>';
			}
			else
			{
				echo '
				<p>Чтобы скачать зарегестируетесь</p>';
			}
			echo '
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



	  	</article><div id="insertCommits" data-page="0"></div>';
	  	
	}
	else if(isset($_POST["Add"]))
	{
		echo'
		<article>
			<p>Заголовок</p>
			<form  method="post">
				<input type="hidden" name="IDP" value="';if (isset($_POST["IDP"])) {echo htmlspecialchars($_POST["IDP"]);}echo'" >
				<input type="text" name="Heading" style = "width: 30%;">
				<p>Текст</p>
				<textarea name="MainText" style = "resize: none;width: 30%;height:80px;" cols="91"></textarea>
				<p>Картинка</p>
				<input type="text" name="UrlImg" style = "width: 30%;">
				<br><br><button name="News" >Добавить</button>
			</form>
		</article>';
	}

?>
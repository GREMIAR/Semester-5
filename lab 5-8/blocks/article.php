<?php 
	if(isset($_GET['AboutGame']) or empty($_GET))
	{
		echo '
		<article class="ArticleMain">
			<p id="text_change"><br><center><img src="image/Pic1.jpg" alt="Привет пацаны"></center><br><div class = "text"><a class = "anchor" name="Mid"></a>NewGame — революция в жанре РПГ. Ваш персонаж — детектив с уникальными навыками, которому предстоит исследовать целый район. Допрашивайте незабываемых персонажей, расследуйте убийства или берите взятки. Кем вы станете: героем или неудачником?</div><br><center><img src="image/Pic2.jpg" alt="Иди покакай"></center><br><div class = "text"></p>
		</article>';
	}
	else if(isset($_GET['Counter']))
	{
		echo '
		<article class="Mainarticle">
			<p><b>До момента выхода оcталось</b><br><center><img src="image/ListC.png" alt="Дней" width="200" height="200"><img src="image/ListC.png" alt="Часов" width="200" height="200"><img src="image/ListC.png" alt="Минут" width="200" height="200"><img src="image/ListC.png" alt="Секунд" width="200" height="200"></center></p>
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
?>
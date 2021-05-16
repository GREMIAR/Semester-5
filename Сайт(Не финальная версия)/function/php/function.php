<?php
	function EditBD()
	{
		if(isset($_GET["ID"]))
		{
			$articleName = htmlspecialchars($_GET["Heading"]);
			$textiq = htmlspecialchars($_GET["MainText"]);
			$imageURLs = htmlspecialchars($_GET["UrlImg"]);
			$IDarticle = htmlspecialchars($_GET["ID"]);
			Connect();
			global $link;
			$sql = "UPDATE article SET Nomen='$articleName',Textiq='$textiq',ImageURL='$imageURLs' WHERE IDarticle=$IDarticle";
			$link->query($sql);
			Close();
			OnlyIDPeople();
		}
		else if (isset($_GET["Del"]))
		{
			$IDarticle = htmlspecialchars($_GET["Del"]);
			Connect();
			global $link;
			$sql = "DELETE FROM article WHERE IDarticle='$IDarticle'";
			$link->query($sql);
			Close();
			OnlyIDPeople();
		}
		else if(isset($_GET["Heading"]) and isset($_GET["MainText"]) and isset($_GET["UrlImg"]))
		{
			$articleName = htmlspecialchars($_GET["Heading"]);
			$textiq = htmlspecialchars($_GET["MainText"]);
			$imageURLs = htmlspecialchars($_GET["UrlImg"]);
			Connect();
			global $link;
			$sql = "INSERT INTO article (Nomen, Textiq, ImageURL) VALUES ('$articleName', '$textiq', '$imageURLs')";
			$link->query($sql);
			Close();
			OnlyIDPeople();
		}
		if (isset($_GET["pswrd"]) and isset($_GET["lg"]) and isset($_GET["next"]) and $_GET["sign"]==="in")
		{
			$lg = htmlspecialchars($_GET["lg"]);
			$password = htmlspecialchars($_GET["pswrd"]);
			Connect();
			global $link;
			global $result;
			$sql = "SELECT * FROM `accounts` WHERE `Login` = '$lg' AND `Password` = '$password'";
			$result = mysqli_query($link, $sql) or die("Ошибка " . mysqli_error($link));
			$rows = mysqli_num_rows($result);
			if($rows === 0)
			{
				OnlyIDPeople();
				return;
			}
			for($i=1;$i<=$rows;$i++)
			{
				$row = mysqli_fetch_row($result);
				if($row[0]==$lg)
				{
					break;
				}
			}
			$url = strtok(GetURL(), '?');
			$url .='?IDP='.$row[0];
			if(isset($_GET["News"]))
			{
				$url.='&News=';
			}
			else if(isset($_GET["Counter"]))
			{
				$url.='&Counter=';
			}
			else if(isset($_GET["Download"]))
			{
				$url.='&Download=';
			}
			else
			{
				$url.='&News=';
			}
			header ('Location: '.$url);
			Close();
		}
		else if(isset($_GET["pswrd"]) and isset($_GET["lg"]) and isset($_GET["next"]) and $_GET["sign"]==="up")
		{
			$lg = htmlspecialchars($_GET["lg"]);
			$password = htmlspecialchars($_GET["pswrd"]);
			Connect();
			global $link;
			global $result;
			$sql = "SELECT * FROM `accounts` WHERE `Login` = '$lg'";
			$result = mysqli_query($link, $sql) or die("Ошибка " . mysqli_error($link));
			$row_count = mysqli_num_rows($result);
			if($row_count === 0)
			{
				$sql = "INSERT INTO accounts (Role, Login,Password ) VALUES (1,'$lg', '$password')";
				$result = mysqli_query($link, $sql) or die("Ошибка " . mysqli_error($link));
			}
			Close();
		}
	}

	function OnlyIDPeople()
	{
		$url = strtok(GetURL(), '?');
		if(isset($_GET["IDP"]))
		{
			$IDP = htmlspecialchars($_GET["IDP"]);
			$url .='?IDP='.$IDP;
			if(isset($_GET["News"]))
			{
				$url.='&News=';
			}
			else if(isset($_GET["Counter"]))
			{
				$url.='&Counter=';
			}
			else if(isset($_GET["Download"]))
			{
				$url.='&Download=';
			}
			else if(isset($_GET["Del"]))
			{
				$url.='&News=';
			}
		}
		else
		{
			if(isset($_GET["News"]))
			{
				$url.='?News=';
			}
			else if(isset($_GET["Counter"]))
			{
				$url.='?Counter=';
			}
			else if(isset($_GET["Download"]))
			{
				$url.='?Download=';
			}
			else if(isset($_GET["Del"]))
			{
				$url.='?News=';
			}
		}


		header ('Location: '.$url);
	}

	function GetURL()
	{
	    if(isset($_SERVER['HTTPS']) && $_SERVER['HTTPS'] === 'on')
	         $url = "https://";
	    else
	         $url = "http://";
	    $url.= $_SERVER['HTTP_HOST'];
	    $url.= $_SERVER['REQUEST_URI'];
	    return $url;
	}

	function ShowAllArticles()
	{
		if (isset($_GET["IDP"]))
		{
			$role = Role();
		}
		global $result;
		Connect();
		SelectBD("article");
		$rows = mysqli_num_rows($result);
		$articleWithStyle;
		echo '
		<form>
			<a name="Mid" class="anchor"></a>';

			if (isset($_GET["IDP"]))
			{
				echo '<input type="hidden" name="IDP" value="'; echo htmlspecialchars($_GET["IDP"]); echo'">';
				if($role == 3)
				{
					echo '<br><button class="buttonArticle" name = "Add">Добавить</button>';
				}
			}
			echo'
		</form>
		<div id="content">';
			for ($i=$rows; $i > 0; $i--)
			{
				echo'
				<div class="block">';
					$articleWithStyle = "<br><div class = 'articleName'>";
					$row = mysqli_fetch_row($result);
					$articleWithStyle.= $row[1];
					$articleWithStyle.="</div><br>";
					echo $articleWithStyle;
					$articleWithStyle = "<div class = 'text'>";
					$articleWithStyle.=$row[2];
					$articleWithStyle.="</div><br>";
					echo $articleWithStyle;
					if ($row[3]!=='')
					{
						$articleWithStyle = "<img src=";
						$articleWithStyle.=$row[3];
						$articleWithStyle.=">";
						echo $articleWithStyle;
					}
					echo '
					<form>';
						if (isset($_GET["IDP"]))
						{
							echo '<input type="hidden" name="IDP" value="'; echo htmlspecialchars($_GET["IDP"]); echo'">';
							if($role == 3 or $role == 2)
							{
								echo '
								<br><button class="buttonArticle" name = "Edit" value = "';echo $row[0];echo'">Редактировать</button>
								<button class="buttonArticle" name = "Del" value = "';echo $row[0];echo '">Удалить</button>';
							}
						}
					echo'
					</form>
					<br><br>
				</div>';
			}
		echo '
		</div>
		<div id="pagination"></div>';
	}

	function SearchArticle($IDarticle,$nameBD)
	{
		Connect();
		global $link,$result;
		$query ="SELECT * FROM" . $nameBD;
		$result = mysqli_query($link, $query) or die("Ошибка " . mysqli_error($link));
		Close();
		global $result;
		$rows = mysqli_num_rows($result);
		for($i=1;$i<=$rows;$i++)
		{
			$row = mysqli_fetch_row($result);
			if($row[0]==$IDarticle)
			{
				return $row;
			}
		}
	}

	function SelectBD($nameTable)
	{
		global $link,$result;
		$query ="SELECT * FROM " . $nameTable . " ORDER BY -IDarticle";
		$result = mysqli_query($link, $query) or die("Ошибка " . mysqli_error($link));
	}

	function Role()
	{
		Connect();
		global $link;
		global $result;
		$IDP = htmlspecialchars($_GET["IDP"]);
		$sql = "SELECT * FROM `accounts` WHERE `IDP` = '$IDP'";
		$result = mysqli_query($link, $sql) or die("Ошибка " . mysqli_error($link));
		$rows = mysqli_num_rows($result);
		$row = mysqli_fetch_row($result);
		Close();
		return $row[1];
	}
?>
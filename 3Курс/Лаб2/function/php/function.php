<?php
	function EditBD()
	{
		session_start();
		if(isset($_POST["ID"]))
		{
			$articleName = htmlspecialchars($_POST["Heading"]);
			$textiq = htmlspecialchars($_POST["MainText"]);
			$imageURLs = htmlspecialchars($_POST["UrlImg"]);
			$IDarticle = htmlspecialchars($_POST["ID"]);
			Connect();
			global $link;
			$sql = "UPDATE article SET Nomen='$articleName',Textiq='$textiq',ImageURL='$imageURLs' WHERE IDarticle=$IDarticle";
			$link->query($sql);
			Close();
		}
		else if (isset($_POST["Del"]))
		{
			$IDarticle = htmlspecialchars($_POST["Del"]);
			Connect();
			global $link;
			$sql = "DELETE FROM article WHERE IDarticle='$IDarticle'";
			$link->query($sql);
			Close();
		}
		else if(isset($_POST["Heading"]) and isset($_POST["MainText"]) and isset($_POST["UrlImg"]))
		{
			$articleName = htmlspecialchars($_POST["Heading"]);
			$textiq = htmlspecialchars($_POST["MainText"]);
			$imageURLs = htmlspecialchars($_POST["UrlImg"]);
			Connect();
			global $link;
			$sql = "INSERT INTO article (Nomen, Textiq, ImageURL) VALUES ('$articleName', '$textiq', '$imageURLs')";
			$link->query($sql);
			Close();
		}
		if (isset($_POST["pswrd"]) and isset($_POST["lg"]) and isset($_POST["next"]) and $_POST["sign"]==="in")
		{
			$lg = htmlspecialchars($_POST["lg"]);
			$password = htmlspecialchars($_POST["pswrd"]);
			Connect();
			global $link;
			global $result;
			$sql = "SELECT * FROM `accounts` WHERE `Login` = '$lg' AND `Password` = '$password'";
			$result = mysqli_query($link, $sql) or die("Ошибка " . mysqli_error($link));
			$rows = mysqli_num_rows($result);
			if($rows === 0)
			{
				Close();
				return;
			}
			for($i=1;$i<=$rows;$i++)
			{
				$row = mysqli_fetch_row($result);
				if($row[2]==$lg)
				{
					$_SESSION['role'] = $row[1];
					$_SESSION['name'] = $row[2];
					break;
				}
			}
			Close();
		}
		else if(isset($_POST["pswrd"]) and isset($_POST["lg"]) and isset($_POST["next"]) and $_POST["sign"]==="up")
		{
			$lg = htmlspecialchars($_POST["lg"]);
			$password = htmlspecialchars($_POST["pswrd"]);
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
		else if(isset($_POST["exit"]))
		{
			session_destroy();
			$url = strtok(GetURL(), '?');
			header ('Location: '.$url);
		}
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
		if (isset($_SESSION["role"]))
		{
			$role = $_SESSION["role"];
		}
		global $result;
		Connect();
		SelectBD("article");
		$rows = mysqli_num_rows($result);
		$articleWithStyle;
		echo '
		<form method="post">
			<a name="Mid" class="anchor"></a>';

			if (isset($_SESSION["role"]))
			{
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
					<form  method="post"><input type="hidden" name="News">';
						if (isset($_SESSION["role"]))
						{
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
		$IDP = htmlspecialchars($_POST["IDP"]);
		$sql = "SELECT * FROM `accounts` WHERE `IDP` = '$IDP'";
		$result = mysqli_query($link, $sql) or die("Ошибка " . mysqli_error($link));
		$rows = mysqli_num_rows($result);
		$row = mysqli_fetch_row($result);
		Close();
		return $row[1];
	}
?>
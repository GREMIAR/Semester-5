<?php 
	function GetString($num,$rows)
	{
		global $result;
		for($i=1;$i<=$rows;$i++)
		{
			$row = mysqli_fetch_row($result);
			if($i==$num)
			{
				return $row;
			}
		}
	}

	function SearchByMenuItem($idMenu,$nameBD)
	{
		Connect();
		SelectBD($nameBD);
		Close(); 
		global $result;
		$rows = mysqli_num_rows($result);
		for($i=1;$i<=$rows;$i++)
		{
			$row = mysqli_fetch_row($result);
			if($row[0]==$idMenu)
			{
				return $row[1];
			}
		}
	}

	function SearchByElemente($idMenu,$nameBD,$column)
	{
		Connect();
		SelectBD($nameBD);
		Close(); 
		global $result;
		$rows = mysqli_num_rows($result);
		for($i=1;$i<=$rows;$i++)
		{
			$row = mysqli_fetch_row($result);
			if($row[0]==$idMenu)
			{
				return $row[$column];
			}
		}
	}

	function SelectBD($nameTable)
	{
		global $link,$result;
		$query ="SELECT * FROM" . $nameTable;
		$result = mysqli_query($link, $query) or die("Ошибка " . mysqli_error($link)); 
	} 

	function Head($idIM)
	{
		$idHead=SearchByMenuItem($idIM,"`head_пункт_меню`");
		global $headstr;
		$headstr=SearchByElemente($idHead,"`head`",1);
	}

	function Menu($idIM)
	{
		$idHead=SearchByMenuItem($idIM,"`пункт_навигации_пункт_меню`");
		global $menustr;
		$menustr=SearchByElemente($idHead,"`пункт_навигации`",1);
	}

	function SiteHeader($idIM)
	{
		$idHead=SearchByMenuItem($idIM,"`header_footer_menu_item`");
		global $headerstr;
		$headerstr=SearchByElemente($idHead,"`header_footer`",1);
	}

	function Artical($idIM)
	{
		$idHead=SearchByMenuItem($idIM,"`статья_пункт_меню`");
		global $articalstr;
		$articalstr=SearchByElemente($idHead,"`article`",1);
	}

	function Footer($idIM)
	{
		$idHead=SearchByMenuItem($idIM,"`header_footer_menu_item`");
		global $footerstr;
		$footerstr=SearchByElemente($idHead,"`header_footer`",2);
	}

	function SelectItemMenu($idIM)
	{
		global $result;
		global $itemMenu;
		global $menubarstr;
		$rows = mysqli_num_rows($result); 
	    $row = GetString($idIM,$rows);
	    Head($row[0]);
	    SiteHeader($row[0]);
	    Menu($row[0]);
	    Artical($row[0]);
	    Footer($row[0]);
	    $itemMenu=$row[0];
		$menubarstr=$row[1];
		mysqli_free_result($result);
	}

	function ReactToPressedButton()
	{
		Connect();
		SelectBD("`menu item`");
		Close(); 
		if(isset($_GET['AboutGame']) or empty($_GET))
		{
			SelectItemMenu(1);
		}
		else if(isset($_GET['Counter']))
		{
			SelectItemMenu(2);
		}
		else if(isset($_GET['Download']))
		{
			SelectItemMenu(3);
		}
	}
?>



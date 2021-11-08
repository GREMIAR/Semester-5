<?php
require_once 'connect.php';
$comment = $_GET['comment'];
Connect();
global $link;
$sql = "Select text,author,time FROM comment WHERE id>".$comment;
$result = mysqli_query($link, $sql) or die("Ошибка " . mysqli_error($link));
$rows = mysqli_num_rows($result);
if($rows === 0)
{
	Close();
	return;
}
$stringBeg = '<div class="comment"><p style="size=14px;font-weight: bold;">';
$stringMid = '</p><p>';
$stringEnd = '</p></div>';
$stringMain = '';
for($i=0;$i<=$rows-1;$i++)
{
	if($i==3)
	{
		break;
	}
	$row = mysqli_fetch_row($result);
	$stringMain .= $stringBeg;
	if($row[1]!="")
	{
		$stringMain .= $row[1];
	}
	else
	{
		$stringMain .= "Гость";
	}
	
	$stringMain .= $stringMid;
	$stringMain .= $row[0];
	$stringMain .= $stringMid;
	$stringMain .= $row[2];
	$stringMain .= $stringEnd;
	$comment++;
}
echo  $stringMain;
?>
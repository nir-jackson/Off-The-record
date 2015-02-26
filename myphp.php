<?php

header('Content-Type: text/html; charset=utf-8;ISO-8859-1;windows-1255'); 
$word = $_REQUEST['word'];
error_reporting(E_ERROR);
$pol = file_get_contents("polijson.txt");
$jsonpol = json_decode($pol,true);
$arraylength = count($jsonpol['array']);
echo '[';
$counter = 0;
for($x = 0; $x < $arraylength; $x++) {
	$temp = null;
	//$name = iconv ('UTF-8', 'windows-1255',  "json1/" . $jsonpol['array'][$x] . "/" . $word . ".txt" );
	$temp = file_get_contents("json1/" . $jsonpol['array'][$x] . "/" . $word . ".txt");
	$tempcount = strlen($temp);
	if ($temp == '' ){
		
	}  else{
		for ($i = 0; $i < $tempcount; $i++){
			if (($temp[$i] == ']')&&($temp[$i+1] == '[')){
				$temp = substr($temp, 0, $i+1);
			}
		}
		if($counter == 0){
			echo '{"id":"' . $jsonpol['array'][$x] . '","resarr":';
			//echo '"'. $jsonpol['array'][$x] . '{"resarr":';
		}else{
			echo ',{"id":"' . $jsonpol['array'][$x] . '","resarr":';
		}
    	echo $temp;
		
		echo '}';
		$counter++;
	}
   
}

echo ']';

$path = "json1";
$data = array();

?>

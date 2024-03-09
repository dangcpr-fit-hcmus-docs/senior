<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
<script type="text/javascript" language="javascript">
	var xmlHttp;
	function CreateXMLHttpRequest()
	{
		if ( window.XMLHttpRequest )
		{
			 // code for IE7+, Firefox, Chrome, Opera, Safari
			return new XMLHttpRequest()
		}
		else if (window.ActiveXObject )
		{
			 // code for IE6, IE5
			return new ActiveXObject("Microsoft.XMLHTTP")
		}
	}
	
	
	function btnSearch()
	{
        //alert('');
		xmlHttp = CreateXMLHttpRequest();
		
		xmlHttp.onreadystatechange = showResult;
		
		var keyword = document.getElementById('keyword').value;
		
		var serverURL = 'ajax_search_nhanvien.php?q=' + encodeURI(keyword) + "&t=" + (new Date()).getTime();
		
		//var serverURL = 'AJAX.php?q=' + keyword	+ "&t=" + (new Date()).getTime();
		
		xmlHttp.open("get", serverURL, true);
		
		xmlHttp.send(null);
		
	}
	
	function showResult()
	{
		if(xmlHttp.readyState == 4 && xmlHttp.status == 200)
		{
			var kq = xmlHttp.responseText;
			                        
			document.getElementById("divResult").innerHTML = kq;
									
								
		}
	}
	
	
	function checkAll()
	{
		
		var list = window.document.getElementsByName("chkItem");
		
		for(var i =0; i < list.length; i++)
		{
			list[i].checked = document.getElementsByName('chkAll')[0].checked;
		}
		//alert(list.length);
		updateList();
	}
	
	function updateList()
	{
		var list = document.getElementsByName('chkItem');
		var s = "";
		for(var i =0; i < list.length; i++)
		{
			if (list[i].checked)
			{
				s = s + list[i].value + ",";
			}
		}
		
		document.getElementById("txtList").value = s;
	}
</script>
</head>
<body>
Keyword: <input type="text" id='keyword' onkeyup='btnSearch();'/>

<input type="button" value="search" onclick='btnSearch();' />

<input type="hidden" id='txtList'/>


<div id="divResult">
	
</div>

<input type="button" value="delete" onclick='btnDelete();' />

</body>
</html>

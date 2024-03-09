<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
	#livesearch
	{
		width:1000px;
	}
	.mark {background-color:yellow;}
	.hidden { display:none;
	position:absolute;}
	.visible { visibility:visible;
		position:absolute;
		top: 200px;
		background-color:#9CC;
		text-align:center;
		border: thin solid #006;
		color:#00F;
                z-index: 0;}
</style>
<script language="javascript" type="text/javascript">
var xmlhttp1;
var xmlhttp2;

function createXMLHttpRequest()
{
	var xmlhttp;	
	if (window.XMLHttpRequest)
	{// code for IE7+, Firefox, Chrome, Opera, Safari
		xmlhttp=new XMLHttpRequest();
	}
	else
	{// code for IE6, IE5
		xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
	}
	return xmlhttp;
}

function showResult(str)
{
	if (str.length==0)
  	{ 
    	document.getElementById("livesearch").innerHTML="";
    	document.getElementById("livesearch").style.border="0px";
    	return;
  	}
	
  	xmlhttp1 = createXMLHttpRequest();
  
	xmlhttp1.onreadystatechange=function()
  	{
        if (xmlhttp1.readyState==4 && xmlhttp1.status==200)
        {
			document.getElementById("livesearch").innerHTML=xmlhttp1.responseText;
			document.getElementById("livesearch").style.border="0px";			
            document.getElementById("divImg").className = "hidden";
        }
  	}
	var serverURL = 'ajax_search_nhanvien.php?q=' + encodeURI(str) + "&t=" + (new Date()).getTime();
	xmlhttp1.open("GET",serverURL,true);
	xmlhttp1.send();
}

function search()
{
	//alert('');
	
	var key = document.getElementById("txtKeyWord").value;
	
	//alert(e.mouseX);
	showResult(key);
}

function DeleteARow(str)
{
	console.log("hee");
	xmlhttp2 = createXMLHttpRequest();
  	
	xmlhttp2.onreadystatechange = callback_DeleteARow;
	
	var serverURL = "ajax_delete.php?q="+ str + "&t=" + (new Date()).getTime();
	console.log(serverURL);
	xmlhttp2.open("GET", serverURL, true);
	
	xmlhttp2.send();
	
	//var serverURL = "delete.php";
	//var params = "q="+ str + "&t=" + (new Date()).getTime();
	//alert(params);
	//xmlhttp2.open("POST",serverURL,true);
	//xmlhttp2.setRequestHeader("Content-Type", "text/xml");
	//xmlhttp2.setRequestHeader("Content-Length", params.length);
	//xmlhttp2.setRequestHeader("Connection", "close");
	//xmlhttp2.send(params);
}

function sleep(ms)
{
        var dt = new Date();
        dt.setTime(dt.getTime() + ms);
        while (new Date().getTime() < dt.getTime());
}


function callback_DeleteARow()
{
    
    //alert(xmlhttp2.readyState + ":" + xmlhttp2.status);
    document.getElementById("divImg").className = "visible";

    

    if (xmlhttp2.readyState==4 && xmlhttp2.status==200)
    { 	

            //alert(xmlhttp2.responseText);

            var key = document.getElementById("txtKeyWord").value;
            sleep(2000);
            showResult(key);


    } 
    
}	

</script>

<script language="javascript" type="text/javascript"> 
    function CheckAll()
    {
        var list = document.getElementsByName("checkItem");
        //alert(list.length);
        var i;
        for(i = 0; i < list.length; i++)
        {
                list[i].checked = document.getElementsByName("checkall")[0].checked;
        }
    }
	

</script>

</head>
<body>
<form>
    <div id="divImg" class="hidden" style="width:1000px; background-color:#FFC">
    	 <img src="loading.gif" style="width:  50px"/>
         <br/>..... đang xóa .....          
    </div>
   
    Keyword for filter: <input id="txtKeyWord" type="text" size="30" />
    <input type="button" value="Search" onclick="search();"/>
    <div id="livesearch">

    </div>
</form>
</body>
</html>


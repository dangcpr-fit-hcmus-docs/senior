<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Demo jQuery</title>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>

<script>

	$(document).ready(function(){


	  // 	$("#btnSearch").click(function(){

			// let keyword = $("#keyword").val();
			// let serverURL = 'ajax_search_nhanvien.php?q=' + encodeURI(keyword) + "&t=" + (new Date()).getTime();
			// // Cách 1
			// // $("#divResult").load(serverURL);

			// // Cách 2
			// var settings = {
			//   "async": true,
			//   "url": serverURL ,
			//   "method": "GET",			  
			//   "processData": false,
			//   "data": ""
			// };

			// $.ajax(settings).done(function (response) {
			//   $("#divResult").html(response);
			// });

	  // 	});

	  	let load_data = function()
	  	{
	  		let keyword = $("#keyword").val();
			let serverURL = 'ajax_search_nhanvien.php?q=' + encodeURI(keyword) + "&t=" + (new Date()).getTime();
			// Cách 1
			// $("#divResult").load(serverURL);

			// Cách 2: Tổng quát hơn
			var settings = {
			  async: true,
			  url: serverURL ,
			  type: "get",
			  cache: false,
			};

			$.ajax(settings).done(function (response) {
			  	$("#divResult").html(response);
			});
	  	};

		let load_data2 = function()
		{
			let keyword = $("#keyword").val();
			let serverURL = 'ajax_search_nhanvien.php?q=' + encodeURI(keyword) + "&t=" + (new Date()).getTime();
			$.ajax({
                url: serverURL,
                type: 'get',                
                cache: false,      
                success: function (response) {
                    $("#divResult").html(response);
					// console.log(response);
                }
            });
		}

	  	$("#keyword").keyup(load_data2);	
	  	$("#btnSearch").click(load_data2);
	});
</script>

</head>
<body>
Keyword: <input type="text" id='keyword' />

<input id="btnSearch" type="button" value="search" />
<div id="divResult">	
</div>
</body>
</html>

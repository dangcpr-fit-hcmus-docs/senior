<?php
	$q = $_REQUEST['q'];
	
	echo "Result for <b>$q</b>: <hr/>";
	
	require("dbconnect.php");
	
	$checkbox_all = "<input type='checkbox' name='chkAll' onclick='checkAll();'/>";

	$response = "<table border='1'>";
	$response = $response."<tr>
							<th>$checkbox_all</th>
							<th>MSSV</th>	
							<th>Họ tên</th>
							<th>Ngày sinh</th>
							<th>Địa chỉ</th>
							<th>Điện thoại</th> 
							<th>Mã Khoa</th>
						   <th></th>						
						   </tr>";
	
							

	$mysqli = connect();
    $mysqli->query("SET NAMES utf8");
    $query = "SELECT * FROM SINHVIEN Where HoTen LIKE '%$q%'";
    $result = $mysqli->query($query);

    if ($result) 
    {            
        foreach ($result as $row) {
            $mssv = $row["MSSV"];
			$hoten = $row["HoTen"];
			$ngaysinh = $row["NgaySinh"];
			$diachi = $row["DiaChi"];
			$dienthoai = $row["DienThoai"];
			$makhoa = $row["MaKhoa"];
			
			$checkbox_area = "<input type='checkbox' name='chkItem' value='$mssv' onclick='updateList();'/>";
			
			$delete_button = "<form action='DSSV.php' method='get'>
								<input type='hidden' value='$mssv' name='mssv'/>
								<input type='submit' value='Delete' name='Delete'/>
								
							  </form>";
			$response = $response."<tr>
								<td>$checkbox_area</td>
								<td>$mssv</td>
								<td>$hoten</td>
								<td>$ngaysinh</td>
								<td>$diachi</td>							
								<td>$dienthoai</td>							
								<td>$makhoa</td>
								<td>$delete_button</td>

							   </tr>";
        }
    }
        

	$response = $response."</table>";	
	$mysqli->close();
	echo $response;
?>
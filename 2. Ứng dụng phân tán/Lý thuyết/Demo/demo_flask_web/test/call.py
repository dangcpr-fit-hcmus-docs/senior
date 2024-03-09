# import requests
#
# url = "http://0.0.0.0:9999/test/"
#
# payload={}
# files=[]
# headers = {}
#
# response = requests.request("GET", url, headers=headers, data=payload, files=files)
#
# print(response.text)


######
# import requests
#
# url = "http://0.0.0.0:9999/tinh_tong/?a=4&b=100"
#
# headers = {}
#
# response = requests.request("GET", url, headers=headers, data={}, files=[])
#
# print(response.text)


import requests

url = "http://0.0.0.0:9999/tinh_nhan/"

payload={'a': '10',
'b': '20'}
files=[

]
headers = {}

response = requests.request("POST", url, headers=headers, data=payload, files=files)

print(response.text)

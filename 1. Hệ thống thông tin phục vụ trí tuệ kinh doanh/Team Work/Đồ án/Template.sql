/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Invoice ID]
      ,[Branch]
      ,[Customer type]
      ,[Gender]
      ,[ProductID]
      ,[Quantity]
      ,[Tax 5%]
      ,[Total]
      ,[Date]
      ,[Time]
      ,[Payment]
      ,[cogs]
      ,[gross margin percentage]
      ,[gross income]
      ,[Rating]
      ,[Create_at]
      ,[Update_at]
  FROM [SuperSale_Source].[dbo].[supermarket_sales$]
  WHERE create_at > '2024-01-03 18:04:17.977' AND create_at <= GETDATE();
use [SuperSale_Source]
GO
UPDATE [supermarket_sales$]
SET create_at = '2020-01-03 18:04:17.977', update_at = GETDATE()
WHERE [Invoice ID] = '651-88-7329'

select getdate()
use [SuperSale_Metadata]
GO
SELECT LSET, CET FROM DATA_FLOW WHERE name = 'sales_a'
UPDATE DATA_FLOW SET CET = GETDATE() WHERE [name] = 'sales_a'

SELECT LSET, CET FROM DATA_FLOW WHERE name = 'sales_a'
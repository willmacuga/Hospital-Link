﻿USE [C:\USERS\WILLAIM\DOCUMENTS\HOSPITALDB.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Search]

SELECT	@return_value as 'Return Value'

GO

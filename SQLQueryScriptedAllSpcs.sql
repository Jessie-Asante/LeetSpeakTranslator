USE [TranslatorDb]
GO
/****** Object:  StoredProcedure [dbo].[spcCreateTranslatedText]    Script Date: 06/04/2024 23:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spcCreateTranslatedText]
@datafield nvarchar(50)
as
begin 
	insert into TblConvertStrings (DataField) values (@datafield)
end;

GO
/****** Object:  StoredProcedure [dbo].[spcGetTranslatedText]    Script Date: 06/04/2024 23:16:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spcGetTranslatedText]

as
begin transaction
	select UserIDpk,trim(lower(replace(DataField,'""','''')))DataField 
	from TblConvertStrings
commit transaction;

GO

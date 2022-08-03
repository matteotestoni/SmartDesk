
        
-- Get XML Struttura Tabella
Declare @Table varchar(90) = '{Table}' ,@Schema varchar(90) ='{Schema}'
--select  @Table='Anagrafiche', @Schema='dbo'

select '<SqlTable>'
select 
		'<Tables Catalog="" '  ----' + TABLE_CATALOG +'" '
		+'Schema="'+ TABLE_SCHEMA +'" '
		+'Name="' + TABLE_NAME +'" ' 
		+'Type="'+ replace(Table_TYPE,'base ','') +'" '
		+'>'
From   INFORMATION_SCHEMA.TABLES 
where   Table_Name in (@Table)

select '<Keys>'
select '<Key Column="' + COLUMN_NAME +'" '
		+'Type="'+ t.Constraint_Type +'" '
		+'/>'
from INFORMATION_SCHEMA.KEY_COLUMN_USAGE k 
	 left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS t
	 on t.CONSTRAINT_CATALOG=k.CONSTRAINT_CATALOG and  t.CONSTRAINT_SCHEMA = k.CONSTRAINT_SCHEMA and t.CONSTRAINT_NAME=k.CONSTRAINT_NAME 
where  k.Table_Name in (@Table)
select '</Keys>'
select '<Fields>'
select 
		'<Field Column="' + COLUMN_NAME +'" '
	--	+'Position="'+convert(varchar(20),Ordinal_Position) +'" '
		+'IsNull="' + left(IS_Nullable,1) +'" ' 
		+'Type="'+ DATA_TYPE  +'" '
		+(case when  DATA_TYPE not in('date','datetime','smalldatetime' ,'float','bit','int','smallint','money','tinyint','bigint') then 
			'Lenght="'+ convert(varchar(20),(case when CHARACTER_MAXIMUM_LENGTH is null then NUMERIC_PRECISION else  CHARACTER_MAXIMUM_LENGTH end))  +'" '
		  	+(case when CHARACTER_MAXIMUM_LENGTH is null then 'Decimal="'+ convert(varchar(20), NUMERIC_SCALE ) +'" ' else '' --'Decimal=""'
			 end)
		else ''--'Lenght="" Decimal=""'
		 end)
		+'/>'
from INFORMATION_SCHEMA.COLUMNS 
 where   Table_Name in (@Table)
ORDER BY ORDINAL_POSITION

select '</Fields>'
select '</Tables>'
 
-- Table
select '<SqlScriptCreate>'+char(13)+dbo.Get_Table_Script(@Schema,@Table) +char(13)+'</SqlScriptCreate>' 
-- View
SELECT '<SqlScriptCreate>' + definition +'</SqlScriptCreate>' FROM sys.sql_modules WHERE object_id = OBJECT_ID(@Schema+'.'+@Table); 

select '</SqlTable>'

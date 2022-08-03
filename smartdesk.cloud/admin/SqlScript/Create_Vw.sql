

select replace(
'		-- $Table_Name$
        create view dbo.$Table_Name$_Vw as 
        select * from $Table_Name$ where $Table_Name$_DateDelete is null;
GO

'
,'$Table_Name$'
,a.TABLE_NAME
)
--select * 
From (select TABLE_NAME from	INFORMATION_SCHEMA.TABLES  where table_type='base table') a left join (select replace(TABLE_NAME,'_vw','') TABLE_NAME,TABLE_NAME Table_View from	INFORMATION_SCHEMA.TABLES a where table_type='view') b on a.TABLE_NAME = b.TABLE_NAME
where b.Table_View is null

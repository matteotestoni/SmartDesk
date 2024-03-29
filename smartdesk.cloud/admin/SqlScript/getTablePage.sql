USE [Db_Rsw]
GO
/****** Object:  StoredProcedure [dbo].[getTablePage]    Script Date: 26/02/2017 17:53:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*


declare @rows int
exec [dbo].[getTablePage]  'Documenticorpo','','Documenticorpo_Ky','','Documenticorpo_ky',1,100 ,@rows = @rows

SELECT AnagraficheServizi_Ky from AnagraficheServizi_Vw WITH (nolock) Where (Anagrafiche_Disdetto!=1 Or Anagrafiche_Disdetto Is Null) And (Month(AnagraficheServizi_Scadenaz)) Order by Anagrafiche_ky

*/

ALTER proc [dbo].[getTablePage] 
(
  @table  varchar(50)  = ''
 ,@tableOut varchar(50)  = ''
 ,@key    varchar(50) = ''
 ,@whr    varchar(500)= ''
 ,@ord    varchar(100) = '' 
 ,@Pg  int  = 1
 ,@PgMax  int  = 999999
 ,@Rows  int output  
) as

 
Declare @Type  int
Declare @Sql   varchar(max)
Declare @PgI   int
Declare @PgNum   int
Declare @RowCount  int
Declare @Cnt   int
Declare @Id    int
Declare @Id2   varchar(32)
set @Cnt = 0
 if len(isnull(@Whr,''))>0
  Set @Whr='Where '+@Whr 
 
 if len(isnull(@Ord,''))>0 
  Set @Ord='Order by '+@Ord 
 
 if  @tableOut ='' 
  set @tableOut = @table
 
 SELECT  @Type =  Sc.xusertype
 FROM dbo.sysobjects SO INNER JOIN
            dbo.syscolumns SC ON SO.id = SC.id INNER JOIN
            dbo.systypes ST ON SC.xusertype = ST.xusertype
 WHERE   so.name=@Table And SC.name = @key


declare @slt  varchar(max) =''
select  @slt = @slt+
                case Data_Type
				--when 'int' then ','+ Column_name +'=' + 'FORMAT(' + Column_name + ',''####'',''It-it'')'
				--when 'smallint' then ','+ Column_name + '=' + 'FORMAT(' + Column_name + ',''####'',''It-it'')'
    --            when 'bigint' then ','+Column_name + '=' + 'FORMAT(' + Column_name + ',''####'',''It-it'')'
    --            when 'tinyint' then ','+Column_name + '=' + 'FORMAT(' + Column_name + ',''####'',''It-it'')'
    --            when 'float' then ','+Column_name + '=' + 'FORMAT(' + Column_name + ',''###0.00'',''It-it'')'
				--when 'decimal' then  ','+Column_name + '=' + 'FORMAT(' + Column_name + ',''###0.00'',''It-it'')'
				--when 'money' then ','+Column_name + '=' + 'FORMAT(' + Column_name + ',''###0.00'',''It-it'')'
				--when 'real' then ','+Column_name + '=' + 'FORMAT(' + Column_name + ',''###0.00'',''It-it'')'
				when 'time' then ',['+Column_name + ']=' + 'FORMAT([' + Column_name + '],''HH:mm'',''It-it'')'
				when 'date' then ',['+Column_name + ']=' + 'FORMAT([' + Column_name + '],''dd-MM-yyyy'',''It-it'')'
				when 'datetime' then ',['+Column_name + ']=' + 'FORMAT([' + Column_name + '],''dd-MM-yyyy'',''It-it'')'
				when 'smalldatetime' then ',['+Column_name + ']=' + 'FORMAT([' + Column_name + '],''dd-MM-yyyy'',''It-it'')'
				else ',['+ Column_name +']=['+ Column_name +']' end
 
 from INFORMATION_SCHEMA.COLUMNS 
 where   Table_Name = @Table

 select @slt = substring(@slt,2,len(@slt)-1) 

 set @Sql = 'DECLARE CRVAL scroll cursor for SELECT '+@key+' from '+@Table+' WITH (nolock) '+@Whr+' '+@Ord

 print @Sql
 exec (@Sql)
 
-- Paginazione
 if @Type in (56)
 begin 
  Open CRVAL
  select @PgI=(@Pg-1) * @PgMax + 1
  Set @Rows = @@CURSOR_ROWS
  CREATE TABLE #tmp (Idn int IDENTITY (1, 1) primary key,Idx int)
  Create index ky_idx on #tmp (Idx )
  FETCH ABSOLUTE @PgI FROM crVal into @id
  WHILE @@FETCH_STATUS = 0 and @Cnt < @PgMax
  BEGIN
   Insert into #tmp (Idx) values (@Id)
   FETCH NEXT FROM crVal into @id
   Set @cnt = @cnt +1
  END
  CLOSE crVal
  DEALLOCATE crVal
  
  set @Sql='select '+ @slt + ' from   '+@TableOut+' INNER JOIN #tmp ON '+@Key + ' = #tmp.Idx order by #tmp.idn '
  exec (@Sql)
 end
 else
 begin
  Open CRVAL
  select @PgI=(@Pg-1) * @PgMax + 1
  Set @Rows = @@CURSOR_ROWS
  CREATE TABLE #tmp2 (Idn int IDENTITY (1, 1) primary key,Idx varchar(32))
  Create index ky_idx on #tmp2(Idx )
  FETCH ABSOLUTE @PgI FROM crVal into @id2

  WHILE @@FETCH_STATUS = 0 and @Cnt< @PgMax
  BEGIN
   Insert into #tmp2 (Idx) values (@Id2)
   FETCH NEXT FROM crVal into @id2
   Set @cnt = @cnt +1
  END
  CLOSE crVal
  DEALLOCATE crVal
  Set @TableOut=Replace(@TableOut,'update ','')
  Set @TableOut=Replace(@TableOut,'declare ','')
  Set @TableOut=Replace(@TableOut,'set ','')
  Set @TableOut=Replace(@TableOut,'delete ','')
  Set @TableOut=Replace(@TableOut,'insert ','')
  Set @TableOut=Replace(@TableOut,'update ','')
  Set @TableOut=Replace(@TableOut,'varchar','')
  Set @TableOut=Replace(@TableOut,'char','')
  Set @TableOut=Replace(@TableOut,'*','')
  Set @TableOut=Replace(@TableOut,'-','')
  Set @TableOut=Replace(@TableOut,'/','')
  Set @TableOut=Replace(@TableOut,'replace','')
  Set @TableOut=Replace(@TableOut,'cast','')
  Set @TableOut=Replace(@TableOut,'convert','')
  Set @TableOut=Replace(@TableOut,'@','')

  Set @Key=Replace(@Key,'update ','')
  Set @Key=Replace(@Key,'declare ','')
  Set @Key=Replace(@Key,'set ','')
  Set @Key=Replace(@Key,'delete ','')
  Set @Key=Replace(@Key,'insert ','')
  Set @Key=Replace(@Key,'update ','')
  Set @Key=Replace(@Key,'varchar','')
  Set @Key=Replace(@Key,'char','')
  Set @Key=Replace(@Key,'*','')
  Set @Key=Replace(@Key,'-','')
  Set @Key=Replace(@Key,'/','')
  Set @Key=Replace(@Key,'replace','')
  Set @Key=Replace(@Key,'cast','')
  Set @Key=Replace(@Key,'convert','')
  Set @Key=Replace(@Key,'@','')

  set @Sql='select '+ @slt +' from   '+@TableOut+' INNER JOIN #tmp2 ON '+@Key + ' = #tmp2.Idx collate SQL_Latin1_General_CP1_CI_AS order by #tmp2.Idn'
  
  exec (@Sql)
 end

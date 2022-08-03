
/*

	select dbo.Get_Table_Script('dbo','AliquoteIVA')

*/
alter Function Get_Table_Script
(
	 @vsSchemaName varchar(max)
    ,@vsTableName varchar(max)
)

Returns
    VarChar(Max)
 
Begin

Declare @ScriptCommand varchar(Max)

Select @ScriptCommand =
    'CREATE TABLE [' + @vsSchemaName +'].['+ @vsTableName + '] (' + o.list + ')' 
    +
    (
        Case
        When TC.Constraint_Name IS NULL 
            Then ''
        Else CHAR(13)+'ALTER TABLE [' +  @vsSchemaName +'].['+ @vsTableName + '] ADD CONSTRAINT ' +
            TC.Constraint_Name  +  ' PRIMARY KEY ' + ' (' + LEFT(j.List, Len(j.List)-1) + ')'
        End
    )
From information_schema.TABLES As SO
    Cross Apply

    (
        Select 
          CHAR(13)+ '  [' + column_name + '] ' + 
             data_type + 
             (
                Case data_type
                    When 'sql_variant' 
                        Then ''
                    When 'text' 
                        Then ''
                    When 'decimal' 
                        Then '(' + Cast( numeric_precision_radix As varchar ) + ', ' + Cast( numeric_scale As varchar ) + ') '
                    Else Coalesce( '(' + 
                                        Case 
                                            When character_maximum_length = -1 
                                                Then 'MAX'
                                            Else Cast( character_maximum_length As VarChar ) 
                                        End + ')' , ''
                                 ) 
                End 
            ) 
            + ' ' +
            (
                Case 
                    When Exists ( 
                                    Select id 
                                    From syscolumns
                                    Where 
                                        ( id = object_id(SO.TABLE_SCHEMA+'.'+ SO.TABLE_NAME))
                                        And 
                                        ( name = column_name )
                                        And 
                                        ( columnproperty(id,name,'IsIdentity') = 1 )
                                ) 
                        Then 'IDENTITY(' + 
                                Cast( ident_seed(SO.TABLE_SCHEMA+'.'+ SO.TABLE_NAME) As varchar ) + ',' + 
                                Cast( ident_incr(SO.TABLE_SCHEMA+'.'+ SO.TABLE_NAME) As varchar ) + ')'

                    Else ''

                End
            ) + ' ' +

            (
                Case 
                    When IS_NULLABLE = 'No' 
                        Then 'NOT ' 
                    Else '' 
                End 
            ) + 'NULL ' + 
            (
                Case 
                    When information_schema.columns.COLUMN_DEFAULT IS NOT NULL 
                        Then 'DEFAULT ' + information_schema.columns.COLUMN_DEFAULT 
                    ELse '' 
                End 
            ) + ', ' 
        From information_schema.columns 
        Where 
            ( TABLE_SCHEMA = @vsSchemaName and TABLE_NAME = @vsTableName )
        Order by ordinal_position
        FOR XML PATH('')) o (list)

        Inner Join information_schema.table_constraints As TC On (
                                                                    ( TC.Table_name = SO.TABLE_NAME and TC.TABLE_SCHEMA = SO.TABLE_SCHEMA )
                                                                    AND 
                                                                    ( TC.Constraint_Type  = 'PRIMARY KEY' )
                                                                    And 
                                                                    ( TC.TABLE_NAME = @vsTableName )
                                                                 )
        Cross Apply
            (
                Select '[' + Column_Name + '], '
                From  information_schema.key_column_usage As kcu
                Where 
                    ( kcu.Constraint_Name = TC.Constraint_Name )
                Order By ORDINAL_POSITION
                FOR XML PATH('')
            ) As j (list)


	set @ScriptCommand =replace(@ScriptCommand,', )',' )')
	set @ScriptCommand =replace(@ScriptCommand,'&#x0D;',char(13))

Return @ScriptCommand

End




/* Table-Key */
Declare  @Key as int = {KeyValue}
		,@Now as datetime 
Select	*
From	{SchemaName}.{TableName}
Where	{TableName_Ky}=@Key
 

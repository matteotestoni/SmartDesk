using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for csSql
/// </summary>
public class csSql
{
    public csSql()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DataSet ds = new DataSet();
    StringWriter swfield = new StringWriter();
    StringWriter swvalue = new StringWriter();
    HttpRequest hrrequest;
    string separatore = "";
    string table = "";
    string where = "";
    string orderby = "";
    public string strConnNet = Smartdesk.Config.Sql.ConnectionReadOnly;

    #region Get/Set
    public DataSet Ds
    {
        get { return ds; }
        set { ds = value; }
    }

    public HttpRequest hrRequest
    {
        get { return hrrequest; }
        set { hrrequest = value; }
    }

    public StringWriter swValue
    {
        get { return swvalue; }
        set { swvalue = value; }
    }

    public StringWriter swField
    {
        get { return swfield; }
        set { swfield = value; }
    }

    public string Table
    {
        get { return table; }
        set { table = value; }
    }

    public string OrderBy
    {
        get { return orderby; }
        set { orderby = value; }
    }

    public string Where
    {
        get { return where; }
        set { where = value; }
    }

    #endregion

    public string InsertCreate() {
       return  "Insert Into "+Table+"("+swField+") Values ("+swValue+")";
    }

    public string InsertCreate(string tableName)
    {
        Table = tableName;
        return "Insert Into " + Table + "(" + swField + ") Values (" + swValue + ")";
    }

    public string UpdateCreate()
    {
        return (Where.Trim()=="") ? "" : "Update  " + Table + " Set " + swValue + " " +Where;
    }

    public string UpdateCreate(string tableName)
    {
        Table = tableName;
        return (Where.Trim() == "") ? "" : "Update " + Table + " Set " + swValue + " " + Where;
    }


    public void WhereCreate(string field,string valore){
        Where = "Where " + field + "=" + valore;
    }


    public void NullInsert(string field)
    {
        string ret = "null";
        swfield.Write(separatore + field + "\n");
        swvalue.Write(separatore + ret + "\n");
        separatore = ",";
    }
    
    public void NumberInsert(string field)
    {
        string ret = "null";

        if (hrRequest[field] != null)
        {
            if (hrRequest[field].ToString() == "")
            {
                ret = "null";
            }
            else
            {
                ret = hrRequest[field].ToString().Replace(",", ".");
            }
        }
        swfield.Write(separatore + field+"\n");
        swvalue.Write(separatore + ret+"\n");
        separatore = ",";
    }

    public void NumberUpdate(string field)
    {
        string ret = "null";

        if (hrRequest[field] != null)
        {
            if (hrRequest[field].ToString() == "")
            {
                ret = "null";
            }
            else
            {
                ret = hrRequest[field].ToString().Replace(",", ".");
            }
        }
        swValue.Write(separatore + field + "=" + ret + "\n");
        separatore = ",";
    }

    public void TextInsert(string field)
    {

        string ret = "";

        if (hrRequest[field] != null)
        {
            if (hrRequest[field].ToString() == "")
            {
                ret = "null";
            }
            else
            {
                ret = "'" + hrRequest[field].ToString().Replace("'", "''") + "'";
            }
        }
        swfield.Write(separatore + field + "\n");
        swvalue.Write(separatore + ret + "\n");
        separatore = ",";
     
    }

    public void TextUpdate(string field)
    {

        string ret = "";

        if (hrRequest[field] != null)
        {
            if (hrRequest[field].ToString() == "")
            {
                ret = "null";
            }
            else
            {
                ret = "'" + hrRequest[field].ToString().Replace("'", "''") + "'";
            }
        }
        swValue.Write(separatore + field + "=" + ret + "\n");
        separatore = ",";
     
    }

    public void NullUpdate(string field)
    {

        string ret = "null";
        swValue.Write(separatore + field + "=" + ret + "\n");
        separatore = ",";
    }


    public void GetDateInsert(string field)
    {

        string ret = "GetDate()";

        swfield.Write(separatore + field + "\n");
        swvalue.Write(separatore + ret + "\n");
        separatore = ",";

    }

    public void GetDateUpdate(string field)
    {

        string ret = "GetDate()";

        swValue.Write(separatore + field + "=" + ret + "\n");
        separatore = ",";

    }


    public void StringInsert(string field,string value)
    {
	      swfield.Write(separatore + field);
	        if (value!=null && value!="null"){
	        	swvalue.Write(separatore + "'" +   value.Replace("'", "''") + "'");
		      }else{
	        	swvalue.Write(separatore + "null");
					}
	        separatore = ",";

    }
    
		public void DateTimeInsert(string field, string value)
    {
	      swfield.Write(separatore + field);
        if (value!=null && value!="null"){
					swValue.Write(separatore + value.Replace("'","''"));
				}else{
					swValue.Write(separatore + "null");
				}
        separatore = ",";

    }    
    

    public void StringUpdate(string field, string value)
    {
        if (value!=null && value!="null"){
					swValue.Write(separatore + field + "=" +"'"+ value.Replace("'","''")+"'");
				}else{
					swValue.Write(separatore + field + "=null");
				}
        separatore = ",";

    }
    
		public void DateTimeUpdate(string field, string value)
    {
        if (value!=null && value!="null"){
					swValue.Write(separatore + field + "=" + value.Replace("'","''"));
				}else{
					swValue.Write(separatore + field + "=null");
				}
        separatore = ",";

    }

    public void StringNumberInsert(string field, string value)
    {
        swfield.Write(separatore + field + "\n");
        swvalue.Write(separatore + value + "\n");
        separatore = ",";

    }

    public void StringNumberInsertUpdate(string field, string value)
    {
        swValue.Write(separatore + field + "=" + value + "\n");
        separatore = ",";

    }

    public void CheckInsert(string field)
    {
        string ret = "null";

        if (hrRequest[field] != null)
        {
            if (hrRequest[field].ToString() == "on" || hrRequest[field].ToString() == "si" || hrRequest[field].ToString() == "1" || hrRequest[field].ToString() == "True" || hrRequest[field].ToString() == "true")
            {
                ret = "1";
            }
            else
            {
                ret = "0";
            }
        }
        else
        {
            ret = "0";
        }
        swfield.Write(separatore + field + "\n");
        swvalue.Write(separatore + ret + "\n");
        separatore = ",";
    }

     public void CheckUpdate(string field)
    {
        string ret = "null";

        if (hrRequest[field] != null)
        {
            if (hrRequest[field].ToString() == "on" || hrRequest[field].ToString() == "si" || hrRequest[field].ToString() == "1" || hrRequest[field].ToString() == "True" || hrRequest[field].ToString() == "true")
            {
                ret = "1";
            }
            else
            {
                ret = "0";
            }
        }else{
            ret = "0";
        }
         swValue.Write(separatore + field + "="+ret+ "\n");
        separatore = ",";
    }


     public void Execute( string commandtext)
     {

        SqlConnection cn = new SqlConnection(strConnNet);
        SqlCommand cm = new SqlCommand();
        cm.CommandText = commandtext;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;
        cm.CommandTimeout = 300;
        cn.Open();
        try
        {
            cm.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("csSql->Execute: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }
     }

    public DataTable Select(string table, string select)
    {

        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable(table);

        SqlConnection cn = new SqlConnection(strConnNet);
        SqlCommand cm = new SqlCommand();

        cm.CommandText = select;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;

        cm.CommandTimeout = 120;
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            da.Fill(dt);
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("Sql->Select: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }

        return dt;
    }



    public int SelectCount(string select)
    {
        int rows = 0;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("Count");

        SqlConnection cn = new SqlConnection(strConnNet);
        SqlCommand cm = new SqlCommand();

        cm.CommandText = select;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;

        cm.CommandTimeout = 120;
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            da.Fill(dt);
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("Sql->SelectCount: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }

        foreach (DataRow dr in dt.Rows)
        {
            rows = (int)dr["Count"];
        }

        return rows;
    }




    public DataTable GetTable(string table, string where, string orderby)
    {

        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("Table");
        SqlConnection cn = new SqlConnection(strConnNet);
        SqlCommand cm = new SqlCommand();


        string select = "SELECT * from " + table;
        if (where != "") select += " where " + where;
        if (orderby != "") select += " order by " + orderby;

        cm.CommandTimeout = 0;
        cm.CommandText = select;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            da.Fill(dt);
        }
        catch (SqlException ex)
        {

            Exception err = new Exception("csModelli: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }
        return dt;

    }


}

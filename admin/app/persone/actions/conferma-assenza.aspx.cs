using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public string strPersone_Ky="";
    public string strPersoneAssenze_Ky="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          if (dtLogin.Rows.Count>0){
                strPersoneAssenze_Ky=Request["PersoneAssenze_Ky"];
                strPersone_Ky=Smartdesk.Current.Request("Persone_Ky");
          		strSorgente=Smartdesk.Current.Request("sorgente");
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable("getTable");
                SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
                SqlCommand cm = new SqlCommand();
                
                strSQL = "UPDATE PersoneAssenze SET PersoneAssenze_Lock=1 WHERE PersoneAssenze_Ky=" + strPersoneAssenze_Ky;
                //Response.Write(strSQL);
                cm.CommandText = strSQL;
                cm.CommandType = CommandType.Text;
                cm.Connection = cn;
                cm.CommandTimeout = 300;
                da.SelectCommand = cm;
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                switch (strSorgente){
                    case "elenco-personeassenze":
                        Response.Redirect("/admin/app/persone/elenco-personeassenze.aspx?Persone_Ky=" + strPersone_Ky);
                        break;
                    default:
                        Response.Redirect("/admin/app/persone/elenco-personeassenze.aspx?tutti=tutti");
                        break;
                }
                Response.Redirect("/admin/app/persone/elenco-personeassenze.aspx?tutti=tutti");
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    /**/
     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}

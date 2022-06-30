using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class RandomPassword : System.Web.UI.Page
{
    
    public int intNumRecords = 0;
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    


    protected void Page_Load(object sender, EventArgs e)
    {
    	string strFROMNet = "";
      string strWHERENet="";
      string strORDERNet = "";

      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
			      if (dtLogin.Rows.Count>0){
			        
			        boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
						}
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}    
    public string getNewPassword(long lngNumero){
        string passwordString = "";
        string temp = "";
        Random rand = new Random(unchecked((int)lngNumero));
        for (int i = 0; i < 12 ; i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            passwordString += temp;
        }
        return passwordString;
    }
    
}

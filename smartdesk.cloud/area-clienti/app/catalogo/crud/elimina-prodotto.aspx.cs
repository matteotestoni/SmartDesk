using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strConnNet = "";
    public int intNumRecords = 0;
    public int i = 0;
    public string strLogin="";
    public DataTable dtLogin;
    public string strProdotti_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      strConnNet = Smartdesk.Config.Sql.ConnectionReadOnly;
      if(Request.Cookies["rswcrm-cliente"] != null)
      {
          strWHERENet = "Anagrafiche_Ky =" + Smartdesk.Session.CurrentUser.ToString();
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1, strConnNet);
          if (dtLogin.Rows.Count>0){
                strProdotti_Ky=Smartdesk.Current.Request("Prodotti_Ky");
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable("getTable");
                SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
                SqlCommand cm = new SqlCommand();
                strSQL = "DELETE FROM Prodotti WHERE Prodotti_Ky=" + strProdotti_Ky;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                Response.Redirect("/area-clienti/elenco-prodotti.aspx");
          }else{
            Response.Redirect("/area-clienti/default.aspx");
          }
      }else{
            Response.Redirect("/area-clienti/default.aspx");
      }
    }

}

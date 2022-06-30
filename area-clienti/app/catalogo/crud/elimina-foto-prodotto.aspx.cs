using System;
using System.Data;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strConnNet = "";
    public int intNumRecords = 0;
    public int i = 0;
    public string strLogin="";
    public DataTable dtLogin;
    public string strProdotti_Ky="";
    public string strFoto="";

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
                strFoto=Smartdesk.Current.Request("foto");
                strSQL = "UPDATE Prodotti SET Prodotti_Foto" + strFoto + "s=null,Prodotti_Foto" + strFoto + "=null WHERE Prodotti_Ky=" + strProdotti_Ky;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                Response.Redirect("/area-clienti/scheda-prodotto.aspx?Prodotti_Ky=" + strProdotti_Ky);
          }else{
            Response.Redirect("/area-clienti/default.aspx");
          }
      }else{
            Response.Redirect("/area-clienti/default.aspx");
      }
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}

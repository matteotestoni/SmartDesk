using System;
using System.Data;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    public DataTable dtWishlist;
    
    
    public string strUtentiLogin = "";
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strAste_Ky = "";
        string strAnagrafiche_Ky = "";
        string strWHERENet = "";
        string strORDERNet = "";
        string strSQL = "";

        
        

        if (Smartdesk.Login.Verify)
        {
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("AsteCauzioni_Autorizzata") == "") frm.Add("AsteCauzioni_Autorizzata", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AsteCauzioni", frm);
            strRedirect = "/admin/app/aste/scheda-astecauzioni.aspx?salvato=salvato&azione=modifica&AsteCauzioni_Ky=" + strKy;
            strAste_Ky=Smartdesk.Current.Request("Aste_Ky");
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            //se non è in wishlist devo inserirlo
            strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky + " AND Aste_Ky=" + strAste_Ky;
            strORDERNet = "Wishlist_Ky DESC";
            dtWishlist = new DataTable("Wishlist");
            dtWishlist = Smartdesk.Sql.getTablePage("Wishlist", null, "Wishlist_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtWishlist.Rows.Count<1){
              strSQL="INSERT INTO Wishlist (Anagrafiche_Ky, Aste_Ky, Wishlist_Data, Wishlist_DateInsert, Wishlist_DateUpdate)";
              strSQL+=" VALUES (" + strAnagrafiche_Ky + "," + strAste_Ky + ",GETDATE(),GETDATE(),GETDATE())" ;
              //Response.Write(strSQL);
              new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }

	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
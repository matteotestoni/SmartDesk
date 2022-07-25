using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public string strLogin = "";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;

    public string strProduttori_Ky = "";
  

    protected void Page_Load(object sender, EventArgs e)
    {
        string strSQL = "";

        if (Smartdesk.Login.Verify)
        {
            dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            if (dtLogin.Rows.Count > 0)
            {
                strProduttori_Ky = Smartdesk.Current.Request("Produttori_Ky");
                strSQL = "UPDATE Produttori SET Produttori_Logo=null WHERE Produttori_Ky=" + strProduttori_Ky;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                Response.Redirect("/admin/app/catalogo/scheda-produttori.aspx?Produttori_Ky=" + strProduttori_Ky);
            }
            else
            {
                Response.Redirect(Smartdesk.Current.LoginPageRoot);
            }
        }
        else
        {
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}

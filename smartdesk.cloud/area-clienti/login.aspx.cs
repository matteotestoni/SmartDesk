using System;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    public string strConnNet = "";
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public string strUrl="";
    public string strErrore="";
    
    public string strReturnUrl="";
    public bool boolLogin = false;
    public bool boolAdmin = false;
    public string strAnagrafiche_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

      strErrore=Smartdesk.Current.Request("errore");
         if (Context.Request.Cookies.Count > 0)
        {
            if (Context.Request.Cookies["rswcrm-cliente"] != null)
            {
                if (Context.Request.Cookies["rswcrm-cliente"].Value != null)
                {
                    try
                    {
                        strAnagrafiche_Ky = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-cliente"].Value)).UserData;
                        strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
                        strORDERNet = "Anagrafiche_Ky";
                        strFROMNet = "Anagrafiche";
                        dtLogin = new DataTable("Login");
                        dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1, strConnNet);
                        if (dtLogin.Rows.Count>0){
                          Response.Redirect("/area-clienti/home.aspx");
                        }
                    }
                    catch
                    {
                        strErrore = "Impossibile leggere il cookie";
                        boolLogin = false;
                        boolAdmin = false;
                    }
                }
                else
                {
                    strErrore = "";
                    boolLogin = false;
                }
            }
            else
            {
                strErrore = "";
                boolLogin = false;
            }
        }
        else
        {
            //strErrore = "";
            //boolLogin = false;
        }
    }    
}

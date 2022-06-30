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
    public string strLead_Ky="";
    public string strLeadStato_Ky="";
    public string strAnagrafiche_Ky="";
    public string strCommesse_Ky="";
    public string strOpportunita_Ky="";
    public int intLeadStato_Ky=0;
    public string strSorgente="";
    
    public bool boolAjax = false;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strLead_Ky=Request["Lead_Ky"];
            boolAjax=Convert.ToBoolean(Smartdesk.Current.Request("ajax"));
            strLeadStato_Ky=Smartdesk.Current.Request("LeadStato_Ky");
            intLeadStato_Ky=Convert.ToInt32(strLeadStato_Ky);
            strSorgente=Smartdesk.Current.Request("sorgente");
            strSQL = "UPDATE Lead SET LeadStato_Ky=" + intLeadStato_Ky.ToString() + " WHERE Lead_Ky=" + strLead_Ky;
  					new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            if (boolAjax==true){
                //Response.Write(strSQL);
                Response.Write("ok");
            }else{
                switch (strSorgente){
                  case "home":
                    Response.Redirect("/admin/home.aspx?Lead_Ky=" + strLeadStato_Ky);
                    break;
                  case "home-tecnici":
                    Response.Redirect("/admin/home.aspx?Lead_Ky=" + strLeadStato_Ky);
                    break;
                  case "scheda-lead":
                    Response.Redirect("/admin/form.aspx?CoreForms_Ky=200&Lead_Ky=" + strLead_Ky);
                    break;
                }            
            }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}

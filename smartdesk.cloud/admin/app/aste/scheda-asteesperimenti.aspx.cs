using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin = "";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtAsteEsperimenti;
    public string strFROMNet = "";
    public string strH1 = "Esperimento asta";
    public string strAzione = "";
    public string strAste_Ky = "";
    

    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Smartdesk.Login.Verify)
        {
	        dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            boolAdmin = Smartdesk.Data.FieldBool(dtLogin,"Utenti_Admin");
            strAzione = Smartdesk.Current.Request("azione");
            strAste_Ky = Smartdesk.Current.Request("Aste_Ky");
            if (strAzione != "new")
            {
                strAzione = "modifica";
                dtAsteEsperimenti = Smartdesk.Data.Read("AsteEsperimenti", "AsteEsperimenti_Ky", Smartdesk.Current.QueryString("AsteEsperimenti_Ky"));
            }
        }
        else
        {
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }


    public String GetDefaultValue(string strField)
    {
        string strValore = "";
        switch (strField)
        {
            case "Aste_Ky":
                strValore = strAste_Ky;
                break;
        }
        return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore="";
      }else{
        strValore= Smartdesk.Data.Field(dtTabella,strField);
      }
      return strValore;
    }

    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
        Boolean boolValore = false;
        if (strAzione == "new")
        {
            boolValore = false;
        }
        else
        {
            boolValore = Smartdesk.Data.FieldBool(dtTabella,strField);
        }
        return boolValore;
    }
}

using System;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public DataTable dtPersoneAssenze;
    public int intAnagrafiche_Ky = 0;
    public string strFROMNet = "";
    public string strH1 = "Assenza persona";
    public string strAzione = "modifica";
    
    public string strPersone_Ky = "";

    protected void Page_Load(object sender, EventArgs e)
    {
     
	 
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strAzione = Request["azione"];
            strPersone_Ky=Smartdesk.Current.Request("Persone_Ky");
            if (strAzione!="new"){
              strAzione = "modifica";
              dtPersoneAssenze = Smartdesk.Data.Read("PersoneAssenze_Vw", "PersoneAssenze_Ky",Smartdesk.Current.QueryString("PersoneAssenze_Ky"));
              strH1="Scheda assenza";
            }else{
              strH1="Nuova assenza";
						}           
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
				case "PersoneAssenze_Data_IT":
					strValore=DateTime.Now.ToString("d");
					break;
				case "PersoneAssenze_Anno":
					strValore=DateTime.Now.Year.ToString();
					break;
				case "PersoneAssenze_Ore":
					strValore="8";
					break;
				case "PersoneAssenze_Descrizione":
					strValore="Assenza";
					break;
				case "PersoneAssenzeTipo_Ky":
					strValore="1";
					break;
				case "Persone_Ky":
					if (strPersone_Ky!=null){
						strValore=strPersone_Ky;
					}else{
						strValore="";
					}
					break;
			}
      return strValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
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
    
    public String GetLock()
    {
      string strValore="";
      if (strAzione!="new"){
        if (dtPersoneAssenze.Rows[0]["PersoneAssenze_Lock"].Equals(true)){
          strValore="readonly=\"readonly\"";
        }
      }
      return strValore;
    }
}

namespace Smartdesk{

  public static class Amministrazione{
    public static int CoreModules_Ky = 2;
    public static string CoreModules_Code = "amministrazione";
    public static string[] CoreEntities = {"Aziende","AziendeSedi","AziendeSediOrari","AziendeSediReparti","BlacklistEmail","Colori","Comuni","ComuniZone","CoreEmailQueue","CoreEmailTemplate","Divise","Lingue","Nazioni","Ore","Priorita","Province","Regioni","TimeZones","Titoli","Utenti","UtentiGruppi","UtentiLog","UtentiTeams","UtentiTipo","AliquoteIVA","CentridiCR","Conti","ContiMovimentiCausali","ImposizioniIVA","Spese","TerminiCondizioni"};

    public static string AliquoteIVA_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string AliquoteIVA_AfterSave(string strKy){
		  string strSQL="";
      string strReturn="";
        if (Smartdesk.Current.Request("AliquoteIVA_Predefinita")=="True" || Smartdesk.Current.Request("AliquoteIVA_Predefinita").Equals(true)){
          strSQL = "UPDATE AliquoteIVA SET AliquoteIVA_Predefinita=0 WHERE AliquoteIVA_Ky<>" + strKy;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          strReturn="AfterSave ok";
				}else{
          strReturn="AfterSave nothing to do";
        }
      return strReturn;
	  }

    public static string CentridiCR_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string CentridiCR_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }

    public static string Conti_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string Conti_AfterSave(string strKy){
		  string strSQL="";
      string strReturn="";
				if (Smartdesk.Current.Request("Conti_Default")=="True" || Smartdesk.Current.Request("Conti_Default").Equals(true)){
          strSQL = "UPDATE Conti SET Conti_Default=0 WHERE Conti_Ky<>" + strKy;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          strReturn="AfterSave ok";
				}else{
          strReturn="AfterSave nothing to do";
        }
      return strReturn;
    }

    public static string ContiMovimentiCausali_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string ContiMovimentiCausali_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }

    public static string ImposizioniIVA_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string ImposizioniIVA_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }

    public static string Spese_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string Spese_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }

    public static string TerminiCondizioni_BeforeSave(){
      string strReturn="";
      return strReturn;
    }

    public static string TerminiCondizioni_AfterSave(string strKy){
      string strReturn="";
      return strReturn;
    }

  }

}

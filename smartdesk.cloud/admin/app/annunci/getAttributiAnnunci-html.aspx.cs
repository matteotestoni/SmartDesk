using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strWHERENet = "";
    public string strORDERNet = "";
    public string strFROMNet = "";
    
    public int intNumRecords = 0;
    public DataTable dtLogin;
    public DataTable dtAnnunciCategorie;
    public DataTable dtAnnunci;
    public DataTable dtAttributi;
    public DataTable dtAttributiOpzioni;
    public string strOutput = "";
    public int intNum = 0;
    public string strAnnunci_Ky = "";
    public string strAnnunciCategorie_Ky = "";
    public string strAttributi = "";
    public string strRequired = "";
    public string strClass = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      Response.Cache.SetCacheability(HttpCacheability.NoCache);

      strAnnunciCategorie_Ky = Request.QueryString["AnnunciCategorie_Ky"];

      if (strAnnunciCategorie_Ky!=null && strAnnunciCategorie_Ky.Length>0){
        strWHERENet = "AnnunciCategorie_Ky=" + strAnnunciCategorie_Ky + "";
        strORDERNet = "AnnunciCategorie_Ky";
        strFROMNet = "AnnunciCategorie";
        dtAnnunciCategorie = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnnunciCategorie_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        strAttributi=dtAnnunciCategorie.Rows[0]["AnnunciCategorie_Attributi"].ToString();
        if (strAttributi!=null && strAttributi.Length>0){
			strWHERENet = "(Attributi_Annunci=1 AND Attributi_Ky IN (" + strAttributi + "))";
		}else{
			strWHERENet = "(Attributi_Annunci=1)";
		}
        strORDERNet = "Attributi_Ky";
        strFROMNet = "Attributi_Vw";
        dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
        strWHERENet = "Attributi_Annunci=1";
        strORDERNet = "Attributi_Ky";
        strFROMNet = "Attributi_Vw";
        dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }
      
      strAnnunci_Ky = Request.QueryString["Annunci_Ky"];
      if (strAnnunci_Ky!=null && strAnnunci_Ky.Length>0){
        strWHERENet = "Annunci_Ky=" + strAnnunci_Ky;
        strORDERNet = "Annunci_Ky";
        strFROMNet = "Annunci_Vw";
        dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }else{
        strWHERENet = "Annunci_Ky=0";
        strORDERNet = "Annunci_Ky";
        strFROMNet = "Annunci_Vw";
        dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      }

      if (dtAttributi!=null && dtAttributi.Rows.Count>0){
        strOutput="<legend>Dati tecnici</legend>";
        for (int j = 0; j < dtAttributi.Rows.Count; j++){
          strOutput+="<div class='grid-x grid-padding-x'>\n";
          strOutput+="<div class='large-2 medium-2 small-4 cell'>\n";
  		  strOutput+="<label class='large-text-right small-text-left middle'>" + dtAttributi.Rows[j]["Attributi_Titolo"].ToString();
  		  if (dtAttributi.Rows[j]["Attributi_Obbligatorio"].Equals(true)){
            strOutput+="*";      
          }else{
            strOutput+="";      
          }
  		  strOutput+="</label>\n";
  		  strOutput+="</div>\n";
          strOutput+="<div class='large-10 medium-10 small-8 cell'>\n";
  		  if (dtAttributi.Rows[j]["Attributi_Obbligatorio"].Equals(true)){
            strRequired=" " + "required=\"required\"";      
          }else{
            strRequired="";      
          }
  		  if (dtAttributi.Rows[j]["Attributi_ClasseCSS"].ToString().Length>0){
            strClass=" " + dtAttributi.Rows[j]["Attributi_ClasseCSS"].ToString();      
          }
  		  switch (dtAttributi.Rows[j]["AttributiTipo_Ky"].ToString()){
  			case "1":
  				strOutput+="<input type='text' name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" value=\"" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "\"" + strRequired + strClass + " />";
  				break;
  			case "2":
  				strOutput+="<textarea name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" value=\"\"" + strRequired + strClass + ">" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "</textarea>";
  				break;
  			case "3":
  				strOutput+="<input type=\"text\" name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" class=\"datepicker txt\" value=\"" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "\"" + strRequired + strClass + " />";
  				break;
  			case "4":
                string strCheck="<input type=\"checkbox\" name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\"";
                if (GetCheckValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString())==true){ 
                    strCheck+=" checked=\"checked\"";
                }
                strCheck+=" value=\"on\" />";
                strOutput+=strCheck;
  				break;
  			case "5":
  				strOutput+="<input type=\"text\" name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" class=\"price\" value=\"" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "\"" + strRequired + strClass + " />";
  				break;
  			case "6":
  				strOutput+="<select name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" value=\"" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "\"" + strRequired + strClass + "><option value=\"\"></option>";
  				strWHERENet="Attributi_Ky=" + dtAttributi.Rows[j]["Attributi_Ky"].ToString();
        	    strORDERNet = "AttributiOpzioni_Ordine";
        	    strFROMNet = "AttributiOpzioni";
        	    dtAttributiOpzioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiOpzioni_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  				for (int j2 = 0; j2 < dtAttributiOpzioni.Rows.Count; j2++){
  				  strOutput+="<option value=\"" + dtAttributiOpzioni.Rows[j2]["AttributiOpzioni_Opzione"].ToString() + "\">" + dtAttributiOpzioni.Rows[j2]["AttributiOpzioni_Opzione"].ToString() + "</option>";
  				}
  				strOutput+="</select>\n";
                strOutput+="<script type=\"text/javascript\">\n";
  				strOutput+="selectSet('" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "', '" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "');\n";
                strOutput+="</script>\n";
  				break;
  	      }
  		  if (dtAttributi.Rows[j]["Attributi_Obbligatorio"].Equals(true)){
            strOutput+="<span class=\"form-error\">Obbligatorio</span>";      
          }
  		  strOutput+="</div>\n";
          strOutput+="</div>\n";
        }
      }
      //Response.Clear();
      Response.ContentType = "text/HTML";
      TextWriter  objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
      objX.WriteLine(strOutput);
      objX.Flush();
      objX.Close();
      Response.End();
    }
    
    public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (dtTabella.Rows.Count>0){
        strValore=dtTabella.Rows[0][strField].ToString();
      }else{
        strValore="";
      }
      return strValore;
    }

    public Boolean GetCheckValue(DataTable dtTabella, string strField)
    {
        Boolean boolValore = false;
        if (dtTabella.Rows.Count>0){
          boolValore = Smartdesk.Data.FieldBool(dtTabella,strField);
        }else{
          boolValore=false;
        }
        return boolValore;
    }
}

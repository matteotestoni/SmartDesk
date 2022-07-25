using System;
using System.Configuration;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Data.SqlClient;
using Reportman.Drawing; 
using Reportman.Reporting;


  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtDocumenti;
    public bool boolAdmin = false;
    public string strSorgente="";
    
	  public string strPathReport="";
	  public string strPathPDF = "";
	  public string strNomePDF = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      
      
			
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
          strWHERENet = "Year(Documenti_Data)=2021 AND Documenti_PDF Is Null";
          strORDERNet = "Documenti_Ky";
          strFROMNet = "Documenti_Vw";
          dtDocumenti = new DataTable("Documenti");
          dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strPathReport =Server.MapPath("/admin/app/documenti/report/rpt-documenti.rep");
    			for (int i = 0; i < dtDocumenti.Rows.Count; i++){
						strPathPDF = Server.MapPath("/uploads/documenti/" + dtDocumenti.Rows[i]["Documenti_Anno"].ToString());
						if (System.IO.Directory.Exists(strPathPDF)==false){
							System.IO.Directory.CreateDirectory(strPathPDF);	
						}
						strNomePDF = dtDocumenti.Rows[i]["Documenti_Anno"].ToString() + "-" + dtDocumenti.Rows[i]["Documenti_Numero"].ToString() + "-" + GetUTF(dtDocumenti.Rows[i]["Anagrafiche_RagioneSociale"].ToString().Trim()) + "-" + GetUTF(dtDocumenti.Rows[i]["Documenti_Descrizione"].ToString().Trim()) + ".pdf";
						strPathPDF = Server.MapPath("/uploads/documenti/" + dtDocumenti.Rows[i]["Documenti_Anno"].ToString() + "/" + strNomePDF);
						strSQL="UPDATE Documenti SET Documenti_PDF='/" + dtDocumenti.Rows[i]["Documenti_Anno"].ToString() + "/" + strNomePDF + "' WHERE Documenti_Ky=" +  dtDocumenti.Rows[i]["Documenti_Ky"].ToString();
						new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            Reportman.Reporting.Report rp = new Reportman.Reporting.Report();
				    rp.LoadFromFile(strPathReport);
				    rp.ConvertToDotNet();
            for (int x = 0; x < rp.DatabaseInfo.Count; x++) {
                rp.DatabaseInfo[x].ConnectionString = Smartdesk.Config.Sql.ConnectionReadOnly;
                rp.DatabaseInfo[x].DotNetDriver = Reportman.Reporting.DotNetDriverType.Sql;
                rp.DatabaseInfo[x].Driver = Reportman.Reporting.DriverType.DotNet2;
            }
            rp.DataInfo[0].SQL = "SELECT * FROM Documenti_Vw WHERE Documenti_Ky = " +  dtDocumenti.Rows[i]["Documenti_Ky"].ToString();
            rp.DataInfo[1].SQL = "SELECT * FROM DocumentiCorpo_Vw WHERE Documenti_Ky=" +  dtDocumenti.Rows[i]["Documenti_Ky"].ToString();
            rp.DataInfo[2].SQL = "SELECT * FROM Aziende_Vw WHERE (Aziende_Ky=1)";
            rp.DataInfo[3].SQL = "SELECT * FROM Pagamenti_Vw WHERE Documenti_Ky=" +  dtDocumenti.Rows[i]["Documenti_Ky"].ToString();
            rp.AsyncExecution=false;
            PrintOutPDF printpdf = new PrintOutPDF
            {
                FileName = strPathPDF,
                Compressed = true
            };
            rp.LFontName = "Google Sans";
            rp.WFontName = "Google Sans";
            printpdf.Print(rp.MetaFile);
    			}
					switch (strSorgente){
						case "scheda-documenti":
						  Response.Redirect("/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=" +  dtDocumenti.Rows[i]["Documenti_Ky"].ToString());
						  break;
						case "elenco-documenti":
						  Response.Redirect("/admin/app/documenti/elenco-documenti.aspx");
						  break;
						default:
						  Response.Redirect("/admin/app/documenti/elenco-documenti.aspx");
						  break;
					}
      }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

  public String GetUTF(string strTestoIn)
  {
    string strTestoOut="";
    if (strTestoIn!=null){
      strTestoOut=strTestoIn.Replace(".","").Replace("&","").Replace("snc","").Replace(" ","-").Replace("--","-").Replace("°","").Replace("\"", "-").Replace("/", "-").Replace("(", "").Replace(")", "").Replace("'", "");
    }else{
      strTestoOut="";
    }
    return strTestoOut;
  }   
     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}

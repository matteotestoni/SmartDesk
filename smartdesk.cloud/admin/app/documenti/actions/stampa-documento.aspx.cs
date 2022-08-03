using System;
using System.Data;
using Reportman.Drawing; 
using Reportman.Reporting;

public partial class _Default : System.Web.UI.Page 
{
  
  
  public DataTable dtLogin;
  public DataTable dtDocumento;
  public bool boolAdmin = false; 
  public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
  public int intNumRecords = 0;
  public int i = 0;
  
  public string strLogin="";
  public string strPathReport="";
  public string strPathPDF = "";
  public string strNomePDF = "";
  public string strDocumenti_Ky = "";
  public string strSQL = "";


  protected void Page_Load(object sender, EventArgs e){   
	  
	  
  
        if (Smartdesk.Login.Verify){
            strDocumenti_Ky = Request["Documenti_Ky"];
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            dtDocumento = Smartdesk.Data.Read("Documenti_Vw","Documenti_Ky", strDocumenti_Ky);
            strPathReport =Server.MapPath("/admin/app/documenti/report/rpt-documenti.rep");
						strPathPDF = Server.MapPath("/uploads/documenti/" + dtDocumento.Rows[0]["Documenti_Anno"].ToString());
						if (System.IO.Directory.Exists(strPathPDF)==false){
							System.IO.Directory.CreateDirectory(strPathPDF);	
						}
						strNomePDF = dtDocumento.Rows[0]["Documenti_Anno"].ToString() + "-" + dtDocumento.Rows[0]["Documenti_Numero"].ToString() + "-" + GetUTF(dtDocumento.Rows[0]["Anagrafiche_RagioneSociale"].ToString().Trim()) + "-" + GetUTF(dtDocumento.Rows[0]["Documenti_Descrizione"].ToString().Trim()) + ".pdf";
						strPathPDF = Server.MapPath("/uploads/documenti/" + dtDocumento.Rows[0]["Documenti_Anno"].ToString() + "/" + strNomePDF);
						
						strSQL="UPDATE Documenti SET Documenti_PDF='/" + dtDocumento.Rows[0]["Documenti_Anno"].ToString() + "/" + strNomePDF + "' WHERE Documenti_Ky=" + strDocumenti_Ky;
						new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            Reportman.Reporting.Report rp = new Reportman.Reporting.Report();
				    Response.Write(strPathReport);
                    rp.LoadFromFile(strPathReport);
				    rp.ConvertToDotNet();
            for (int x = 0; x < rp.DatabaseInfo.Count; x++) {
                rp.DatabaseInfo[x].ConnectionString = Smartdesk.Config.Sql.ConnectionReadOnly;
                rp.DatabaseInfo[x].DotNetDriver = Reportman.Reporting.DotNetDriverType.Sql;
                rp.DatabaseInfo[x].Driver = Reportman.Reporting.DriverType.DotNet2;
            }
            rp.DataInfo[0].SQL = "SELECT * FROM Documenti_Vw WHERE Documenti_Ky = " + strDocumenti_Ky;
            rp.DataInfo[1].SQL = "SELECT * FROM DocumentiCorpo_Vw WHERE Documenti_Ky=" + strDocumenti_Ky;
            rp.DataInfo[2].SQL = "SELECT * FROM Aziende_Vw WHERE (Aziende_Ky=1)";
            rp.DataInfo[3].SQL = "SELECT * FROM Pagamenti_Vw WHERE Documenti_Ky=" + strDocumenti_Ky;
            //Response.Write(rp.DataInfo[0].ToString());
            //Response.Write(rp.DataInfo[0].SQL.ToString());
            //Response.Write(rp.DataInfo[1].SQL.ToString());
            rp.AsyncExecution=false;
            PrintOutPDF printpdf = new PrintOutPDF
            {
                FileName = strPathPDF,
                Compressed = true
            };
            rp.LFontName = "Google Sans";
            rp.WFontName = "Google Sans";
            printpdf.Print(rp.MetaFile);
            Response.Clear();
            //Response.Write(strNomePDF);
						Response.ContentType = "application/pdf";
            Response.AddHeader("Name",strNomePDF);
            Response.AddHeader("Content-Disposition", "inline; filename=" + strNomePDF);
            Response.TransmitFile(strPathPDF);
            Response.End(); 

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
}

using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo ciEn = new System.Globalization.CultureInfo("en-US");
    
    public string strAnagrafiche_Ky="";
    public string strDocumenti_Ky="";
    public string strAttributiGruppi_Ky;
    public DataTable dtAnagrafiche;
    public DataTable dtAnagraficheServizi;
    public DataTable dtDocumenti;
    public DataTable dtTemp;
    public string strPath="";
    public string strNumero="0";
    
    public string strMese="0";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      string strDescrizione = "";
      decimal decTotDocumento = 0;
      int intRinnovo=0;
      SqlConnection conn;
      SqlCommand cmd;

      
      
	  
      if (Smartdesk.Login.Verify){
          	strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
          	strMese=Request["mese"];
			//dati del cliente
			strWHERENet = "Anagrafiche_Ky =" + strAnagrafiche_Ky;
	        strORDERNet = "Anagrafiche_Ky";
	        strFROMNet = "Anagrafiche_Vw";
	        dtAnagrafiche = new DataTable("Anagrafiche");
	        dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
            conn.Open();
            
			//prendo tutti i servizi in scadenza per il cliente per il mese selezionato
	        if (strMese!=null && strMese!="0" && strMese.Length>0){
				strWHERENet = "AnagraficheServizi_Chiuso=0 And Anagrafiche_Ky=" + strAnagrafiche_Ky + " And Month(AnagraficheServizi_Scadenza)=" + strMese;
			}else{
				strWHERENet = "AnagraficheServizi_Chiuso=0 And Anagrafiche_Ky=" + strAnagrafiche_Ky;
			}
            strFROMNet = "AnagraficheServizi_Vw";
            strORDERNet = "AnagraficheServizi_Scadenza, Anagrafiche_Ky";
            dtAnagraficheServizi = new DataTable("AnagraficheServizi");
            dtAnagraficheServizi = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

			//inserimento documento vuoto
			strNumero=GetNewNumDoc(DateTime.Now.Year);
			strSQL="INSERT INTO Documenti ([DocumentiTipo_Ky],[DocumentiStato_Ky],[Documenti_Riferimenti],[Documenti_Numero],[Documenti_Data],[Anagrafiche_Ky],[Documenti_TotaleRighe],[Documenti_TotaleIVA],[Documenti_Totale],[Documenti_Descrizione],[Documenti_Note],[Documenti_PDF],[Commesse_Ky], Aziende_Ky)";
			strSQL+="VALUES (1,2,'servizi'," + strNumero + ",GETDATE(),"+ strAnagrafiche_Ky + ",0,0,0,'Rinnovo servizi',null,null,null,1)";
			//Response.Write(strSQL);
            cmd = new SqlCommand(strSQL, conn);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();

		    strWHERENet = "Anagrafiche_Ky=" + strAnagrafiche_Ky;
            strFROMNet = "Documenti_Vw";
            strORDERNet = "Documenti_Ky DESC";
            dtDocumenti = new DataTable("Documento");
            dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
			strDocumenti_Ky=dtDocumenti.Rows[0]["Documenti_Ky"].ToString();
    		for (int i = 0; i < dtAnagraficheServizi.Rows.Count; i++){
				strAttributiGruppi_Ky=dtAnagraficheServizi.Rows[i]["AttributiGruppi_Ky"].ToString();
				if (strAttributiGruppi_Ky.Length<1){
					strAttributiGruppi_Ky="null";	
				}
				strDescrizione=dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Descrizione"].ToString().Replace("'","") + Environment.NewLine;
				strDescrizione+=Environment.NewLine + " - Servizio valido dal " + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Inizio_IT"].ToString() + " al "  + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Scadenza_IT"].ToString();
				strSQL="INSERT INTO DocumentiCorpo ([Documenti_Ky],[DocumentiCorpo_Titolo],[DocumentiCorpo_Descrizione],[DocumentiCorpo_Qta],[DocumentiCorpo_Importo],[DocumentiCorpo_Totale], AnagraficheServizi_Ky, AliquoteIVA_Ky,AliquoteIVA_Aliquota, Servizi_Ky, AttributiGruppi_Ky)";
				strSQL+="VALUES (";
				strSQL+=strDocumenti_Ky + ",'" + dtAnagraficheServizi.Rows[i]["Servizi_Titolo"].ToString() + "','" + strDescrizione + "'," + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Qta"].ToString().Replace(",",".") + "," + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Importo"].ToString().Replace(",",".") + "," + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Importo"].ToString().Replace(",",".") + "," + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString() + "," + dtAnagrafiche.Rows[0]["AliquoteIVA_Ky"].ToString() + "," + dtAnagrafiche.Rows[0]["AliquoteIVA_Aliquota"].ToString().Replace(",",".");
				strSQL+="," + dtAnagraficheServizi.Rows[i]["Servizi_Ky"].ToString() + "," + strAttributiGruppi_Ky;
				strSQL+=")";
				//Response.Write(strSQL + "<hr>");
	            cmd = new SqlCommand(strSQL, conn);
	            cmd.CommandTimeout = 0;
	            cmd.ExecuteNonQuery();
	            
				intRinnovo=Convert.ToInt32(dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Rinnovo"]);
                switch (intRinnovo){
                    case 0:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_DataChiusura=GETDATE(),AnagraficheServizi_Chiuso=1 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                		break;
                    case 1:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 1, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 1, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 2:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 2, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 2, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 3:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 3, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 3, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 4:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 4, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 4, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 5:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 5, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 5, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 6:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 6, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 6, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 7:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 7, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 7, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 8:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 8, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 8, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 9:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 9, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 9, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 10:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 10, AnagraficheServizi_Inizio), AnagraficheServizi_Scadenza=DATEADD(month, 10, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 11:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(month, 11, AnagraficheServizi_Inizio, AnagraficheServizi_Scadenza=DATEADD(month, 11, AnagraficheServizi_Scadenza, AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                    case 12:
	                	strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_Inizio=DATEADD(year, 1, AnagraficheServizi_Inizio),AnagraficheServizi_Scadenza=DATEADD(year, 1, AnagraficheServizi_Scadenza), AnagraficheServizi_Chiuso=0 WHERE AnagraficheServizi_Ky=" + dtAnagraficheServizi.Rows[i]["AnagraficheServizi_Ky"].ToString();
                        break;    
                }
                //Response.Write(strSQL);
				new SqlCommand(strSQL, conn).ExecuteNonQuery();
		        
				//aggiorno totali
				strSQL="UPDATE Documenti SET "; 
		        strSQL+="Documenti_TotaleRighe=Documenti_Totali_Vw.TotaleRighe,";
		        strSQL+="Documenti_TotaleIVA=Documenti_Totali_Vw.TotaleIVA,";
		        strSQL+="Documenti_Totale=Documenti_Totali_Vw.TotaleRighe+Documenti_Totali_Vw.TotaleIVA";
		        strSQL+=" FROM Documenti inner JOIN Documenti_Totali_Vw ON Documenti.Documenti_Ky=Documenti_Totali_Vw.Documenti_Ky";
		        strSQL+=" WHERE Documenti.Documenti_Ky=" + strDocumenti_Ky;
		        //Response.Write(strSQL);
		        new SqlCommand(strSQL, conn).ExecuteNonQuery();

			}
		    strWHERENet = "Documenti_Ky=" + strDocumenti_Ky;
            strFROMNet = "Documenti_Vw";
            strORDERNet = "Documenti_Ky DESC";
            dtDocumenti = new DataTable("Documento");
            dtDocumenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Documenti_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

	        decTotDocumento=Convert.ToDecimal(dtDocumenti.Rows[0]["Documenti_Totale"]);
			//Response.Write(decTotDocumento.ToString("0.##"));

			//inserisco scadenza di pagamento
			strDescrizione=dtDocumenti.Rows[0]["Documenti_Numero"].ToString() + " del " + dtDocumenti.Rows[0]["Documenti_Data_IT"].ToString() + " per Rinnovo servizi";
			strSQL="INSERT INTO Pagamenti ([PagamentiTipo_Ky],[Pagamenti_Data],[Pagamenti_Importo],[Pagamenti_Riferimenti],[Anagrafiche_Ky],[Pagamenti_Pagato],[Pagamenti_NumeroPromemoria],[Pagamenti_NumeroChiamate],[Pagamenti_AttivaPromemoria],[Documenti_Ky],[Pagamenti_UltimoPromemoria],[Pagamenti_DataPagato],[Commesse_Ky],[PagamentiMetodo_Ky])";
			strSQL+=" VALUES (1 ,DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,GETDATE())+2,0)) ," + decTotDocumento.ToString("0.##") + ",'" + strDescrizione + "'," + strAnagrafiche_Ky + ",0,0,0,1," + strDocumenti_Ky + ",Null,Null,Null,1)";
            cmd = new SqlCommand(strSQL, conn);
            cmd.CommandTimeout = 0;
	        //Response.Write(strSQL);
            cmd.ExecuteNonQuery();

			strPath="/admin/app/documenti/scheda-documenti.aspx?CoreModules_Ky=13&CoreEntities_Ky=44&CoreForms_Ky=1212&Documenti_Ky=" + strDocumenti_Ky;
            conn.Close();
			Response.Redirect(strPath);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public String GetNewNumDoc(int intAnno)
    {
    	int intUltimoNumero=0;
    	string strNuovoNumero="";
			dtTemp = new DataTable("GetNewNumDoc");
			dtTemp = Smartdesk.Sql.getTablePage("Documenti_Vw", null, "Documenti_Ky", "Documenti_Anno=" + intAnno, "Documenti_Numero DESC", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			if (dtTemp.Rows.Count>0){
				intUltimoNumero=Convert.ToInt32(dtTemp.Rows[0]["Documenti_Numero"]);
			}     
			strNuovoNumero=(intUltimoNumero+1).ToString();
      return strNuovoNumero;
    }

    public Decimal GetDecimal(string strValue)
    {
    	decimal dcmlReturn=0;
			
			if (strValue!=null && strValue.Length>0){
				try{
					dcmlReturn=Convert.ToDecimal(strValue);
				}catch{
					dcmlReturn=0;				
				}				
			}else{
				dcmlReturn=0;				
			}
      return dcmlReturn;
    }

     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}

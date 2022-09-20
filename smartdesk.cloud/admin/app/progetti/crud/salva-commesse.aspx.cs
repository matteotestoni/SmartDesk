using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
          {
  		  	Dictionary<string, object> frm = new Dictionary<string, object>();
  		  	if (Smartdesk.Current.Request("Commesse_DataConsegna") == "") frm.Add("Commesse_DataConsegna", null);
  		  	if (Smartdesk.Current.Request("Commesse_DataChiusura") == "") frm.Add("Commesse_DataChiusura", null);
          strKy = Smartdesk.Functions.SqlWriteKey("Commesse", frm);
          aggiornaOre(strKy);
          aggiornaAvanzamento(strKy);
          strRedirect = "/admin/app/progetti/scheda-commesse.aspx?salvato=salvato&Commesse_Ky=" + strKy;
  	    	Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
    		}
    }
        
    
    public bool aggiornaAvanzamento(string strCommesse_Ky){
      bool output = false;
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";
      DataTable dtAttivitaAperte;
      DataTable dtAttivitaChiuse;
      DataTable dtAttivitaTotali;
      DataTable dtAttivitaCommesseTotaleOre;
      DataTable dtCommesse;
      decimal decTotOrePreviste=0; 
      decimal decTotOreImpiegate=0; 
      decimal decTotOreResidue=0; 
      string strTotOrePreviste="0"; 
      string strTotOreImpiegate="0"; 
      string strTotOreResidue="0"; 
      int intAvanzamento = 0;

    		strWHERENet = "Commesse_Ky=" + strCommesse_Ky;
			  strORDERNet = "Commesse_Ky DESC";
        strFROMNet = "Commesse";
        dtCommesse = new DataTable("Commesse");
        dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				decTotOrePreviste=Convert.ToDecimal(dtCommesse.Rows[0]["Commesse_OrePreviste"]);
				decTotOreResidue=Convert.ToDecimal(dtCommesse.Rows[0]["Commesse_OreResidue"]);

  			strWHERENet="Commesse_Ky=" + strCommesse_Ky + "";
        strORDERNet = "Commesse_Ky";
        strFROMNet = "Attivita_TotaliCommesse_Vw";
        dtAttivitaCommesseTotaleOre = new DataTable("AttivitaCommesseTotaleOre");
        dtAttivitaCommesseTotaleOre = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtAttivitaCommesseTotaleOre!=null && dtAttivitaCommesseTotaleOre.Rows.Count>0){
  				if (dtAttivitaCommesseTotaleOre.Rows[0]["Attivita_Ore"]!=System.DBNull.Value){
  					decTotOreImpiegate=Convert.ToDecimal(dtAttivitaCommesseTotaleOre.Rows[0]["Attivita_Ore"]);
  				}else{
  					decTotOreImpiegate=0;	
  				}
  			}else{
  				strTotOreImpiegate="0";
  			}
        if (dtCommesse.Rows[0]["CommesseTipo_Ky"].ToString()=="1"){
		        strWHERENet="(Commesse_Ky=" + strCommesse_Ky + ")";
            strORDERNet = "Attivita_Ky";
            strFROMNet = "Attivita";
            dtAttivitaTotali = new DataTable("AttivitaTotali");
            dtAttivitaTotali = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
						if (dtAttivitaTotali!=null && dtAttivitaTotali.Rows.Count>0){
							strWHERENet="(Attivita_Completo<>1 Or Attivita_Completo Is Null) And (Commesse_Ky=" + strCommesse_Ky + ")";
              strORDERNet = "Attivita_Ky";
              strFROMNet = "Attivita";
              dtAttivitaAperte = new DataTable("AttivitaAperte");
              dtAttivitaAperte = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							strWHERENet="(Attivita_Completo=1) And (Commesse_Ky=" + strCommesse_Ky + ")";
              strORDERNet = "Attivita_Ky";
              strFROMNet = "Attivita";
              dtAttivitaChiuse = new DataTable("AttivitaChiuse");
              dtAttivitaChiuse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
             	Response.Write("Attivita aperte:" + dtAttivitaAperte.Rows.Count + "<br>");	
             	Response.Write("Attivita chiuse:" + dtAttivitaChiuse.Rows.Count + "<br>");	
             	Response.Write("Attivita totali:" + dtAttivitaTotali.Rows.Count + "<br>");	
							intAvanzamento=Math.Abs(dtAttivitaChiuse.Rows.Count*100/dtAttivitaTotali.Rows.Count);
							strWHERENet="Commesse_Ky=" + strCommesse_Ky + "";
              strORDERNet = "Commesse_Ky";
              strFROMNet = "Attivita_TotaliCommesse_Vw";
              dtAttivitaCommesseTotaleOre = new DataTable("AttivitaCommesseTotaleOre");
              dtAttivitaCommesseTotaleOre = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtAttivitaCommesseTotaleOre!=null && dtAttivitaCommesseTotaleOre.Rows.Count>0){
								if (dtAttivitaCommesseTotaleOre.Rows[0]["Attivita_Ore"]!=System.DBNull.Value){
									decTotOreImpiegate=Convert.ToDecimal(dtAttivitaCommesseTotaleOre.Rows[0]["Attivita_Ore"]);
								}else{
									decTotOreImpiegate=0;	
								}
                decTotOreResidue=decTotOrePreviste-decTotOreImpiegate;
								strTotOreImpiegate=Convert.ToString(decTotOreImpiegate).Replace(",",".");
								strTotOreResidue=Convert.ToString(decTotOreResidue).Replace(",",".");
							}else{
								strTotOreImpiegate="0";
							  strTotOreResidue="0";
							}
            }else{
              intAvanzamento=0;
							strTotOreImpiegate="0";
            
            }
        }else{
            //contratto ad ore
            if (decTotOreImpiegate>0 && decTotOrePreviste>0){
              intAvanzamento=Math.Abs(Convert.ToInt32((decTotOreImpiegate*100)/decTotOrePreviste));
            }else{
              intAvanzamento=0;
            }
            decTotOreResidue=decTotOrePreviste-decTotOreImpiegate;
						strTotOreImpiegate=Convert.ToString(decTotOreImpiegate).Replace(",",".");
						strTotOreResidue=Convert.ToString(decTotOreResidue).Replace(",",".");
        }
        if (intAvanzamento>100){
          intAvanzamento=100;
        }
				strSQL = "UPDATE Commesse SET Commesse_OreImpiegate=" + strTotOreImpiegate + ", Commesse_OreResidue=" + strTotOreResidue + ", Commesse_Avanzamento=" + intAvanzamento + " WHERE Commesse_Ky=" + strCommesse_Ky;
        Response.Write(strSQL + "<br>");
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
    
    
    public bool aggiornaOre(string strCommesse_Ky)
    {
        string strSQL = "gg";
        bool output = false;

        if (strCommesse_Ky != null && strCommesse_Ky.Length > 0)
        {
            strSQL = "UPDATE Commesse SET";
            strSQL += " Commesse_OreImpiegate=Commesse_Totali_Vw.TotaleOreImpiegate, Commesse_OreResidue=Commesse_Totali_Vw.Commesse_OrePreviste-Commesse_Totali_Vw.TotaleOreImpiegate";
            strSQL += " FROM Commesse INNER JOIN Commesse_Totali_Vw ON Commesse.Commesse_Ky=Commesse_Totali_Vw.Commesse_Ky";
            strSQL += " WHERE Commesse.Commesse_Ky=" + strCommesse_Ky;
            //Response.Write(strSQL);
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
        output=true;
        return output;
    }
    
}

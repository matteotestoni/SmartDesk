using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    public string strMetaDescription = "";
    public string strMetaKeywords = "";
    public string strH1 = "";
    public string strP1 = "";
    public string strTitle = "";
    public string strValore = "";
    public int i = 0;
    public int intNumRecords = 0;
    public int intRecxPag = 10;
    public int intStartPag = 1;
    public DataTable dtVeicolo;
    public DataTable dtVeicoloOfferte;
    public DataTable dtVeicoloOfferteAuto;
    public DataTable dtVeicoloEquipaggiamenti;
    public DataTable dtVeicoloOptionals;
    public DataTable dtLandi;
    public string strVeicoli_Ky="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo ciEN = new System.Globalization.CultureInfo("en-US");
    private string strAnnuncioMeta = "";
    private string strInviato = "";
    public DataTable dtVeicoli;
    public DataTable dtVeicoliMarca;
    public DataTable dtVeicoloModello;
    public int intNumRecordsModelli = 0;
    public string strVeicoliMarca_Ky_Selezionata = "0";
    public string strScheda = "";
    public string strAlt="";
    public string strImg="";
    public string strWHERENet="";
    public string strAgostodaspazio="";
    public string strSanvalentino="";
    public string strDipendentifca="";
    public string strPreferitiCookie;
    public string strConfrontoCookie;
    public string strUtm_source="";
    public string strUtm_medium="";
    public string strUtm_campaign="";
    public string strUtm_term="";
    public string strUtm_content="";
    public DataTable dtVeicoliOfferteAttiva;
    public string strClass="";
    public string strPrice="";
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        string strFROMNet = "";
        string strORDERNet = "";
        string strVeicoli_Ky="";
    
    	  
    	  
        //tracciamento utm
        strUtm_source=StripHTML(Request["utm_source"]);
        if (strUtm_source==null || strUtm_source.Length<1){
            if (Request.Cookies["utm_source"]!=null && Request.Cookies["utm_source"].Value.ToString().Length>0){
               strUtm_source=Request.Cookies["utm_source"].Value.ToString();
            }
        }else{
      		Response.Cookies["utm_source"].Value = strUtm_source;		
      		Response.Cookies["utm_source"].Expires = DateTime.Now.AddDays(120);
        }
        strUtm_medium=StripHTML(Request["utm_medium"]);
        if (strUtm_medium==null || strUtm_medium.Length<1){
            if (Request.Cookies["utm_medium"]!=null && Request.Cookies["utm_medium"].Value.ToString().Length>0){
               strUtm_medium=Request.Cookies["utm_medium"].Value.ToString();
            }
        }else{
      		Response.Cookies["utm_medium"].Value = strUtm_medium;		
      		Response.Cookies["utm_medium"].Expires = DateTime.Now.AddDays(120);
        }
        strUtm_campaign=StripHTML(Request["utm_campaign"]);
        if (strUtm_campaign==null || strUtm_campaign.Length<1){
            if (Request.Cookies["utm_campaign"]!=null && Request.Cookies["utm_campaign"].Value.ToString().Length>0){
               strUtm_campaign=Request.Cookies["utm_campaign"].Value.ToString();
            }
        }else{
      		Response.Cookies["utm_campaign"].Value = strUtm_campaign;		
      		Response.Cookies["utm_campaign"].Expires = DateTime.Now.AddDays(120);
        }
        //preferiti e confronto
        if (Request.Cookies["preferiti"]!=null){
			strPreferitiCookie=Request.Cookies["preferiti"].Value.ToString();
		}else{
			strPreferitiCookie="";
		}
        if (Request.Cookies["confronto"]!=null){
			strConfrontoCookie=Request.Cookies["confronto"].Value.ToString();
		}else{
			strConfrontoCookie="";
		}

        //prendo la prima offerta attiva
        strWHERENet = "VeicoliOfferte_DataInizio<=GETDATE() AND VeicoliOfferte_DataFine>GETDATE() AND VeicoliOfferte_Abilitata=1";
        strFROMNet = "VeicoliOfferte";
        strORDERNet = "VeicoliOfferte_Ky DESC";
        dtVeicoliOfferteAttiva = new DataTable("VeicoliOfferte");
        dtVeicoliOfferteAttiva = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliOfferte_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        //marche
        strWHERENet="VeicoliTipo_Ky=1";
        strFROMNet = "VeicoliMarca_Presenti_Vw";
        strORDERNet = "VeicoliMarca_Titolo";
        dtVeicoliMarca = new DataTable("Marche");
        dtVeicoliMarca = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliMarca_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        strVeicoli_Ky= Request["Veicoli_Ky"];
        if (strVeicoli_Ky!=null && strVeicoli_Ky.Length>0){
          if (!IsNumeric(strVeicoli_Ky)){
            Response.Redirect("/");
          }          
          if (strVeicoli_Ky.Contains(",")){
            string[] words = strVeicoli_Ky.Split(',');
            strVeicoli_Ky=words[0];
          }
        }
        
        strInviato= Request["inviato"];
        strWHERENet="Veicoli_Ky=" + strVeicoli_Ky;
        strFROMNet = "Veicoli_SchedaWebSpazio_Vw";
        strORDERNet = "Veicoli_Ky";
        dtVeicolo = new DataTable("auto");
        dtVeicolo = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtVeicolo.Rows.Count>0){
          //offerta sul veicolo
			    dtVeicoloOfferte = Smartdesk.Sql.getTablePage("VeicoliOfferte", null, "VeicoliOfferte_Ky", "VeicoliOfferte_Titolo='agostodaspaziotorino' AND Veicoli_Targa='" + dtVeicolo.Rows[0]["Veicoli_Targa"].ToString().Trim() + "'", "VeicoliOfferte_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			    dtVeicoloOfferteAuto = Smartdesk.Sql.getTablePage("VeicoliOfferteAuto_Vw", null, "VeicoliOfferteAuto_Ky", "VeicoliOfferte_DataInizio<=GETDATE() AND VeicoliOfferte_DataFine>GETDATE() AND VeicoliOfferte_Abilitata=1 AND Veicoli_Targa='" + dtVeicolo.Rows[0]["Veicoli_Targa"].ToString().Trim() + "'", "VeicoliOfferte_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        
          //carico gli equipaggiamenti
	        //Response.Write(strWHERENet);
          strWHERENet="type='standard' AND externalId = '" + dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString() + "'";
	        strFROMNet = "VehiclesEquipments";
	        strORDERNet = "VehiclesEquipments_Ky";
	        dtVeicoloEquipaggiamenti = new DataTable("VehiclesEquipments");
	        dtVeicoloEquipaggiamenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "VehiclesEquipments_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
					strWHERENet="type='option' AND externalId = '" + dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString() + "'";
	        strFROMNet = "VehiclesEquipments";
	        strORDERNet = "VehiclesEquipments_Ky";
	        dtVeicoloOptionals = new DataTable("VehiclesOptionals");
	        dtVeicoloOptionals = Smartdesk.Sql.getTablePage(strFROMNet, null, "VehiclesEquipments_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

    			//cookie offerte
    			if (Request.Browser.Cookies){		
    					if (Request.Cookies["dipendentifca"]!=null){
    						if (dtVeicolo.Rows[0]["Comuni_Comune"].ToString().ToLower().Trim().Equals("torino") && dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower().Trim().Equals("fiat") || dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="alfa romeo" || dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="abarth" || dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="jeep" || dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="alfa" || dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString().ToLower()=="lancia"){
    							strDipendentifca=Request.Cookies["dipendentifca"].Value;
    						}
    					}
    			}

          //modelli
        strVeicoliMarca_Ky_Selezionata=dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString();
        dtVeicoloModello = new DataTable("modelliauto");
        dtVeicoloModello = Smartdesk.Sql.getTablePage("VeicoliModelloSpazioGroup", null, "VeicoliModelloSpazioGroup_Ky", "VeicoliTipo_Ky=1 AND VeicoliMarcaSpazioGroup_Marca='" + strVeicoliMarca_Ky_Selezionata + "'", "VeicoliModelloSpazioGroup_Modello", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        intNumRecordsModelli=intNumRecords;

          if (dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString().Trim().Length>1){
            strTitle=dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString();
          }else{
            strTitle=dtVeicolo.Rows[0]["VeicoliMarca_Titolo"].ToString();
          }

          if (dtVeicolo.Rows[0]["VeicoliModelloSpazioGroup_Modello"].ToString().Trim().Length>1){
            strTitle+=" " + dtVeicolo.Rows[0]["VeicoliModelloSpazioGroup_Modello"].ToString();
          }else{
            strTitle+=" " + dtVeicolo.Rows[0]["VeicoliModello_Titolo"].ToString();
          }
          if (dtVeicolo.Rows[0]["Veicoli_Allestimento"].ToString().Length>0){
            strTitle+=" " + dtVeicolo.Rows[0]["Veicoli_Allestimento"].ToString().Trim();
          }
          if (dtVeicolo.Rows[0]["VeicoliCategoria_DescrizioneWEB"].ToString().Length>0){
            strTitle+=" " + dtVeicolo.Rows[0]["VeicoliCategoria_DescrizioneWEB"].ToString();
          }
          if (dtVeicolo.Rows[0]["VeicoliColore_Descrizione"].ToString().Length>0){
            strTitle+=" colore " + dtVeicolo.Rows[0]["VeicoliColore_Descrizione"].ToString();
          }
          if (dtVeicolo.Rows[0]["VeicoliCategoria_Ky"].ToString()!="7" && dtVeicolo.Rows[0]["Veicoli_KM"].ToString().Trim().Length>0){
            strTitle+=" con " + dtVeicolo.Rows[0]["Veicoli_KM"].ToString() + "km";
          }
          strH1=strTitle;
          if (dtVeicolo.Rows[0]["Veicoli_Allestimento"].ToString().Length>0){
            strTitle+=" " + dtVeicolo.Rows[0]["Veicoli_Allestimento"].ToString();
          }
          if ((dtVeicolo.Rows[0]["Veicoli_ValoreNascondi"].Equals(true)) || (dtVeicolo.Rows[0]["Veicoli_Valore"].Equals(null))){
            strValore="in Trattativa riservata";
          }else{ 
      			if (dtVeicolo.Rows[0]["Veicoli_Valore"]!=null && dtVeicolo.Rows[0]["Veicoli_Valore"].ToString().Length>0){
      	            strValore=" <span class=\"prezzoauto\">" + ((decimal)dtVeicolo.Rows[i]["Veicoli_Valore"]).ToString("N0", ci) + " &euro;</span>";
      			}else{
      	            strValore=" <span class=\"prezzoauto\"></span>";
      			}

          } 

					if ((dtVeicolo.Rows[0]["Veicoli_ValoreNascondi"].Equals(true)) || (dtVeicolo.Rows[0]["Veicoli_Valore"].Equals(null))){
						strPrice="0";
					}else{ 
						if (dtVeicoloOfferteAuto.Rows.Count>0){
							if ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreTagliato"]>0){
								strPrice=((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]).ToString("N0", ciEN);
							}else{
								if ((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]!=(decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]){
								  strPrice=(((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"])-((decimal)dtVeicoloOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"])).ToString("N0", ciEN);
								}else{
									if (dtVeicolo.Rows[0]["Veicoli_Valore"]!=null && dtVeicolo.Rows[0]["Veicoli_Valore"].ToString().Length>0){
								    strPrice=((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ciEN);
									}
								}
							}
						}else{
							if (dtVeicolo.Rows[0]["Veicoli_Valore"]!=null && dtVeicolo.Rows[0]["Veicoli_Valore"].ToString().Length>0){
								strPrice=((decimal)dtVeicolo.Rows[0]["Veicoli_Valore"]).ToString("N0", ciEN);
							}
						}
					}                        
          
          
          
          
          if (dtVeicolo.Rows[0]["ComuneVenditore"].ToString().Length>0){
            strTitle+=" a " + dtVeicolo.Rows[0]["Comuni_Comune"].ToString();
            strH1+=" a " + dtVeicolo.Rows[0]["Comuni_Comune"].ToString();
          }
					
          strAnnuncioMeta=Server.HtmlEncode(dtVeicolo.Rows[0]["Veicoli_Annuncio"].ToString().Trim().Replace(System.Environment.NewLine," ").Replace("\r", " ").Replace("\n", " "));
          if (strAnnuncioMeta.Length>150){
            strAnnuncioMeta=strAnnuncioMeta.Substring(0,150);
          }
          strMetaDescription = strTitle + " | " + strAnnuncioMeta.Trim();
          strP1=" in vendita.";
	        strWHERENet="(VeicoliMarcaSpazioGroup_Marca='" + dtVeicolo.Rows[0]["VeicoliMarcaSpazioGroup_Marca"].ToString() + "') ";
	        strWHERENet+="AND (VeicoliModelloSpazioGroup_Modello='" + dtVeicolo.Rows[0]["VeicoliModelloSpazioGroup_Modello"].ToString() + "')";
	        strWHERENet+="AND (Veicoli_Ky<>" + dtVeicolo.Rows[0]["Veicoli_Ky"].ToString() + ")";
	        //Response.Write(strWHERENet);
	        strFROMNet = "Veicoli_ElencoWebSpazio_Vw";
	        strORDERNet = "Veicoli_Valore, VeicoliMarcaSpazioGroup_Marca, Veicoli_KM";
	        dtVeicoli = new DataTable("ElencoAuto");
	        dtVeicoli = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, 1, 20,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          strWHERENet = "equipment like '%IMPIANTO GPL Landi%' AND externalId = '" + dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString() + "'";
          dtLandi = Smartdesk.Sql.getTablePage("VehiclesEquipments", null, "VehiclesEquipments_Ky", strWHERENet, "VehiclesEquipments_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }else{
          //Response.Redirect("/");
        }        
    }

    public int GetNumeroFotoVeicolo(DataRow dtRigaVeicolo)
    {
      int intNumeroFoto=0;
      int intCampo=0;
      string strCampo="";
      for (intCampo=1;intCampo<21;intCampo++){
            strCampo="Veicoli_Foto" + intCampo;
            if (dtRigaVeicolo[strCampo].ToString().Length > 0)
            {
                intNumeroFoto = intCampo;                
            }else{
                break;
            }
        }
      return intNumeroFoto;
    } 

    public String GetUrlScheda(DataTable dtScheda)
    {
	  string strSchedaTemp="";
        strSchedaTemp="/usata_";
	    strSchedaTemp+=dtScheda.Rows[i]["VeicoliMarca_UrlKey"].ToString().Trim();
	    strSchedaTemp+="-" + dtScheda.Rows[i]["VeicoliModello_UrlKey"].ToString().Replace("(","").Replace(")","").Replace(">","").Replace("/","").Trim();
	    strSchedaTemp+="-usato_" + dtScheda.Rows[i]["Veicoli_Ky"].ToString().Trim() + ".html";
        if (strUtm_source!=null && strUtm_source.Length>0){
            strSchedaTemp+="?utm_source=" + strUtm_source;
            if (strUtm_medium!=null && strUtm_medium.Length>0){
                strSchedaTemp+="&utm_medium=" + strUtm_medium;
            }
            if (strUtm_campaign!=null && strUtm_campaign.Length>0){
                strSchedaTemp+="&utm_campaign=" + strUtm_campaign;
            }
            if (strUtm_term!=null && strUtm_term.Length>0){
                strSchedaTemp+="&utm_term=" + strUtm_term;
            }
            if (strUtm_content!=null && strUtm_content.Length>0){
                strSchedaTemp+="&utm_content=" + strUtm_content;
            }
        }
	  return strSchedaTemp;
    }   


    public string GetBodyStyle(string strCarrozzeria){
	   string strBodyStyle="";
     switch (strCarrozzeria){
      case "City Car":
        strBodyStyle="SMALL_CAR";
        break;
      case "Cabrio":
        strBodyStyle="CONVERTIBLE";
        break;
      case "Station Wagon":
        strBodyStyle="WAGON";
        break;
      case "Suv/Fuoristrada":
        strBodyStyle="SUV";
        break;
      case "Berlina":
        strBodyStyle="SEDAN";
        break;
      case "Coupé":
        strBodyStyle="COUPE";
        break;
      case "Monovolume":
        strBodyStyle="OTHER";
        break;
      case "Furgoni/Van":
        strBodyStyle="VAN";
        break;
      case "Altro":        
        strBodyStyle="OTHER";
        break;
      default:    
        strBodyStyle="NONE";
        break;
    
     }
	   return strBodyStyle;
    }
    
    public string GetTransmission(string strCambio){
	   string strTransmission="";
     switch (strCambio){
      case "Cambio automatico":
        strTransmission="AUTOMATIC";
        break;
      case "Cambio manuale":
        strTransmission="MANUAL";
        break;
      default:    
        strTransmission="OTHER";
        break;
    
     }
	   return strTransmission;
    }
    
    public string GetFuelType(string strCarburante){
	   string strFuelType="";
     switch (strCarburante){
      case "Benzina":
        strFuelType="PETROL";
        break;
      case "Ibrido":
        strFuelType="HYBRID";
        break;
      case "Diesel":
        strFuelType="DIESEL";
        break;
      case "Elettrica":
        strFuelType="ELECTRIC";
        break;
      case "GPL":
        strFuelType="OTHER";
        break;
      case "Metano":
        strFuelType="OTHER";
        break;
      case "Altro":
        strFuelType="OTHER";
        break;
      default:    
        strFuelType="OTHER";
        break;
    
     }
	   return strFuelType;
    }
    
    public static string sanitizeInput(string strInput, string strType){
        string strPattern;
        string strReturn;
        if (strInput != null)
        {
            switch (strType){
              case "string":
                strPattern = @"<(.|\n)*?>";
                strReturn = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, string.Empty);
                strReturn = strReturn.Replace(">","").Replace("<","").Replace("'","").Replace("\"","");
                break;
              case "number":
                strPattern = @"[^0-9.]";
                strReturn = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, string.Empty);
                strReturn = strReturn.Replace(" ","").Replace("..",".");
                break;
              default:
                strPattern = @"<(.|\n)*?>";
                strReturn = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, string.Empty);
                strReturn = strReturn.Replace(">","").Replace("<","").Replace("'","").Replace("\"","");
                break;
            }
            return strReturn;
        }
        else
        {
            return string.Empty;
        }    
    }

    public static string StripHTML(string htmlString)
    {
        string strPattern;
        string strReturn;
        if (htmlString != null)
        {
            strPattern = @"<(.|\n)*?>";
            strReturn = System.Text.RegularExpressions.Regex.Replace(htmlString, strPattern, string.Empty);
            strReturn = strReturn.Replace(">","").Replace("<","").Replace("'","").Replace("\"","");
            return strReturn;
        }
        else
        {
            return string.Empty;
        }
    }
    
    public bool IsNumeric(string strValue){
      bool boolReturn=false;
      int number;
        if (int.TryParse(strValue, out number))
        {
            boolReturn=true;
        }
        return boolReturn;
    }    

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        if (table.Trim() == "" || App.Trim() == "")
        {
            Exception ex = new Exception("csLoadData->getTablePage: Manca Tabella: " + table + " o App: " + App);
            throw ex;
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(App);
        SqlCommand cm = new SqlCommand();
        SqlParameter pm = null;

        cm.CommandTimeout = 0;
        cm.CommandText = "getTablePage";
        cm.CommandType = CommandType.StoredProcedure;
        cm.Connection = cn;

        pm = new SqlParameter("@table", SqlDbType.VarChar, 50);
        pm.Value = table;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@tableout", SqlDbType.VarChar, 50);
        pm.Value = tableout;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@key", SqlDbType.VarChar, 50);
        pm.Value = key;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@whr", SqlDbType.VarChar, 1000);
        pm.Value = where;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@ord", SqlDbType.VarChar, 100);
        pm.Value = orderby;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@pg", SqlDbType.Int);
        pm.Value = pagina;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@pgmax", SqlDbType.Int);
        pm.Value = paginamax;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@rows", SqlDbType.Int);
        pm.Value = paginamax;
        pm.Direction = System.Data.ParameterDirection.Output;
        cm.Parameters.Add(pm);
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            da.Fill(dt);
        }
        catch (SqlException ex)
        {
            string msg = "<br />Table: " + table + "<br />Tableout:" + tableout + "<br />Where:" + where + "<br />Orderby:" + orderby;
            Exception err = new Exception("csLoadData->getTablePage: " + ex.Message + msg);
            throw err;
        }
        finally
        {
            dt.Dispose();
            cm.Dispose();
            cn.Close();
        }
        System.Data.IDataParameter[] id;
        id = da.GetFillParameters();
        this.intNumRecords = Convert.ToInt32(id[7].Value.ToString());
        return dt;
    }

}

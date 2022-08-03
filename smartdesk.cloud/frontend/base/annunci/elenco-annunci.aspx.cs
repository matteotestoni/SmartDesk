using System;
using System.Data;
using System.Web.Security;
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page 
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public string strH1="Elenco annunci";
    public DataTable dtAnnunci;
    public int intRecxPag = 30;
    public int intPage = 0;
    public int intNumPagine = 1;
    public string strPaginazione = "";
    public DataTable dtAnnunciTipologie;
    public DataTable dtAnnunciCategorie;
    public DataTable dtAnnunciCategorieFigli;
    public DataTable dtAnnunciCategorieFiltri;
    public DataTable dtAnnunciCategorieCorrente;
    public DataTable dtComuni;
    public DataTable dtProvince;
    public DataTable dtRegioni;
    public DataTable dtAttributi;
    public string strTemp="";
    public string strAnnunciCategorie_Ky="";
    public string strAnnunciCategorie_Ky_Corrente = "";
    public DataTable dtBannerTop1;
    public DataTable dtBannerTop2;
    public DataTable dtBannerBottom1;
    public DataTable dtBannerBottom2;
    public DataTable dtBannerSidebar1;
    public DataTable dtBannerSidebar2;
    public DataTable dtBannerSidebar3;
    public DataTable dtBannerSidebar4;
    public string strClass="";
   public string strWHERENetAnnunci="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
      string strPage = "";
      string strValue="";

      
	    
        if (Request.Cookies["app"] != null){
            strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
            strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
            strORDERNet = "Anagrafiche_Ky";
            strFROMNet = "Anagrafiche";
            dtLogin = new DataTable("Login");
            dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtLogin.Rows.Count>0){
              boolLogin=true;
              strLogin="<li><a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>Il mio profilo</a></li><li><a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa-duotone fa-user-times fa-fw\"></i>Esci</a></li>";
            }else{
              strLogin="<li><a href=\"/account/login.html\" rel=\"nofollow\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Accedi</span></a><li></li><a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-plus fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Registrati</span></a><li>";
              boolLogin=false;
            }
        }else{
          strLogin="<li><a href=\"/account/login.html\" rel=\"nofollow\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Accedi</span></a><li></li><a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-plus fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Registrati</span></a><li>";
          boolLogin=false;
        }
  
        strPage = Request["page"];
        if ((strPage == null) || (strPage == ""))
        {
            intPage = 1;
        }
        else
        {
            intPage = Convert.ToInt32(strPage);
        }
      
	  	  strWHERENet = "AnnunciCategorie_Padre=0";
      	dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      	dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        strAnnunciCategorie_Ky=Request["AnnunciCategorie_Ky"];
        
	  		if (strAnnunciCategorie_Ky!=null && strAnnunciCategorie_Ky.Length>0){
          strWHERENet = "AnnunciCategorie_Padre IN (" + strAnnunciCategorie_Ky + ")";
        	dtAnnunciCategorieFigli = new DataTable("AnnunciCategorie");
        	dtAnnunciCategorieFigli = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }

        if (strAnnunciCategorie_Ky!=null && strAnnunciCategorie_Ky.Length>0){
          if (Int32.TryParse(strAnnunciCategorie_Ky, out i) == false){
            Response.Redirect("/");
          }
          if (strAnnunciCategorie_Ky.Substring(strAnnunciCategorie_Ky.Length-1,1)==","){
            strAnnunciCategorie_Ky=strAnnunciCategorie_Ky.Substring(0,strAnnunciCategorie_Ky.Length-1);              
          } 
          strWHERENet = "AnnunciCategorie_Padre IN (" + strAnnunciCategorie_Ky + ")";
      	  dtAnnunciCategorieFiltri = new DataTable("AnnunciCategorieFiltri");
      	  dtAnnunciCategorieFiltri = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }else{
          strWHERENet = "AnnunciCategorie_Padre=0";
      	  dtAnnunciCategorieFiltri = new DataTable("AnnunciCategorieFiltri");
      	  dtAnnunciCategorieFiltri = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }
        
        strAnnunciCategorie_Ky_Corrente = Request["AnnunciCategorie_Ky_Corrente"];
        if (strAnnunciCategorie_Ky_Corrente!=null && strAnnunciCategorie_Ky_Corrente.Length>0){
          strWHERENet = "AnnunciCategorie_Ky=" + strAnnunciCategorie_Ky_Corrente;
          dtAnnunciCategorieCorrente = new DataTable ("AnnunciCategorieCorrente");
          dtAnnunciCategorieCorrente = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Titolo", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }
        
        strValue = Request["Regioni_Ky"];
        if (strValue != null && strValue != "" && strValue.Length > 0){
            if (Int32.TryParse(strValue, out i) == false){
              Response.Redirect("/");
            }
            strWHERENet = "Regioni_Ky=" + strValue;
        }else{
            strWHERENet = "Nazioni_Ky=105";
        }
        dtProvince = new DataTable("Province");
        dtProvince = Smartdesk.Sql.getTablePage("Province_Vw", null, "Province_Ky", strWHERENet, "Province_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);


        dtComuni = new DataTable("Comuni");
        strValue = Request["Province_Ky"];
        if (strValue != null && strValue != "" && strValue.Length > 0){
            if (Int32.TryParse(strValue, out i) == false){
              Response.Redirect("/");
            }
            strWHERENet = "Province_Ky=" + strValue;
            dtComuni = Smartdesk.Sql.getTablePage("Comuni_Vw", null, "Comuni_Ky", strWHERENet, "Comuni_Ky", 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }

        strWHERENet = "Nazioni_Ky=105";
      	dtRegioni = new DataTable("Regioni");
      	dtRegioni = Smartdesk.Sql.getTablePage("Regioni", null, "Regioni_Ky", strWHERENet, "Regioni_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      	strWHERENet = getWhere();
        strWHERENetAnnunci= strWHERENet;
      	dtAnnunci = new DataTable("Annunci");
      	dtAnnunci = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Vetrina DESC, Annunci_Ky DESC", intPage, intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  		  this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtAnnunci,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
        //Response.Write(strWHERENet);
        
        strWHERENet = "Attributi_Annunci=1";
        strORDERNet = "Attributi_Ordine";
        strFROMNet = "Attributi_Vw";
        dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        
        //banner
        strValue = Request["Province_Ky"];
        strValue = sanitize(strValue);
        if (strValue != null && strValue != "" && strValue.Length>0){
            strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%1%' AND CMSAds_Province like '%" + strValue + "%'";
            strORDERNet = "CMSAds_Ky DESC";
            strFROMNet = "CMSAds_Vw";
            dtBannerTop1 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%2%' AND CMSAds_Province like '%" + strValue + "%'";
            strORDERNet = "CMSAds_Ky DESC";
            strFROMNet = "CMSAds_Vw";
            dtBannerTop2 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%3%' AND CMSAds_Province like '%" + strValue + "%'";
            strORDERNet = "CMSAds_Ky DESC";
            strFROMNet = "CMSAds_Vw";
            dtBannerBottom1 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%4%' AND CMSAds_Province like '%" + strValue + "%'";
            strORDERNet = "CMSAds_Ky DESC";
            strFROMNet = "CMSAds_Vw";
            dtBannerBottom2 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%5%' AND CMSAds_Province like '%" + strValue + "%'";
            strORDERNet = "CMSAds_Ky DESC";
            strFROMNet = "CMSAds_Vw";
            dtBannerSidebar1 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%6%' AND CMSAds_Province like '%" + strValue + "%'";
            strORDERNet = "CMSAds_Ky DESC";
            strFROMNet = "CMSAds_Vw";
            dtBannerSidebar2 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%8%' AND CMSAds_Province like '%" + strValue + "%'";
            strORDERNet = "CMSAds_Ky DESC";
            strFROMNet = "CMSAds_Vw";
            dtBannerSidebar3 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%9%' AND CMSAds_Province like '%" + strValue + "%'";
            strORDERNet = "CMSAds_Ky DESC";
            strFROMNet = "CMSAds_Vw";
            dtBannerSidebar4 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }

    }

    public string getWhere()
    {
        string strWHERE="";
        string strWHEREPermessi="";
        string strValue="";

        strWHERE="(AnnunciStato_Ky=1)";
        strValue = Request["AnnunciCategorie_Ky"];
        if (strValue != null && strValue != "" && strValue.Length>0){
            strValue=sanitize(strValue);
            if (strValue.Substring(0,1)==","){
              strValue=strValue.Substring(1,strValue.Length-1);              
            } 
            if (strValue.Substring(strValue.Length-1,1)==","){
              strValue=strValue.Substring(0,strValue.Length-1);              
            } 
            if (strValue != null && strValue != ""){
                strWHERE += " AND (AnnunciCategorie_Ky IN (" + strValue + ") OR AnnunciCategorie_Padre IN (" + strValue + "))";
            }
        }

        strValue = Request["AnnunciTipologie_Ky"];
        if (strValue != null && strValue != "" && strValue.Length>0){
            strValue=sanitize(strValue);
            if (strValue.Substring(0,1)==","){
              strValue=strValue.Substring(1,strValue.Length-1);              
            } 
            if (strValue.Substring(strValue.Length-1,1)==","){
              strValue=strValue.Substring(0,strValue.Length-1);              
            } 
            if (strValue != null && strValue != ""){
                strWHERE += " AND (AnnunciTipologie_Ky=" + strValue + ")";
            }
        }
        strValue = Request["Comuni_Ky"];
        strValue = sanitize(strValue);
        if (strValue != null && strValue != "" && strValue.Length>0){
            if (strValue.Substring(0,1)==","){
              strValue=strValue.Substring(1,strValue.Length-1);              
            } 
            if (strValue.Substring(strValue.Length-1,1)==","){
              strValue=strValue.Substring(0,strValue.Length-1);              
            } 
            if (strValue != null && strValue != ""){
                strWHERE += " AND (Comuni_Ky IN (" + strValue + "))";
            }
        }else{
              strValue = Request["Province_Ky"];
              strValue = sanitize(strValue);
              if (strValue != null && strValue != "" && strValue.Length>0){
                  if (strValue.Substring(0,1)==","){
                    strValue=strValue.Substring(1,strValue.Length-1);              
                  } 
                  if (strValue.Substring(strValue.Length-1,1)==","){
                    strValue=strValue.Substring(0,strValue.Length-1);              
                  } 
                  if (strValue != null && strValue != ""){
                      strWHERE += " AND (Province_Ky IN (" + strValue + "))";
                  }
              }else{
                  strValue = Request["Regioni_Ky"];
                  if (strValue != null && strValue != "" && strValue.Length>0){
                      strValue = sanitize(strValue);
                      if (strValue.Substring(0,1)==","){
                        strValue=strValue.Substring(1,strValue.Length-1);              
                      } 
                      if (strValue.Substring(strValue.Length-1,1)==","){
                        strValue=strValue.Substring(0,strValue.Length-1);              
                      } 
                      if (strValue != null && strValue != ""){
                          strWHERE += " AND (Regioni_Ky IN (" + strValue + "))";
                      }
                  }
              }
        }
        strValue = Request["ComuniZone_Ky"];
        strValue = sanitize(strValue);
        if (strValue != null && strValue != "" && strValue.Length>0){
            if (strValue.Substring(0,1)==","){
              strValue=strValue.Substring(1,strValue.Length-1);              
            } 
            if (strValue.Substring(strValue.Length-1,1)==","){
              strValue=strValue.Substring(0,strValue.Length-1);              
            } 
            if (strValue != null && strValue != ""){
                strWHERE += " AND (ComuniZone_Ky IN (" + strValue + "))";
            }
        }
        strValue = Request["prezzo"];
        strValue = sanitize(strValue);
        if (strValue != null && strValue != "" && strValue.Length>0){
            if (Int32.TryParse(strValue, out i) == false)
            {
                Response.Redirect("/");
            }
            switch (strValue){
                case "1":
                  strWHERE+=" AND (Annunci_Valore>0 AND Annunci_Valore<5000)";
                  break;
                case "2":
                  strWHERE+=" AND (Annunci_Valore>=5000 AND Annunci_Valore<10000)";
                  break;
                case "3":
                  strWHERE+=" AND (Annunci_Valore>=10000 AND Annunci_Valore<50000)";
                  break;
                case "4":
                  strWHERE+=" AND (Annunci_Valore>=50000 AND Annunci_Valore<150000)";
                  break;
                case "5":
                  strWHERE+=" AND (Annunci_Valore>=150000 AND Annunci_Valore<500000)";
                  break;
            }
        }
        /*
        strValue = Request["Annunci_Cerco"];
        if (strValue != null && strValue != "" && strValue.Length>0 && strValue=="1"){
                  strValue=strValue.Replace(".","");
                  strWHERE+=" AND (Annunci_Cerco=1)";
        }
        strValue = Request["Annunci_Offro"];
        if (strValue != null && strValue != "" && strValue.Length>0 && strValue=="1"){
                  strValue=strValue.Replace(".","");
                  strWHERE+=" AND (Annunci_Offro=1)";
        }
        */
        strValue = Request["prezzoda"];
        if (strValue != null && strValue != "" && strValue.Length>0){
            strValue=strValue.Replace(".","");
            strWHERE+=" AND (Annunci_Valore" + strValue + ")";
        }
        strValue = Request["prezzoa"];
        if (strValue != null && strValue != "" && strValue.Length>0){
            strValue=strValue.Replace(".","");
            strWHERE+=" AND (Annunci_Valore" + strValue + ")";
        }
        
        strValue = Request["camere"];
        if (strValue != null && strValue != "" && strValue.Length>0){
         if (strWHERE!=null && strWHERE.Length>0){
            strWHERE = strWHERE + " And (Annunci_NumeroCamere" + strValue + ")";
          }else{
            strWHERE = "(Immobili_NumeroCamereLetto" + strValue + ")";
          }
        }
        
        strValue = Request["bagni"];
        if (strValue != null && strValue != "" && strValue.Length>0){
         if (strWHERE!=null && strWHERE.Length>0){
            strWHERE = strWHERE + " And (Annunci_NumeroBagni" + strValue + ")";
          }else{
            strWHERE = "(Annunci_NumeroBagni" + strValue + ")";
          }
        }        
        
        strValue = Request["mqmin"];
        if (strValue != null && strValue != "" && strValue.Length>0){
         if (strWHERE!=null && strWHERE.Length>0){
            strWHERE = strWHERE + " And (Annunci_Mq" + strValue + ")";
          }else{
            strWHERE = "(Annunci_Mq" + strValue + ")";
          }
        }        
             
        //Response.Write(strWHERE);
        return strWHERE;
    }

    public string sanitize(string strIN){
      string strOUT="";
      string pattern = @"[^0-9^,]";

      if (strIN!=null && strIN.Length>0){
            Regex rgx = new Regex(pattern);
            strOUT = Regex.Replace(strIN, pattern, "");
      }else{
            strOUT = "";
      }


      return strOUT;
    }

    public string getAttributi(int indiceRecord, DataTable dtDati)
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";
        string strIcona="";

        strOutput="";   
        strAttributi=dtAnnunci.Rows[indiceRecord]["AnnunciCategorie_AttributiElenchi"].ToString();
        if (strAttributi.Length>0){
          
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           strIcona=drAttributiElenco[x]["Attributi_Icona"].ToString();
           if (strIcona!=null && strIcona.Length>0){
            strIcona="<i class=\"" + strIcona + " fa-fw\"></i>";
           }
           if (dtAnnunci.Rows[indiceRecord][strCodice].ToString().Length>0 && dtAnnunci.Rows[indiceRecord][strCodice].ToString()!="0"){
              switch (strTipo){
                case "1":
                    strOutput+="<span class=\"secondary\">" + strTitolo + " " + strIcona + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "2":
                    strOutput+="<span class=\"secondary\">" + strTitolo + " " + strIcona + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "3":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "4":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-square-check fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
                    break;  
                case "5":
                    strOutput+="<span class=\"secondary\">" + strTitolo + " " + strIcona + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "6":
                    strOutput+="<span class=\"secondary\">" + strTitolo + " " + strIcona + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;                  
              }
           }

          }
        }

        return strOutput;
    }


    public string StripHTML(string str){
        return System.Text.RegularExpressions.Regex.Replace(str, @"<(.|\n)*?>", string.Empty);
    }
}

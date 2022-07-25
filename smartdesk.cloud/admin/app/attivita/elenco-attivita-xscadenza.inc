<%
  string strHtml;
  System.Data.DataTable dtDaFareScaduti;
  System.Data.DataTable dtDaFareAppenaScaduti;
  System.Data.DataTable dtDaFareProssimi;
  System.Data.DataTable dtDaFareFuturi;
  System.Data.DataTable dtUtenti;
  int intNumeroAttivita = 0;
  string strHtmlCorpo = "";

  strFROMNet = "Utenti";
  strWHERENet= "Utenti_Ky=" + Smartdesk.Current.Request("Utenti_Ky");
  strORDERNet = "Utenti_Ky";
  dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  for (int j = 0; j < dtUtenti.Rows.Count; j++){
      strHtml+="<div><div class=\"grid-x grid-padding-x\"><div class=\"small-12 medium-12 large-12 cell align-middle\"><img src=\"" + dtUtenti.Rows[i]["Utenti_Logo"].ToString() + "\" width=\"40\" height=\"40\" align=\"left\" class=\"align-middle\" style=\"border-radius:50%\"><h2>" + dtUtenti.Rows[j]["Utenti_Nominativo"].ToString() + "</h2></div></div></div>";

      strHtml+="<div class=\"grid-x grid-padding-x\">";
      strHtml+="<div class=\"auto cell\">";
      strHtml+="<h2 class=\"text-center\" style=\"color:#ff7a59\">Scaduti da oltre 30gg (" + dtDaFareScaduti.Rows.Count + ")<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
      strHtml+="<div class=\"appenascaduti dropzone\" id=\"appenascaduti\">";
      intNumeroAttivita=0;
      strHtmlCorpo="";
      for (i = 0; i < dtDaFareScaduti.Rows.Count; i++){
          if (dtDaFareScaduti.Rows[i]["Utenti_Ky"].ToString()==dtUtenti.Rows[j]["Utenti_Ky"].ToString()){
              strHtml+=renderAttivita(dtDaFareScaduti.Rows[i],"scaduti");
              intNumeroAttivita++;
          }
      }
      strHtml+=strHtmlCorpo;
      strHtml+="</div>";
      strHtml+="</div>";

      strHtml+="<div class=\"auto cell\">";
      strHtml+="<h2 class=\"text-center\" style=\"color:#FFA726\">Scaduti da meno di 30gg (" + dtDaFareAppenaScaduti.Rows.Count + ")<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
      strHtml+="<div class=\"scaduti dropzone\">";
      intNumeroAttivita=0;
      strHtmlCorpo="";
      for (i = 0; i < dtDaFareAppenaScaduti.Rows.Count; i++){
          if (dtDaFareAppenaScaduti.Rows[i]["Utenti_Ky"].ToString()==dtUtenti.Rows[j]["Utenti_Ky"].ToString()){
              strHtml+=renderAttivita(dtDaFareAppenaScaduti.Rows[i],"appenascaduti");
              intNumeroAttivita++;
          }
      }
      if (intNumeroAttivita==0){
          strHtmlCorpo+="<div>Nessuna attivit&agrave;</div>";
      }
      strHtml+=strHtmlCorpo;
      strHtml+="</div>";
      strHtml+="</div>";

      strHtml+="<div class=\"auto cell\">";
      strHtml+="<h2 class=\"text-center\" style=\"color:#43ac6a\">Prossime scadenze (" + dtDaFareProssimi.Rows.Count + ")<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
      strHtml+="<div class=\"prossimi dropzone\">";
      intNumeroAttivita=0;
      strHtmlCorpo="";
      for (i = 0; i < dtDaFareProssimi.Rows.Count; i++){
          if (dtDaFareProssimi.Rows[i]["Utenti_Ky"].ToString()==dtUtenti.Rows[j]["Utenti_Ky"].ToString()){
              strHtml+=renderAttivita(dtDaFareProssimi.Rows[i],"prossimi");
              intNumeroAttivita++;
          }
      }
      if (intNumeroAttivita==0){
          strHtmlCorpo+="<div>Nessuna attivit&agrave;</div>";
      }
      strHtml+=strHtmlCorpo;
      strHtml+="</div>";
      strHtml+="</div>";

      strHtml+="<div class=\"auto cell\">";
      strHtml+="<h2 class=\"text-center\" style=\"color:#000000\">Scadenze future (" + dtDaFareFuturi.Rows.Count + ")<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
      strHtml+="<div class=\"futuri dropzone\">";
      intNumeroAttivita=0;
      strHtmlCorpo="";
      for (i = 0; i < dtDaFareFuturi.Rows.Count; i++){
          if (dtDaFareFuturi.Rows[i]["Utenti_Ky"].ToString()==dtUtenti.Rows[j]["Utenti_Ky"].ToString()){
              strHtml+=renderAttivita(dtDaFareFuturi.Rows[i],"prossimi");
              intNumeroAttivita++;
          }
      }
      if (intNumeroAttivita==0){
          strHtmlCorpo+="<div>Nessuna attivit&agrave;</div>";
      }
      strHtml+=strHtmlCorpo;
      strHtml+="</div>";
      strHtml+="</div>";
      strHtml+="</div>";
  }
%>

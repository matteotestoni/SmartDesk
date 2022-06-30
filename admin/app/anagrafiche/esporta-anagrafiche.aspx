<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="esporta-anagrafiche.aspx.cs" Inherits="_Default" Debug="true"%>
<%
	//Response.Clear();
	Response.ContentType = "text/plain";
  Response.Write(strCampi+"\r\n");
	for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){
		//Response.Write("\"" + i.ToString() + "\",");

  	if (strCampi.IndexOf("Anagrafiche_Ky")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString().Replace("\"","") + "\",");
		}

  	if (strCampi.IndexOf("Anagrafiche_RagioneSociale")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_RagioneSociale"].ToString().Replace("\"","") + "\",");
		}

  	if (strCampi.IndexOf("Comuni_Ky")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Comuni_Ky"].ToString().Replace("\"","") + "\",");
		}
  	if (strCampi.IndexOf("Comuni_Comune")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Comuni_Comune"].ToString().Replace("\"","") + "\",");
		}

  	if (strCampi.IndexOf("Province_Ky")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Province_Ky"].ToString().Replace("\"","") + "\",");
		}

  	if (strCampi.IndexOf("Province_Provincia")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Province_Provincia"].ToString().Replace("\"","") + "\",");
		}

  	if (strCampi.IndexOf("Regioni_Ky")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Regioni_Ky"].ToString().Replace("\"","") + "\",");
		}

  	if (strCampi.IndexOf("Regioni_Regione")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Regioni_Regione"].ToString().Replace("\"","") + "\",");
		}

  	if (strCampi.IndexOf("Nazioni_Ky")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Nazioni_Ky"].ToString().Replace("\"","") + "\",");
		}

  	if (strCampi.IndexOf("Nazioni_Nazione")>=0){
			Response.Write("\"" + dtAnagrafiche.Rows[i]["Nazioni_Nazione"].ToString().Replace("\"","") + "\",");
		}
   	
		if (strCampi.IndexOf("Anagrafiche_EmailContatti")>=0){
 	  		Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_EmailContatti"].ToString() + "\",");
		}

		if (strCampi.IndexOf("Anagrafiche_EmailAmministrazione")>=0){
 	  	Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_EmailAmministrazione"].ToString() + "\",");
		}

		if (strCampi.IndexOf("Anagrafiche_PEC")>=0){
 	  	Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_PEC"].ToString() + "\",");
		}
   	
		if (strCampi.IndexOf("Anagrafiche_Telefono")>=0){
  		Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_Telefono"].ToString() + "\",");
		}

		if (strCampi.IndexOf("Anagrafiche_DataInserimento")>=0){
  		Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_DataInserimento"].ToString() + "\",");
		}

		if (strCampi.IndexOf("Anagrafiche_CodiceDestinatario")>=0){
  		Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_CodiceDestinatario"].ToString() + "\",");
		}
		
		if (strCampi.IndexOf("Anagrafiche_Origine")>=0){
  		    Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_Origine"].ToString() + "\",");
		}

		if (strCampi.IndexOf("Anagrafiche_Privacy")>=0){
  		    Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_Privacy"].ToString() + "\",");
		}

		if (strCampi.IndexOf("Anagrafiche_Newsletter")>=0){
  		    Response.Write("\"" + dtAnagrafiche.Rows[i]["Anagrafiche_Newsletter"].ToString() + "\"");
		}

  	Response.Write("\r\n");
  }
%>

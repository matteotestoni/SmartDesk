<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/esporta-lead.aspx.cs" Inherits="_Default" Debug="true"%>
<%
	//Response.Clear();
	Response.ContentType = "text/plain";
  Response.Write(strCampi+"\r\n");
	for (int i = 0; i < dtLead.Rows.Count; i++){
		
    string[] arrayCampi = strCampi.Split(',');
    foreach (string strCampo in arrayCampi){
	    Response.Write("\"" + dtLead.Rows[i][strCampo].ToString().Trim().Replace("\"","").Replace("\n","").Replace("\r","").Replace("\t", "") + "\",");
    }    
  	Response.Write("\r\n");
  }
%>

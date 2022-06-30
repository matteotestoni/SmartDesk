<%@ LANGUAGE="VBSCRIPT" codepage=65001 ENABLESESSIONSTATE=False%>
<%
  Option Explicit
  Response.Buffer = True
  Response.Expires = 0
  Server.ScriptTimeout = 14400
  Response.AddHeader "Access-Control-Allow-Origin","*"

  Dim xm
  Dim cn
  Dim cm
  Dim st
  Dim dm
  Dim sUdl
		
  Set xm = Server.CreateObject("microsoft.FreeThreadedxmldom")
	Set cn = Server.CreateObject("ADODB.Connection")
	Set cm = Server.CreateObject("ADODB.Command")
	Set st = Server.CreateObject("ADODB.Stream")
	xm.Async=false
	Response.ContentType="text/xml"
	if Request.TotalBytes>0 then
		xm.Load (Request)
	end if	
    cn.Open "File name=" & Server.MapPath("/admin/db.udl")
	st.Open
	cm.ActiveConnection = cn
	cm.CommandText = xm.getElementsByTagName("st").item(0).text
	cm.CommandType = 4
	cm.Properties("Output Stream") = st
    cm.Parameters("@XmlDoc") = xm.Xml
	cm.Execute ,, 1028
	st.Position = 0
	Response.write st.ReadText(-1)
	cn.Close
	Set cm = Nothing
	Set st = Nothing
	Set cn = Nothing
	set xm = Nothing	
%>

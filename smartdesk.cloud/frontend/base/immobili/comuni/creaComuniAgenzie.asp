<%
  Server.ScriptTimeOut=960
  Dim strCurrentPath
  Dim strPath1
  Dim MyFile1
  Dim fso
  Dim strSQL
  Dim Con
  Dim RSProvince
  Dim RSComuni
  Dim strComune
  Dim i
  Dim intColonne
  Dim intNumComunixCol
  Dim strClass

  Function IsoToUtf(mT)
  Dim T
  T=mT
  if T<>"" then 
  	T=replace(T,"&","&amp;")
  	T=replace(T,">","&#62;")
  	T=replace(T,"<","&#60;")
  	T=replace(T,"à","&#224;")
  	T=replace(T,"è","&#232;")
  	T=replace(T,"é","&#233;")
  	T=replace(T,"ò","&#242;")
  	T=replace(T,"ì","&#236;")
  	T=replace(T,"ù","&#249;")
  	T=replace(T,"°","&#176;")
  	T=replace(T,"£","&#163;")
  	'T=replace(T,"'","''")
  	T=replace(T," ","&nbsp;")
  end if	
  	IsoToUtf=T
  End Function  
  
  Function sistemaUrl(mT)
  Dim T
  T=mT
  if T<>"" then 
  	T=replace(T," ","%20")
  	T=replace(T,"ì","i")
  	T=replace(T,"'","%27")
  end if	
  	sistemaUrl=T
  End Function  
  
  set Con = Server.CreateObject("ADODB.Connection")
  strUDL="Provider=SQLOLEDB.1;Password=I2u7IgVhGmsn;Persist Security Info=True;User ID=parasitewr;Initial Catalog=Db_Parasite;Data Source=localhost"
  Con.open strUDL
  intColonne=4
  set RSProvince = Server.CreateObject("ADODB.Recordset")
  set RSComuni = Server.CreateObject("ADODB.Recordset")
  RSProvince.ActiveConnection = Con
  RSComuni.ActiveConnection = Con
  Set objFso = Server.CreateObject("Scripting.FileSystemObject")
  strSQL = "SELECT * FROM Province ORDER BY Province_Ky"
  RSProvince.Open strSQL, , 0, 1
  strCurrentPath=server.mappath(".")
  Response.Write "<ul>"
  do while RSProvince.eof=false
    Response.Write "<li>" & RSProvince("Province_Provincia") & "</li>"
    strPath1=sistemaUrl(RSProvince("Province_ProvinciaHTML")) & ".htm"
    strPath1=strCurrentPath & "\agenzie-immobiliari\" & strPath1
    Set MyFile1 = objFso.CreateTextFile(strPath1, True)
      MyFile1.WriteLine "<li><a href=""/" & LCase(RSProvince("Province_ProvinciaHTML")) & "/agenzie-immobiliari-provincia-" & LCase(RSProvince("Province_ProvinciaHTML")) & ".html"" title=""agenzie immobiliari " & RSProvince("Province_Provincia") & """>" & RSProvince("Province_Provincia") & "</a></li>"
      strSQL = "SELECT * FROM Comuni_Vw WHERE (Province_Ky=" & RSProvince("Province_Ky") & ") ORDER BY Comuni_Comune"
      RSComuni.Open strSQL, , 3, 3
      i=0
      do while RSComuni.eof=false
        MyFile1.WriteLine "<li><a href=""/" & LCase(RSProvince("Province_ProvinciaHTML")) & "/agenzie-immobiliari-" & LCase(RSComuni("Comuni_ComuneHTML")) & ".html"" title=""agenzie immobiliari " & RSComuni("Comuni_Comune") & """><i class="" fas fa-map-marker-alt fa-fw""></i>" & RSComuni("Comuni_Comune") & "</a></li>"
        i=i+1
        RSComuni.MoveNext
      Loop
      RSComuni.Close
    RSProvince.movenext
    MyFile1.Close
  loop
  Response.Write "</ul>"
  RSProvince.Close
  Set MyFile1=Nothing
  Set RSProvince=nothing
  Set RSComuni=nothing
  Set Con=nothing
%>

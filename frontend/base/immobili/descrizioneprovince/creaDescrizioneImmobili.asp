Contenuti provincia
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
  Dim RSProvinceRegione
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
  
  Set Con = Server.CreateObject("ADODB.Connection")
  set RSProvince = Server.CreateObject("ADODB.Recordset")
  set RSProvinceRegione = Server.CreateObject("ADODB.Recordset")
  set RSComuni = Server.CreateObject("ADODB.Recordset")
  
  strUDL="Provider=SQLOLEDB.1;Password=I2u7IgVhGmsn;Persist Security Info=True;User ID=parasitewr;Initial Catalog=Db_Parasite;Data Source=localhost"
  Con.CommandTimeout = 0
  Con.open strUDL
  RSProvince.ActiveConnection = Con
  RSComuni.ActiveConnection = Con
  RSProvinceRegione.ActiveConnection = Con
  Set objFso = Server.CreateObject("Scripting.FileSystemObject")
  strSQL = "SELECT * FROM Province ORDER BY Province_Ky"
  RSProvince.Open strSQL, , 0, 1
  strCurrentPath=server.mappath(".")
  do while RSProvince.eof=false
    strPath1=sistemaUrl(RSProvince("Province_ProvinciaHTML")) & ".htm"
    strPath1=strCurrentPath & "\annunci-immobiliari\" & strPath1
      Set MyFile1 = objFso.CreateTextFile(strPath1, True)
      strSQL = "SELECT * FROM Province WHERE (Regioni_Codice='" & RSProvince("Regioni_Codice") & "') ORDER BY Province_Provincia"
      RSProvinceRegione.Open strSQL, , 3, 3
      i=0
      strProvinceRegione="PROVINCE:"
      do while RSProvinceRegione.eof=false
        strProvinceRegione=strProvinceRegione & " <a href=""/" & LCase(RSProvinceRegione("Province_ProvinciaHTML")) & "/vendita-case-provincia-" & LCase(RSProvinceRegione("Province_ProvinciaHTML"))& ".html"" class=""linkfooter"" title=""case " & RSProvinceRegione("Province_Provincia") & """>" & RSProvinceRegione("Province_Provincia") & "</a> |"
        i=i+1
        RSProvinceRegione.MoveNext
      Loop
      RSProvinceRegione.Close
      MyFile1.WriteLine "<p><strong>" & RSProvince("Province_Provincia") & " affitti e vendite</strong>: se stai cercando affitti e vendite di <b>case " & RSProvince("Province_Provincia") & "</b>,appartamenti " & RSProvince("Province_Provincia") & ",villette " & RSProvince("Province_Provincia") & " o altri residenziali a " & RSProvince("Province_Provincia") & " consulta il nostro database per superficie, prezzo, bagni, locali, camere da letto.</p><p align=""justify"">Tra gli <b>affitti e vendite case a " & RSProvince("Province_Provincia") & "</b> puoi trovare qualunque tipologia</p><p>" & strProvinceRegione & "</p>"
    RSProvince.movenext
    MyFile1.Close
  loop
  RSProvince.Close
  Set MyFile1=Nothing
  Set RSProvince=nothing
  Set RSComuni=nothing
  Set Con=nothing
  Response.Write "finito"
%>
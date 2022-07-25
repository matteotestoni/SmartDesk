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
  Dim RSProvinceRegione
  Dim strProvinceRegione
  Dim i
  Dim intColonne
  Dim intNumComunixCol
  Dim strClass
  Dim strElencoComuni

  Function IsoToUtf(mT)
  Dim T
  T=mT
  if T<>"" then 
  	T=replace(T,"&","&amp;")
  	T=replace(T,">","&#62;")
  	T=replace(T,"<","&#60;")
  	T=replace(T,"�","&#224;")
  	T=replace(T,"�","&#232;")
  	T=replace(T,"�","&#233;")
  	T=replace(T,"�","&#242;")
  	T=replace(T,"�","&#236;")
  	T=replace(T,"�","&#249;")
  	T=replace(T,"�","&#176;")
  	T=replace(T,"�","&#163;")
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
  	T=replace(T,"�","i")
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
  set RSProvinceRegione = Server.CreateObject("ADODB.Recordset")
  RSProvinceRegione.ActiveConnection = Con
  RSProvince.ActiveConnection = Con
  RSComuni.ActiveConnection = Con
  Set objFso = Server.CreateObject("Scripting.FileSystemObject")
  strSQL = "SELECT * FROM Province ORDER BY Province_Ky"
  RSProvince.Open strSQL, , 0, 1
  strCurrentPath=Server.MapPath(".")
  Response.Write "<ul>"
  do while RSProvince.eof=false
    Response.Write "<li>" &  RSProvince("Province_Provincia") & "</li>"
    strPath1=sistemaUrl(RSProvince("Province_ProvinciaHTML")) & ".htm"
    strPath1=strCurrentPath & "\agenzie-immobiliari\" & strPath1
    strElencoComuni=""
    Set MyFile1 = objFso.CreateTextFile(strPath1, True)
      strSQL = "SELECT * FROM Comuni_Vw WHERE (Province_Ky=" & RSProvince("Province_Ky") & ") ORDER BY Comuni_Ky"
      RSComuni.Open strSQL, , 3, 3
      i=0
      do while RSComuni.eof=false
        strElencoComuni=strElencoComuni & RSComuni("Comuni_Comune") & " "
        i=i+1
        RSComuni.MoveNext
      Loop
      RSComuni.Close
      'Province
      strSQL = "SELECT * FROM Province WHERE (Regioni_Codice='" & RSProvince("Regioni_Codice") & "') ORDER BY Province_Provincia"
      RSProvinceRegione.Open strSQL, , 3, 3
      i=0
      strProvinceRegione="PROVINCE:"
      do while RSProvinceRegione.eof=false
        strProvinceRegione=strProvinceRegione & " <a href=""/" & LCase(RSProvinceRegione("Province_ProvinciaHTML")) & "/agenzie-immobiliari-provincia-" & LCase(RSProvinceRegione("Province_ProvinciaHTML"))& ".html"" title=""agenzie immobiliari " & RSProvinceRegione("Province_Provincia") & """>" & RSProvinceRegione("Province_Provincia") & "</a> |"
        i=i+1
        RSProvinceRegione.MoveNext
      Loop
      RSProvinceRegione.Close
      MyFile1.WriteLine "<p>Naviga per cercare le <strong>agenzie immobiliari " & RSProvince("Province_Provincia") & "</strong>, i <strong>franchising immobiliari " & RSProvince("Province_Provincia") & "</strong> per te tra tutte le agenzie nel nostro database per ragione sociale, localit&agrave;. Se vuoi inserire annunci sul nostro portale visita la nostra sezione dedicata</p><p>" & strProvinceRegione & "</p>"
    RSProvince.movenext
    MyFile1.Close
  loop
  RSProvince.Close
  Response.Write "</ul>"
  Set MyFile1=Nothing
  Set RSProvince=nothing
  Set RSComuni=nothing
  Set Con=nothing
%>

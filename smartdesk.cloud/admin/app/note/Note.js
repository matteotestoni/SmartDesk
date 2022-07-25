//javascript
function printschedanote(){
  var strKy=jQuery("#Note_Ky").val();
  var strUrl="/admin/app/note/report/rpt-note.aspx?Note_Ky=" + strKy;
  //console.log(strUrl);
  window.open(strUrl,'_blank');
}

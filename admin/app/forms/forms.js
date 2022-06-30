function preview(){
    strForms_Ky=jQuery("#Forms_Ky").val();
    strAnagrafiche_Ky=jQuery("#Anagrafiche_Ky").val();
    strUrl="/admin/app/forms/anteprima-forms.aspx?CoreModules_Ky=16&CoreEntities_Ky=146&CoreGrids_Ky=96&CoreForms_Ky=151&Forms_Ky=" + strForms_Ky;
    window.open(strUrl);
}

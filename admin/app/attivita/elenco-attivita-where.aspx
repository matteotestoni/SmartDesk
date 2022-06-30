<h4>Filtri</h4>
<form action="<%=HttpContext.Current.Request.Url.AbsoluteUri%>" name="formRicerca" id="formRicerca">
  <input type="hidden" name="CoreModules_Ky" value="6" />
  <input type="hidden" name="CoreEntities_Ky" value="79" />
  <input type="hidden" name="CoreGrids_Ky" value="62" />
  <div class="input-group">
  	<select name="Utenti_Ky" id="Utenti_Ky" class="input-group-field select2">
      <option value=""></option>
      <!--#include file="/var/cache/Utenti-options-select2.htm"--> 
    </select>
    <div class="input-group-button">
      <button type="submit" value="cerca" name="cerca" class="tiny button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
    </div>
  </div>
</form>


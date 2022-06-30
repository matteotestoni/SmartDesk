	<%if (Request["salvato"]=="salvato"){%>
		<div class="tiny reveal success callout" id="message" data-reveal data-close-on-click="true" data-animation-in="fade-in" data-animation-out="fade-out">
    			<i class="fa-duotone fa-circle-info fa-lg fa-fw pull-left"></i>
    			Salvato
        <button class="close-button" data-close aria-label="Close modal" type="button">
          <span aria-hidden="true">&times;</span>
        </button>
    </div>
	<%}%>
	<div data-abide-error class="alert callout" style="display: none;">
		<p><i class="fa-duotone fa-triangle-exclamation-triangle fa-lg fa-fw"></i>Ci sono errori nel tuo modulo: compila tutti i campi richiesti e controlla i formati.</p>
	</div>

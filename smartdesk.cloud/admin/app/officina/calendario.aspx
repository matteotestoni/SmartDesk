<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/officina/calendario.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
  <title>Calendario</title>
	<!--#include file="/admin/inc-head.aspx"-->
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.0/main.min.css" integrity="sha256-5veQuRbWaECuYxwap/IOE/DAwNxgm4ikX7nrgsqYp88=" crossorigin="anonymous">
  <script src="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.0/main.min.js" integrity="sha256-XCdgoNaBjzkUaEJiauEq+85q/xi/2D4NcB3ZHwAapoM=" crossorigin="anonymous"></script>
  <script src="https://cdn.jsdelivr.net/npm/fullcalendar@5.11.0/locales-all.min.js" integrity="sha256-GcByKJnun2NoPMzoBsuCb4O2MKiqJZLlHTw3PJeqSkI=" crossorigin="anonymous"></script>
  <style>
    .fc .fc-toolbar-title{ font-size:1.5rem !important}
  </style>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header sticky" data-sticky="content-header" data-margin-top="0">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-5 small-12 cell align-middle">
              <h1><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Officina > <%=strH1%></h1>
          </div>
          <div class="large-8 medium-7 small-12 cell float-right align-middle">
        		<div class="stacked-for-small button-group small hide-for-print align-right">
        			<button class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</button>
              <% if (dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString()=="3"){ %>
              <a href="/admin/form.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=244&CoreForms_Ky=<%=strCoreForms_Ky%>&custom=0&azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
              <% } %>			
      		</div>
        </div>
  	</div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
			<fieldset class="filtri fieldset hide-for-print" id="filtri" data-toggler=".hide" style="padding:0.25rem">
					<legend>Cerca officina</legend>
          <div class="grid-x">
            <div class="large-4 medium-4 small-12 cell">
                <form id="formRicerca1" class="formRicerca" method="get" action="/admin/view.aspx">
      						<input type="hidden" name="CoreModules_Ky" value="33">
      						<input type="hidden" name="CoreEntities_Ky" value="231">
      						<input type="hidden" name="CoreGrids_Ky" value="<%=strCoreGrids_Ky%>">		
                  <div class="input-group">
                    <span class="input-group-label" style="min-width:100px">Nominativo</span>
                    <input class="input-group-field" type="text" name="Officina_Nominativo" id="Officina_Nominativo">
                    <div class="input-group-button">
      						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
                    </div>
                  </div>
                </form>
            </div>
            <div class="large-4 medium-4 small-12 cell">
      					<form id="formRicerca2" class="formRicerca" method="get" action="/admin/view.aspx">
      						<input type="hidden" name="CoreModules_Ky" value="33">
      						<input type="hidden" name="CoreEntities_Ky" value="231">
      						<input type="hidden" name="CoreGrids_Ky" value="<%=strCoreGrids_Ky%>">		
                  <div class="input-group">
                    <span class="input-group-label" style="min-width:100px">Targa</span>
                    <input class="input-group-field" type="text" name="Officina_TargaVettura" id="Officina_TargaVettura">
                    <div class="input-group-button">
      						    <button type="submit" value="cerca" name="cerca" class="button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
                    </div>
                  </div>
                </form>
            </div>
            <div class="large-4 medium-4 small-12 cell">
              <ul class="menu horizontal">
                <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=<%=strCoreGrids_Ky%>&OfficinaTipoauto_Ky=1">Auto nuove</a></li>
                <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=<%=strCoreGrids_Ky%>&OfficinaTipoauto_Ky=2">Auto usate</a></li>
                <li><a href="/admin/view.aspx?CoreModules_Ky=33&CoreEntities_Ky=231&CoreGrids_Ky=<%=strCoreGrids_Ky%>&OfficinaTipoauto_Ky=3">Auto km 0</a></li>
              </ul>
            </div>
          </div>
  </div>
</div>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
      <div class="divcalendar" style="margin-top:0;">
            <div class="divgrid">
        		  <div id="calendar"></div>
        		</div>
      </div>
  </div>
</div>

<!--#include file=/admin/inc-footer.aspx -->
<script type="text/javascript">

  var currentUpdateEvent;
  var addStartDate;
  var addEndDate;
  var globalAllDay;
  
  function updateEvent(event, element) {
      currentUpdateEvent = event;
      jQuery('#updatedialog').dialog('open');
      jQuery("#eventName").val(event.title);
      jQuery("#eventDesc").val(event.description);
      jQuery("#eventId").val(event.id);
      jQuery("#eventStart").text("" + event.start.toLocaleString());
  
      if (event.end === null) {
          jQuery("#eventEnd").text("");
      }
      else {
          jQuery("#eventEnd").text("" + event.end.toLocaleString());
      }
  
      return false;
  }
  
  function updateSuccess(updateResult) {
      //alert(updateResult);
  }
  
  function deleteSuccess(deleteResult) {
      //alert(deleteResult);
  }
  
  function addSuccess(addResult) {
  // if addresult is -1, means event was not added
  //    alert("added key: " + addResult);
  
      if (addResult != -1) {
      }
  }
  
  function UpdateTimeSuccess(updateResult) {
      //alert(updateResult);
  }
  
  function selectDate(start, end, allDay) {
  
      jQuery('#addDialog').dialog('open');
      jQuery("#addEventStartDate").text("" + start.toLocaleString());
      jQuery("#addEventEndDate").text("" + end.toLocaleString());
  
      addStartDate = start;
      addEndDate = end;
      globalAllDay = allDay;
      //alert(allDay);
  }
  
  function updateEventOnDropResize(event, allDay) {
  
      //alert("allday: " + allDay);
      var eventToUpdate = {
          id: event.id,
          start: event.start
      };
  
      if (event.end === null) {
          eventToUpdate.end = eventToUpdate.start;
      }
      else {
          eventToUpdate.end = event.end;
      }
  
      var endDate;
      if (!event.allDay) {
          endDate = new Date(eventToUpdate.end + 60 * 60000);
          endDate = endDate.toJSON();
      }
      else {
          endDate = eventToUpdate.end.toJSON();
      }
  
      eventToUpdate.start = eventToUpdate.start.toJSON();
      eventToUpdate.end = eventToUpdate.end.toJSON(); //endDate;
      eventToUpdate.allDay = event.allDay;
  
      PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);
  }
  
  function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {
      updateEventOnDropResize(event);
  }
  
  function eventResized(event, dayDelta, minuteDelta, revertFunc) {
      updateEventOnDropResize(event);
  }
  
  function checkForSpecialChars(stringToCheck) {
      var pattern = /[^A-Za-z0-9 ]/;
      return pattern.test(stringToCheck); 
  }
  
  function isAllDay(startDate, endDate) {
      var allDay;
  
      if (startDate.format("HH:mm:ss") == "00:00:00" && endDate.format("HH:mm:ss") == "00:00:00") {
          allDay = true;
          globalAllDay = true;
      }
      else {
          allDay = false;
          globalAllDay = false;
      }
      
      return allDay;
  }
  
  jQuery(document).ready(function() {
      var calendarEl = document.getElementById('calendar');
      var calendar = new FullCalendar.Calendar(calendarEl, {
          headerToolbar: {
            left: 'prevYear,prev,next,nextYear today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
          },
          views: {
            listWeek: { buttonText: 'Agenda' }
          },
          initialView: 'timeGridWeek',
          themeSystem: "standard",
          locale: 'it',
          height: 650,
          contentHeight: 630,
          allDaySlot: false,
   				aspectRatio: 2,
          slotMinTime: '09:00',
          slotMaxTime: '19:30',
          firstDay: 1,
  				weekends: <%=boolWeekend.ToString().ToLower()%>,
          editable: false,
          nowIndicator: true,
          selectable: false,
          select: function(arg) {
            var title = prompt('Event Title:');
            if (title) {
              calendar.addEvent({
                title: title,
                start: arg.start,
                end: arg.end,
                allDay: arg.allDay
              })
            }
            calendar.unselect()
          },
          eventClick: function(info) {
            //alert('Event: ' + info.event.title  + '-' + info.event.id);
            info.el.style.borderColor = 'red';
          },
          events: "calendario.ashx",
          navLinks: true
      }); 
      calendar.render();
   });
</script>
</body>
</html>

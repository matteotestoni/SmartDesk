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
				weekends: true,
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

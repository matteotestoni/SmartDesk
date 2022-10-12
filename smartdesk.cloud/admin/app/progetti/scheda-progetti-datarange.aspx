        <div class="input-group">
          <span class="input-group-label">Periodo (MM-DD-YYYY)</span>
          <input class="input-group-field" type="text" name="periodo" id="periodo">
          <div class="input-group-button">
            <button type="submit" class="button" onclick="javascript:updateReport();"><i class="fa-duotone fa-eye fa-fw"></i>Aggiorna</button>
          </div>
        </div>
        <script>
          function updateReport(){
            location.reload();
          }
          
          strReportdatarangestart=Cookies.get("reportdatarangestart");
          if (strReportdatarangestart==null && strReportdatarangestart==undefined){
            strReportdatarangestart=moment().startOf('month');
            //Cookies.set("reportdatarangestart", moment().startOf('month').format('MM-DD-YYYY'), { secure: true, sameSite: 'Lax', expires: 180, path: '/' });
          }
          console.log(strReportdatarangestart);
          strReportdatarangeend=Cookies.get("reportdatarangeend");
          if (strReportdatarangeend==null && strReportdatarangeend==undefined){
            strReportdatarangeend=moment().endOf('month');
          }
          console.log(strReportdatarangeend);
          jQuery('#periodo').daterangepicker({
              "showDropdowns": true,
              "timePicker24Hour": true,
              ranges: {
                  'Oggi': [moment().subtract(1, 'days'), moment().add(1, 'days')],
                  'Ieri': [moment().subtract(1, 'days'), moment()],
                  'Ultimi 7 giorni': [moment().subtract(6, 'days'), moment().add(1, 'days')],
                  'Ultimi 30 giorni': [moment().subtract(29, 'days'), moment().add(1, 'days')],
                  'Ultimi 45 giorni': [moment().subtract(44, 'days'), moment().add(1, 'days')],
                  'Questo mese': [moment().startOf('month'), moment().endOf('month')],
                  'Ultimo mese': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
                  'Ultimi 365gg': [moment().subtract(364, 'days'), moment().add(1, 'days')]
              },
              "locale": {
                  "format": "MM/DD/YYYY",
                  "separator": " - ",
                  "applyLabel": "Applica",
                  "cancelLabel": "Annulla",
                  "fromLabel": "Da",
                  "toLabel": "A",
                  "customRangeLabel": "Personalizzato",
                  "weekLabel": "W",
                  "daysOfWeek": [
                      "Do",
                      "Lu",
                      "Ma",
                      "Me",
                      "Gio",
                      "Ve",
                      "Sa"
                  ],
                  "monthNames": [
                      "gennaio",
                      "febbraio",
                      "marzo",
                      "aprile",
                      "maggio",
                      "giugno",
                      "luglio",
                      "agosto",
                      "settembre",
                      "ottobre",
                      "novembre",
                      "dicembre"
                  ],
                  "firstDay": 1
              },
              "showCustomRangeLabel": true,
              "alwaysShowCalendars": true,
              "startDate": strReportdatarangestart,
              "endDate": strReportdatarangeend,
              "drops": "auto",
              "autoApply": true,
              "autoUpdateInput": true
          }, function(start, end, label) {
            Cookies.set("reportdatarangestart", start.format('MM-DD-YYYY'), { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
            Cookies.set("reportdatarangeend", end.format('MM-DD-YYYY'), { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
            //console.log('New date range selected: ' + start.format('MM-DD-YYYY') + ' to ' + end.format('MM-DD-YYYY') + ' (predefined range: ' + label + ')');
            location.reload();
          });

        </script>


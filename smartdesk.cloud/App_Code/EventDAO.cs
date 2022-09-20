using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// EventDAO class is the main class which interacts with the database. SQL Server express edition
/// has been used.
/// the event information is stored in a table named 'event' in the database.
///
/// Here is the table format:
/// event(event_id int, title varchar(100), description varchar(200),event_start datetime, event_end datetime)
/// event_id is the primary key
/// </summary>
public class EventDAO
{
	//change the connection string as per your database connection.
    private static string connectionString = ConfigurationManager.AppSettings["DBConnString"];

	//this method retrieves all events within range start-end
    public static List<CalendarEvent> getEvents(DateTime start, DateTime end)
    {   
 		string strSQL = "";
		string strTemp = "";
		DateTime dtTemp;
		TimeSpan tmTemp;
        List<CalendarEvent> events = new List<CalendarEvent>();
        SqlConnection con = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        SqlConnection con2 = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
    		strSQL="SELECT Attivita_Ky, Attivita_Descrizione, AttivitaTipo_Descrizione, Attivita_Inizio As Attivita_Inizio, Attivita_Scadenza As Attivita_Scadenza, Utenti_Ky, Utenti_Nominativo, Utenti_Colore, Anagrafiche_Ky, Anagrafiche_RagioneSociale FROM Attivita_Vw WHERE (Attivita_Chiusura Is Null Or Attivita_Chiusura=0) And (Attivita_Scadenza>=@start AND Attivita_Scadenza<=@end)";
    		SqlCommand cmd = new SqlCommand(strSQL, con);
		    cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = start;
        cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = end;
        
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
			       while (reader.Read())
            {
                CalendarEvent cevent = new CalendarEvent();
                cevent.id = (int)reader["Attivita_Ky"];
                strTemp=(string)reader["Attivita_Descrizione"];
                strTemp=strTemp.Replace("\n",String.Empty);
                
				//if (strTemp.Length>40){
				//	strTemp=strTemp.Substring(0,40);
				//}
				cevent.description = strTemp;
				dtTemp = (DateTime)reader["Attivita_Scadenza"];
				//tmTemp = (TimeSpan)reader["Attivita_OraScadenza"];
				dtTemp = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, dtTemp.Hour, dtTemp.Minute, dtTemp.Second);
				cevent.start = dtTemp;
                strTemp=(string)reader["Utenti_Nominativo"] + "-" + (string)reader["Anagrafiche_RagioneSociale"] + "-" + strTemp;
                //if (strTemp.Length>20){
				//	strTemp=strTemp.Substring(0,20);
				//}
				cevent.title = strTemp;
				dtTemp = (DateTime)reader["Attivita_Scadenza"];
				//tmTemp = (TimeSpan)reader["Attivita_OraScadenza"];
				dtTemp = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, dtTemp.Hour, dtTemp.Minute, dtTemp.Second);
                cevent.end = dtTemp;
                cevent.bgcolor = (string)reader["Utenti_Colore"];
                cevent.color = (string)reader["Utenti_Colore"];
                cevent.persona = (int)reader["Utenti_Ky"];
                cevent.allDay = false;
                cevent.display = "";
                cevent.url = "/admin/app/attivita/scheda-attivita.aspx?source=calendario&Attivita_Ky=" +(int)reader["Attivita_Ky"];
                events.Add(cevent);
            }
        }
		strSQL="SELECT PersoneAssenze_Ky, PersoneAssenze_Descrizione, PersoneAssenzeTipo_Descrizione, Convert(date, PersoneAssenze_Data) As PersoneAssenze_Data, Persone_Ky, Persone_Nome,Persone_Cognome, Persone_Colore FROM PersoneAssenze_Vw WHERE (PersoneAssenzeTipo_Ky=1 Or PersoneAssenzeTipo_Ky=3) AND PersoneAssenze_Data>=@start AND PersoneAssenze_Data<=@end";
		SqlCommand cmdAssenze = new SqlCommand(strSQL, con2);
        cmdAssenze.Parameters.AddWithValue("@start", start);
        cmdAssenze.Parameters.AddWithValue("@end", end);
		//if (persona!=null && persona.Length>0){
    	//	cmdAssenze.Parameters.AddWithValue("@persona", persona);
        //}
        using (con2)
        {
        	con2.Open();
            SqlDataReader reader = cmdAssenze.ExecuteReader();
            while (reader.Read())
            {
                CalendarEvent cevent = new CalendarEvent();
                cevent.id = (int)reader["PersoneAssenze_Ky"];
                cevent.description = (string)reader["PersoneAssenze_Descrizione"];
        				dtTemp = (DateTime)reader["PersoneAssenze_Data"];
        				//tmTemp = (TimeSpan)reader["PersoneAssenze_Data"];
        				cevent.start = dtTemp;
                cevent.title = (string)reader["Persone_Nome"] + "-" + (string)reader["PersoneAssenze_Descrizione"];
        				dtTemp = (DateTime)reader["PersoneAssenze_Data"];
        				//tmTemp = (TimeSpan)reader["PersoneAssenze_Data"];
                cevent.end = dtTemp;
                cevent.bgcolor = (string)reader["Persone_Colore"];
                cevent.color = (string)reader["Persone_Colore"];
                cevent.persona = (int)reader["Persone_Ky"];
                cevent.allDay = true;
                cevent.display = "";
                cevent.url = "";
                //cevent.url = "/admin/app/persone/scheda-personeassenze.aspx?source=calendario&PersoneAssenze_Ky=" +(int)reader["PersoneAssenze_Ky"];
                events.Add(cevent);
            }
        }

        return events;
        //side note: if you want to show events only related to particular users,
        //if user id of that user is stored in session as Session["userid"]
        //the event table also contains an extra field named 'user_id' to mark the event for that particular user
        //then you can modify the SQL as:
        //SELECT event_id, description, title, event_start, event_end FROM event where user_id=@user_id AND event_start>=@start AND event_end<=@end
        //then add paramter as:cmd.Parameters.AddWithValue("@user_id", HttpContext.Current.Session["userid"]);
    }

	//this method updates the event title and description
    public static void updateEvent(int id, String title, String description)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("UPDATE Attivita SET Attivita_Descrizione=@description WHERE Attivita_Ky=@event_id", con);
        cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
        cmd.Parameters.Add("@description", SqlDbType.VarChar).Value= description;
        cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = id;

        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

	//this method updates the event start and end time ... allDay parameter added for FullCalendar 2.x
    public static void updateEventTime(int id, DateTime start, DateTime end, bool allDay)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("UPDATE Attivita SET Attivita_DataInizio=@event_start, Attivita_DataScadenza=@event_end, all_day=@all_day WHERE event_id=@event_id", con);
        cmd.Parameters.Add("@event_start", SqlDbType.DateTime).Value = start;
        cmd.Parameters.Add("@event_end", SqlDbType.DateTime).Value = end;
        cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@all_day", SqlDbType.Bit).Value = allDay;

        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

	//this mehtod deletes event with the id passed in.
    public static void deleteEvent(int id)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("DELETE FROM Event WHERE (event_id = @event_id)", con);
        cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = id;

        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

	//this method adds events to the database
    public static int addEvent(CalendarEvent cevent)
    {
        //add event to the database and return the primary key of the added event row

        //insert
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("INSERT INTO Event(title, description, event_start, event_end, all_day) VALUES(@title, @description, @event_start, @event_end, @all_day)", con);
        cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = cevent.title;
        cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = cevent.description;
        cmd.Parameters.Add("@event_start", SqlDbType.DateTime).Value = cevent.start;
        cmd.Parameters.Add("@event_end", SqlDbType.DateTime).Value = cevent.end;
        cmd.Parameters.Add("@all_day", SqlDbType.Bit).Value = cevent.allDay;

        int key = 0;
        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();

            //get primary key of inserted row
            cmd = new SqlCommand("SELECT max(event_id) FROM Event where title=@title AND description=@description AND event_start=@event_start AND event_end=@event_end AND all_day=@all_day", con);
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = cevent.title;
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = cevent.description;
            cmd.Parameters.Add("@event_start", SqlDbType.DateTime).Value = cevent.start;
            cmd.Parameters.Add("@event_end", SqlDbType.DateTime).Value = cevent.end;
            cmd.Parameters.Add("@all_day", SqlDbType.Bit).Value = cevent.allDay;

            key = (int)cmd.ExecuteScalar();
        }

        return key;
    }
}

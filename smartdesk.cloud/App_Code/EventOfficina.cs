﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// EventiOfficina class is the main class which interacts with the database. SQL Server express edition
/// has been used.
/// the event information is stored in a table named 'event' in the database.
///
/// Here is the table format:
/// event(event_id int, title varchar(100), description varchar(200),event_start datetime, event_end datetime)
/// event_id is the primary key
/// </summary>
public class EventiOfficina
{
	//change the connection string as per your database connection.
    private static string connectionString = ConfigurationManager.AppSettings["DBConnString"];

	//this method retrieves all events within range start-end
    public static List<CalendarEvent> getEvents(DateTime start, DateTime end)
    {   
 		string strSQL = "";
		string strTemp = "";
		String strTime = "";
		DateTime dtTemp;
		TimeSpan tmTemp;
        List<CalendarEvent> events = new List<CalendarEvent>();
        SqlConnection con = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        SqlConnection con2 = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
    		strSQL="SELECT Officina_Ky, Officina_Vettura, Officina_Nominativo, Officina_TargaVettura, Convert(date, Officina_DataConsegna) As Officina_DataConsegna, OfficinaOrari_Orario, Officina_OraConsegna, Officina_Venditore, OfficinaPreparatori_Nominativo, OfficinaStati_Colore, OfficinaTipoauto_Titolo FROM Officina_Vw WHERE (OfficinaStati_Ky Is Null Or OfficinaStati_Ky!=4) And (Officina_DataConsegna Is Not Null) And (Officina_DataConsegna>=@start AND Officina_DataConsegna<=@end)";
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
                cevent.id = (int)reader["Officina_Ky"];
        				dtTemp = (DateTime)reader["Officina_DataConsegna"];
        				strTime = (String)reader["OfficinaOrari_Orario"].ToString();
                if (strTime.Length<1){
                  strTime="09:00:00";
                }
        				tmTemp = TimeSpan.Parse(strTime);
        				dtTemp = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, tmTemp.Hours, tmTemp.Minutes, tmTemp.Seconds);
        				cevent.start = dtTemp;

                strTemp=(string)reader["Officina_Vettura"];
                strTemp=strTemp.Replace("\n",String.Empty);
        				cevent.description = strTemp;
                strTemp= ((string)reader["OfficinaTipoauto_Titolo"]).ToUpper() + "-" + (string)reader["Officina_Nominativo"] + "-" + (string)reader["Officina_Vettura"];
        				cevent.title = strTemp;
        				dtTemp = (DateTime)reader["Officina_DataConsegna"];
        				strTime = (String)reader["OfficinaOrari_Orario"].ToString();
                if (strTime.Length<1){
                  strTime="09:00:00";
                }
        				tmTemp = TimeSpan.Parse(strTime);
        				dtTemp = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, tmTemp.Hours, tmTemp.Minutes, tmTemp.Seconds);
                cevent.end = dtTemp;
                cevent.bgcolor = (string)reader["OfficinaStati_Colore"];
                cevent.color = (string)reader["OfficinaStati_Colore"];
                //cevent.persona = (string)reader["Officina_Nominativo"];
                cevent.allDay = false;
                cevent.display = "";
                cevent.url = "/admin/app/officina/scheda-officina.aspx?Officina_Ky=" +(int)reader["Officina_Ky"];
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
        SqlCommand cmd = new SqlCommand("UPDATE Officina SET Officina_Vettura=@description WHERE Officina_Ky=@event_id", con);
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
        SqlCommand cmd = new SqlCommand("UPDATE Officina SET Officina_DataConsegna=@event_start all_day=@all_day WHERE event_id=@event_id", con);
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
        SqlCommand cmd = new SqlCommand("DELETE FROM Officina WHERE (Officina_Ky = @event_id)", con);
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
        SqlCommand cmd = new SqlCommand("INSERT INTO Officina(title, description, event_start, event_end, all_day) VALUES(@title, @description, @event_start, @event_end, @all_day)", con);
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
            cmd = new SqlCommand("SELECT max(event_id) FROM Officina where title=@title AND description=@description AND event_start=@event_start AND event_end=@event_end AND all_day=@all_day", con);
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

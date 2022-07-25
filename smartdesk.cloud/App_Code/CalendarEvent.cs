using System;

public class CalendarEvent
{
    public int id { get; set; }
    public int persona { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
    public string bgcolor { get; set; }
    public string color { get; set; }
    public bool allDay { get; set; }
    public string display { get; set; }
    public string url { get; set; }
}

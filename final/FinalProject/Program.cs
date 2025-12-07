using System;
using System.Windows.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Calender myCalendar = new Calender();
        myCalendar.load("bigcal.txt");

        CalenderApp.Form1 app = new CalenderApp.Form1(myCalendar);
        Application.Run(app);

        
    }
}
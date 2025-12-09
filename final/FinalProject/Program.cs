using System;
using System.Threading.Tasks;
using System.Windows.Forms;

static class Program
{
    [STAThread]
    async static Task Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Calender myCalendar = new Calender();
        // await myCalendar.SyncExternalCal("https://byui.instructure.com/feeds/calendars/user_MsN9hQyH8YwVHMQaYZlbkVdNPZbBk7aAjhOKLGjy.ics");
        // myCalendar.save("canvasCal.txt");
        // myCalendar.load("canvasCal.txt");

        Form1 app = new Form1(myCalendar);
        Application.Run(app);

        
    }
}
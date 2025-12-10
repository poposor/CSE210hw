// This project is a simple weekly calender
// Features:
// Create new event
// Delete event (Click the delete button and then click the event you wish to delete)
// Load txt into the calender
// Save calender into txt
// Get calender from canvas (On the canvas calender page in the bottom right corner there is a link titiled "Calendar Feed" clicking it will show you a link you can copy into the program)

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
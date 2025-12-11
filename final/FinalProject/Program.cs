// This project is a simple weekly calender
// Features:
// Create new event
// Delete event (Click the delete button and then click the event you wish to delete)
// Load txt into the calender
// Save calender into txt
// Get calender from canvas (On the canvas calender page in the bottom right corner there is a link titiled "Calendar Feed" clicking it will show you a link you can copy into the program)
// Origianly I was planning on adding Goals to this project and I did implement the Goal class but decided against adding them to the final interface

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

static class Program
{
    [STAThread]
    async static Task Main()
    {
        Calender myCalendar = new Calender();

        // Uncomment the line bellow if you don't feel like getting your own calender
        // myCalendar.Load("canvas.txt");

        Window app = new Window(myCalendar);
        Application.Run(app);


    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        // string fileUrl = "https://byui.instructure.com/feeds/calendars/user_MsN9hQyH8YwVHMQaYZlbkVdNPZbBk7aAjhOKLGjy.ics"; // Replace with your URL

        // using (HttpClient client = new HttpClient())
        // {
        //     try
        //     {
        //         // Download the file content as a string
        //         string fileContents = await client.GetStringAsync(fileUrl);
                
        //         Console.WriteLine("File contents:");
        //         Console.WriteLine(fileContents);
        //     }
        //     catch (HttpRequestException e)
        //     {
        //         Console.WriteLine($"Error downloading file: {e.Message}");
        //     }
        // }
        string dateString = "12/15/2023 10:30:00 AM";
        DateTime resultDate = DateTime.Parse(dateString);
        Console.WriteLine(resultDate); 
    }
}
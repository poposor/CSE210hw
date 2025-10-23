using System;

class Program
{
    static void Main(string[] args)
    {

        ParseTxt test = new ParseTxt();
        Scripture myScripture = test.Parse("mastery.txt");

        Reference script = new Reference("1 Nephi", 1, 1, 3);
        Verse myVerse = new Verse(1, "I, Nephi, having been born of goodly parents, therefore I was taught somewhat in all the learning of my father; and having seen many afflictions in the course of my days, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a record of my proceedings in my days.");
        Verse myVerse2 = new Verse(2, "Yea, I make a record in the language of my father, which consists of the learning of the Jews and the language of the Egyptians.");
        Verse myVerse3 = new Verse(3, "And I know that the record which I make is true; and I make it with mine own hand; and I make it according to my knowledge.");

        List<Verse> myVerses = new List<Verse>();
        myVerses.Add(myVerse);
        myVerses.Add(myVerse2);
        myVerses.Add(myVerse3);

        // Scripture myScripture = new Scripture(script, myVerses);

        string user = "";
        while (user != "quit")
        {
            Console.Clear();

            if(myScripture.Display() == "fullyHidden")
            {
                return;
            }

            Console.WriteLine("");
            Console.Write("Type 'quit' to quit or press enter to hide more words: ");
            user = Console.ReadLine();

            myScripture.HideWords(4);
        }

    }
}
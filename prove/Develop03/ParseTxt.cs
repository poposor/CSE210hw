class ParseTxt
{
    private List<string> books = new List<string>();
    private List<int> chapters = new List<int>();
    private List<int> verseStarts = new List<int>();
    private List<int> verseEnds = new List<int>();
    private List<string> verseText = new List<string>();

    private List<List<Verse>> verses = new List<List<Verse>>();
    private List<Reference> references = new List<Reference>();

    private string _fileLocation;
    public Scripture Parse(string fileLoc)
    {
        _fileLocation = fileLoc;

    string fileContents = File.ReadAllText(_fileLocation);
        string[] split = fileContents.Split('/', StringSplitOptions.RemoveEmptyEntries);


        for (int i = 0; i < split.Length; i++)
        {
            string[] line = split[i].Split('|');
            books.Add(line[0]);
            string[] refer = line[1].Split(':');
            chapters.Add(int.Parse(refer[0]));
            if (refer[1].Contains('–'))
            {
                // Console.WriteLine("big" + refer[1]);
                string[] vs = refer[1].Split('–');
                int[] v = [int.Parse(vs[0]), int.Parse(vs[1])];
                verseStarts.Add(v[0]);
                verseEnds.Add(v[1]);
                references.Add(new Reference(books[i], chapters[i], verseStarts[i], verseEnds[i]));
            }
            else
            {
                int v = int.Parse(refer[1]);
                verseStarts.Add(v);
                verseEnds.Add(-1);
                references.Add(new Reference(books[i], chapters[i], verseStarts[i]));
            }
            verseText.Add(refer[2]);

            
            verses.Add(new List<Verse>());
            verses[i].Add(new Verse(verseStarts[i], verseText[i]));
            // Console.WriteLine(i+"ref:"+references[i].GetReferenece());
        }
        Random random = new Random();
        int picked = random.Next(0, references.Count);
        // Console.WriteLine(picked + "/" + references.Count);
        return new Scripture(references[picked],verses[picked]);
    }

}
class Scripture
{
    private Reference _reference;
    private List<Verse> _verses = new List<Verse>();
    public Scripture(Reference reference, Verse verse)
    {
        _reference = reference;
        _verses.Add(verse);
    }
    public Scripture(Reference reference, List<Verse> verses)
    {
        _reference = reference;
        _verses = verses;
    }

    public string Display()
    {
        Console.WriteLine(_reference.GetReferenece());
        int versesLeft = _verses.Count;
        foreach (Verse v in _verses)
        {
            Console.WriteLine(v.GetVerse());
            if (v._allWordsHidden)
            {
                versesLeft--;
            }
        }
        if (versesLeft == 0)
        {
            return "fullyHidden";
        }
        return "keepGoing";
    }
    public void HideWords(int count)
    {
        Random random = new Random();
        for (int i = 0;i<count;i++)
        {
            _verses[random.Next(0, _verses.Count)].HideWords(1);
        }
    }
}
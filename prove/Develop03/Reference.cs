class Reference
{
    private string _book;
    private int _chapter;
    private string _verses;
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verses = verse.ToString();
    }
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verses = verseStart + "-" + verseEnd;
    }
    public string GetReferenece()
    {
        return _book + " " + _chapter + ":" + _verses;
    }
}
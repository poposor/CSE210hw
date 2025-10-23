class Verse
{
    private List<Word> _words;
    private int _number;
    public bool _allWordsHidden = false;
    public Verse(int number, List<Word> words)
    {
        _number = number;
        _words = words;
    }
    public Verse(int number, string words)
    {
        _number = number;
        _words = new List<Word>();
        string[] splitWords = words.Split(' ');
        foreach (string w in splitWords)
        {
            _words.Add(new Word(w));
        }
    }
    public string GetVerse()
    {
        // string verseReturn = _number + " ";
        string verseReturn = "";
        foreach (Word word in _words)
        {
            verseReturn += word.GetWord() + " ";
        }
        return verseReturn;
    }
    private int CountWordsLeft()
    {
        int cnt = 0;
        foreach (Word w in _words)
        {
            if (!w.isHidden())
            {
                cnt++;
            }
        }
        return cnt;
    }
    public bool HideWords(int count)
    {
        Random random = new Random();
        int left = CountWordsLeft();
        if (left == 0)
        {
            _allWordsHidden = true;
            return false;
        }
        else
        {
            for (int i = 0; i < Math.Min(count, left); i++)
            {
                while (_words[random.Next(0, _words.Count)].Hide() == false)
                {

                }
            }
            return true;
        }
    }
}
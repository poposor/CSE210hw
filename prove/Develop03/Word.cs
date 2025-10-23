class Word
{
    private bool _hidden = false;
    private string _word;

    public Word(string word)
    {
        _word = word;
    }
    public string GetWord()
    {
        if (_hidden)
        {
            return "___";
        }
        return _word;
    }
    public bool isHidden()
    {
        return _hidden;
    }
    public bool Hide()
    {
        if (_hidden)
        {
            return false;
        }
        _hidden = true;
        return true;
    }
}
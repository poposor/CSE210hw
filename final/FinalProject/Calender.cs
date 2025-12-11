using System.Collections.Generic;
using System.Threading.Tasks;

public class Calender
{
    private List<CalendarItem> _items;
    private Sync _sync;
    private Loader _loader;

    public Calender()
    {
        _items = new List<CalendarItem>();
        _sync = new Sync();
        _loader = new Loader();
    }
    public void Load(string url)
    {
        _items = _loader.Load(url);
    }
    public void Save(string url)
    {
        _loader.Save(url, _items);
    }
    public List<CalendarItem> GetItems()
    {
        return _items;
    }
    public void AddItem(CalendarItem item)
    {
        _items.Add(item);
    }
    public void DeleteItem(CalendarItem item)
    {
        _items.Remove(item);
    }
    public async Task SyncExternalCal(string url)
    {
        await _sync.GetExternalCal(url);
        _items = _sync.AddExternalCal(_items);
    }
}
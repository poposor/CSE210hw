using System;
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
    public void load(string url)
    {
        _items = _loader.load(url);
    }
    public void save(string url)
    {
        _loader.save(url, _items);
    }
    public List<CalendarItem> getItems()
    {
        return _items;
    }
    public async Task SyncExternalCal(string url){
        await _sync.GetExternalCal(url);
        _items =_sync.AddExternalCal(_items);
        // foreach (CalendarItem item in getItems())
        // {
        //     Console.WriteLine(item.getSaveable());
        // }
    }
}
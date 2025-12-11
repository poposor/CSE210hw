using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class Window : Form
{
    private Calender _cal;
    private Image _saveImg;
    private Image _folderImg;
    private Image _webImg;
    private Image _newImg;
    private Image _deleteImg;
    public Window(Calender cal)
    {
        _cal = cal;
        InitializeComponent();
        this.MouseClick += new MouseEventHandler(Form1_MouseClick);
        this.Text = "Calender App";
        _saveImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "save-2.png"));
        _folderImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "folder-2.png"));
        _webImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "web-2.png"));
        _newImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "new-2.png"));
        _deleteImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "delete-2.png"));
        buttonsX = width - width / 20 + width / 40 - 25;
        _saveButtonRect = new Rectangle(buttonsX, height - 70 - 60 - 60, 50, 50);
        _loadButtonRect = new Rectangle(buttonsX, height - 70 - 60, 50, 50);
        _webButtonRect = new Rectangle(buttonsX, height - 70, 50, 50);
        _newButtonRect = new Rectangle(buttonsX, 60, 50, 50);
        _deleteButtonRect = new Rectangle(buttonsX, 120, 50, 50);

        _monday = DateOnly.FromDateTime(DateTime.Now).AddDays(-(int)DateOnly.FromDateTime(DateTime.Now).DayOfWeek + 1);
        _sunday = _monday.AddDays(6);
    }
    Graphics g;
    int width = 1280;
    int height = 720;
    int buttonsX;
    Rectangle _saveButtonRect;
    Rectangle _loadButtonRect;
    Rectangle _webButtonRect;
    Rectangle _newButtonRect;
    Rectangle _deleteButtonRect;
    DateOnly _monday;
    DateOnly _sunday;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        g = e.Graphics;
        DrawBackground(g);
        foreach (CalendarItem item in _cal.GetItems())
        {
            if (item.GetDate() >= _monday && item.GetDate() <= _sunday)
            {
                DrawCalendarItem(item);
            }
        }

        Rectangle(g, _newButtonRect, Color.LightGray);
        g.DrawImage(_newImg, _newButtonRect.X + 9, _newButtonRect.Y + 9, 32, 32);

        Color deleteColor;
        if (delete)
        {
            deleteColor = Color.DarkGray;
        }
        else
        {
            deleteColor = Color.LightGray;
        }
        Rectangle(g, _deleteButtonRect, deleteColor);
        g.DrawImage(_deleteImg, _deleteButtonRect.X + 9, _deleteButtonRect.Y + 9, 32, 32);

        Rectangle(g, _saveButtonRect, Color.LightGray);
        g.DrawImage(_saveImg, _saveButtonRect.X + 9, _saveButtonRect.Y + 9, 32, 32);
        Rectangle(g, _loadButtonRect, Color.LightGray);
        g.DrawImage(_folderImg, _loadButtonRect.X + 9, _loadButtonRect.Y + 9, 32, 32);
        Rectangle(g, _webButtonRect, Color.LightGray);
        g.DrawImage(_webImg, _webButtonRect.X + 9, _webButtonRect.Y + 9, 32, 32);
    }

    private void Rectangle(Graphics g, Rectangle rect, Color color)
    {
        using (SolidBrush brush = new SolidBrush(color))
        {
            g.FillRectangle(brush, rect);
        }
    }
    private void DrawBackground(Graphics g)
    {
        Rectangle rect = new Rectangle(0, 0, width, height);
        Rectangle(g, rect, Color.LightGray);

        Rectangle(g, new Rectangle(0, 0, width / 20, height), Color.DimGray);
        Rectangle(g, new Rectangle(width - width / 20, 0, width / 20, height), Color.DimGray);

        // Times
        g.DrawLine(Pens.Black, 0, height / 15, width, height / 15);
        g.DrawLine(Pens.Black, width / 20, 0, width / 20, height);
        string[] timeSuffixes = { "am", "pm" };
        for (int i = 7; i <= 23; i++)
        {
            int y = (height - height / 15) / (24 - 7) * (i - 7) + height / 15;
            g.DrawLine(Pens.Black, 0, y, width / 20, y);
            g.DrawString((i % 12) + timeSuffixes[i / 12], new Font("Arial", 12), Brushes.Black, 5, y);
        }

        // Day Boxes
        string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
        for (int i = 1; i <= 7; i++)
        {
            int x = (int)((width - width / 10) / 7.0 * i + width / 20);
            g.DrawLine(Pens.Black, x, 0, x, height);
            g.DrawString(days[i - 1], new Font("Arial", 12), Brushes.Black, x - (width - width / 20) / 14 - 18, 5);
        }

    }

    private Rectangle GetCalendarItemRect(CalendarItem item, string type)
    {
        int x = 0;
        int y = 0;
        int h = 50;
        if (type == "E")
        {
            DateTime start = ((Event)item).getStartTime();
            DateTime end = ((Event)item).getEndTime();
            int dayOfWeek = ((int)start.DayOfWeek + 6) % 7;
            x = (int)((width - width / 10) / 7.0 * dayOfWeek + width / 20);
            y = (int)((height - height / 15) / (24 - 7) * (start.Hour - 7 + start.Minute / 60.0) + height / 15);
            h = (int)((height - height / 15) / (24 - 7) * ((end - start).TotalMinutes / 60.0));
            if (h < 20) h = 20;
        }
        else if (type == "R")
        {
            DateTime time = ((Reminder)item).getTime();
            int dayOfWeek = ((int)time.DayOfWeek + 6) % 7;
            x = (int)((width - width / 10) / 7.0 * dayOfWeek + width / 20);
            y = (int)((height - height / 15) / (24 - 7) * (time.Hour - 7 + time.Minute / 60.0) + height / 15);
            h = 20;
        }
        else if (type == "A")
        {
            DateOnly date = ((AllDay)item).GetDate();
            int dayOfWeek = ((int)date.DayOfWeek + 6) % 7;
            x = (int)((width - width / 10) / 7.0 * dayOfWeek + width / 20);
            y = height - height / 30;
            h = height / 30;
        }
        return new Rectangle(x + 1, y, (width - width / 10) / 7 - 1, h);
    }
    public void DrawCalendarItem(CalendarItem item)
    {
        string type = item.GetSaveable()[0].ToString();
        Rectangle pos = GetCalendarItemRect(item, type);
        Color color = Color.LightBlue;
        if (type == "E")
        {
            color = Color.LightGreen;
        }
        else if (type == "R")
        {
            color = Color.LightCoral;
        }
        else if (type == "A")
        {
            color = Color.LightGoldenrodYellow;
        }

        Rectangle(g, pos, color);
        g.DrawRectangle(new Pen(Color.Black, 1), pos);
        int nameSize = item.GetName().Length;
        if (nameSize < 23)
        {
            g.DrawString(item.GetName(), new Font("Arial", 12), Brushes.Black, pos.X, pos.Y);
        }
        else
        {
            g.DrawString(item.GetName().Substring(0, 20) + "...", new Font("Arial", 10), Brushes.Black, pos.X, pos.Y);
        }

    }
    bool delete = false;
    private async void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (delete)
            {
                foreach (CalendarItem item in _cal.GetItems())
                {
                    if (item.GetDate() >= _monday && item.GetDate() <= _sunday)
                    {
                        string type = item.GetSaveable()[0].ToString();
                        Rectangle pos = GetCalendarItemRect(item, type);
                        if (e.X >= pos.X && e.X <= pos.X + pos.Width &&
                            e.Y >= pos.Y && e.Y <= pos.Y + pos.Height)
                        {
                            Console.WriteLine(item.GetName() + " deleted");
                            _cal.DeleteItem(item);
                            Invalidate();
                            break;
                        }
                    }
                }
                delete = false;
                Invalidate();
                return;
            }
            else if (e.X >= buttonsX && e.X <= buttonsX + 50)
            {
                if (e.Y >= _saveButtonRect.Y && e.Y <= _saveButtonRect.Y + 50)
                {
                    InputForm saveForm = new InputForm("Save Calendar", "Filename:");
                    if (saveForm.ShowDialog() == DialogResult.OK)
                    {
                        string filename = saveForm.GetInput();
                        _cal.Save(filename);
                    }
                }
                else if (e.Y >= _loadButtonRect.Y && e.Y <= _loadButtonRect.Y + 50)
                {
                    InputForm loadForm = new InputForm("Load Calendar", "Filename:");
                    if (loadForm.ShowDialog() == DialogResult.OK)
                    {
                        string filename = loadForm.GetInput();
                        _cal.Load(filename);
                    }
                    Invalidate();
                }
                else if (e.Y >= _webButtonRect.Y && e.Y <= _webButtonRect.Y + 50)
                {
                    InputForm webForm = new InputForm("Get Web Calendar", "URL:");
                    if (webForm.ShowDialog() == DialogResult.OK)
                    {
                        string filename = webForm.GetInput();
                        Console.WriteLine(filename);
                        await _cal.SyncExternalCal(filename);
                        Console.WriteLine("Done");
                        Invalidate();
                    }
                }
                else if (e.Y >= _newButtonRect.Y && e.Y <= _newButtonRect.Y + 50)
                {
                    NewForm i = new NewForm();
                    if (i.ShowDialog() == DialogResult.OK)
                    {
                        CalendarItem newItem;
                        string[] types = { "E", "R", "A" };
                        if (i.GetSelectedType() == 0)
                        {
                            Console.WriteLine($"{types[i.GetSelectedType()]}|{i.GetName()}|{i.GetDesc()}|{i.GetDate()}|{i.GetEndDate()}");
                            newItem = new Event(i.GetName(), i.GetDesc(), i.GetDate(), i.GetEndDate());

                        }
                        else if (i.GetSelectedType() == 1)
                        {
                            Console.WriteLine($"{types[i.GetSelectedType()]}|{i.GetName()}|{i.GetDesc()}|{i.GetDate()}");
                            newItem = new Reminder(i.GetName(), i.GetDesc(), i.GetDate());
                        }
                        else
                        {
                            Console.WriteLine($"{types[i.GetSelectedType()]}|{i.GetName()}|{i.GetDesc()}|{i.GetDate()}");
                            newItem = new AllDay(i.GetName(), i.GetDesc(), DateOnly.FromDateTime(i.GetDate()));
                        }
                        _cal.AddItem(newItem);
                    }
                    Invalidate();
                }
                else if (e.Y >= _deleteButtonRect.Y && e.Y <= _deleteButtonRect.Y + 50)
                {
                    delete = true;
                    Invalidate();
                }
            }
        }
    }
    private void InitializeComponent()
    {
        this.ClientSize = new System.Drawing.Size(width, height);
        this.Name = "Form1";
    }
}
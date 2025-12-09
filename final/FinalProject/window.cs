using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalenderApp
{
    public partial class Form1 : Form
    {
        private Calender _cal;
        private Image saveImg;
        private Image folderImg;
        private Image webImg;
        private Image newImg;
        private Image deleteImg;
        public Form1(Calender cal)
        {
            _cal = cal;
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
            this.Text = "Calender App"; 
            saveImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "save-2.png"));
            folderImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "folder-2.png"));
            webImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "web-2.png"));
            newImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "new-2.png"));
            deleteImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "delete-2.png"));
            buttonsX = width - width / 20 + width / 40 - 25;
            saveButtonRect = new Rectangle(buttonsX, height - 70-60-60, 50, 50);
            loadButtonRect = new Rectangle(buttonsX, height - 70-60, 50, 50);
            webButtonRect = new Rectangle(buttonsX, height - 70, 50, 50);
            newButtonRect = new Rectangle(buttonsX, 60, 50, 50);
            deleteButtonRect = new Rectangle(buttonsX, 120, 50, 50);

            monday = DateOnly.FromDateTime(DateTime.Now).AddDays(-(int)DateOnly.FromDateTime(DateTime.Now).DayOfWeek + 1);
            sunday = monday.AddDays(6);
        }
        Graphics g;
        int width = 1280;
        int height = 720;
        int buttonsX;
        Rectangle saveButtonRect;
        Rectangle loadButtonRect;
        Rectangle webButtonRect;
        Rectangle newButtonRect;
        Rectangle deleteButtonRect;

        DateOnly monday;
        DateOnly sunday;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            g = e.Graphics;
            drawBackground(g);
            foreach (CalendarItem item in _cal.getItems())
            {
                if (item.getDate() >= monday && item.getDate() <= sunday)
                {
                    drawCalendarItem(item);
                }
            }

            rectangle(g, newButtonRect, Color.LightGray);
            g.DrawImage(newImg, newButtonRect.X+9, newButtonRect.Y+9, 32, 32);
            
            Color deleteColor = delete ? Color.DarkGray : Color.LightGray;
            rectangle(g, deleteButtonRect, deleteColor);
            g.DrawImage(deleteImg, deleteButtonRect.X+9, deleteButtonRect.Y+9, 32, 32);

            rectangle(g, saveButtonRect, Color.LightGray);
            g.DrawImage(saveImg, saveButtonRect.X+9, saveButtonRect.Y+9, 32, 32);
            rectangle(g, loadButtonRect, Color.LightGray);
            g.DrawImage(folderImg, loadButtonRect.X+9, loadButtonRect.Y+9, 32, 32);
            rectangle(g, webButtonRect, Color.LightGray);
            g.DrawImage(webImg, webButtonRect.X+9, webButtonRect.Y+9, 32, 32);
        }
        
        private void rectangle(Graphics g, Rectangle rect, Color color)
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, rect);
            }
        }
        private void drawBackground(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, width, height);
            rectangle(g, rect, Color.LightGray);

            rectangle(g, new Rectangle(0, 0, width/20, height), Color.DimGray);
            rectangle(g, new Rectangle(width-width/20, 0, width/20, height), Color.DimGray);

            // Times
            g.DrawLine(Pens.Black, 0, height/15, width, height/15);
            g.DrawLine(Pens.Black, width/20, 0, width/20, height);
            string[] timeSuffixes = { "am", "pm" };
            for (int i = 7; i <= 23; i++)
            {
                int y = (height - height / 15) / (24-7) * (i - 7) + height / 15;
                g.DrawLine(Pens.Black, 0, y, width/20, y);
                g.DrawString((i%12) + timeSuffixes[i / 12], new Font("Arial", 12), Brushes.Black, 5, y);
            }

            // Day Boxes
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            for (int i = 1; i <= 7; i++)
            {
                int x = (int)((width - width/10) / 7.0 * i + width/20);
                g.DrawLine(Pens.Black, x, 0, x, height);
                g.DrawString(days[i-1], new Font("Arial", 12), Brushes.Black, x - (width - width/20) / 14 - 18, 5);
            }
            
        }
        
        private Rectangle getCalendarItemRect(CalendarItem item, string type)
        {
            int x = 0;
            int y = 0;
            int h = 50;
            if (type == "E")
            {
                DateTime start = ((Event)item).getStartTime();
                DateTime end = ((Event)item).getEndTime();
                int dayOfWeek = ((int)start.DayOfWeek + 6) % 7;
                x = (int)((width - width/10) / 7.0 * dayOfWeek + width/20);
                y = (int)((height - height / 15) / (24-7) * (start.Hour - 7 + start.Minute / 60.0) + height / 15);
                h = (int)((height - height / 15) / (24-7) * ((end - start).TotalMinutes / 60.0));
                if (h < 20) h = 20;
            } else if (type == "R")
            {
                DateTime time = ((Reminder)item).getTime();
                int dayOfWeek = ((int)time.DayOfWeek + 6) % 7;
                x = (int)((width - width/10) / 7.0 * dayOfWeek + width/20);
                y = (int)((height - height / 15) / (24-7) * (time.Hour - 7 + time.Minute / 60.0) + height / 15);
                h = 20;
            } else if (type == "A")
            {
                DateOnly date = ((AllDay)item).getDate();
                int dayOfWeek = ((int)date.DayOfWeek + 6) % 7;
                x = (int)((width - width/10) / 7.0 * dayOfWeek + width/20);
                y = height - height / 30;
                h = height / 30;
            }
            return new Rectangle(x+1, y, (width - width/10) / 7-1, h);
        }
        public void drawCalendarItem(CalendarItem item)
        {
            string type = item.getSaveable()[0].ToString();
            Rectangle pos = getCalendarItemRect(item, type);
            System.Drawing.Color color = Color.LightBlue;
            if (type == "E")
            {
                color = Color.LightGreen;
            } else if (type == "R")
            {
                color = Color.LightCoral;
            } else if (type == "A")
            {
                color = Color.LightGoldenrodYellow;
            }

            rectangle(g, pos, color);
            g.DrawRectangle(new Pen(Color.Black, 1), pos);
            int nameSize = item.getName().Length;
            if (nameSize < 23)
            {
                g.DrawString(item.getName(), new Font("Arial", 12), Brushes.Black, pos.X, pos.Y);
            } else
            {
                g.DrawString(item.getName().Substring(0, 20) + "...", new Font("Arial", 10), Brushes.Black, pos.X, pos.Y);
            }
            
        }
        bool delete = false;
        private async void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (delete)
                {
                    foreach (CalendarItem item in _cal.getItems())
                    {
                        if (item.getDate() >= monday && item.getDate() <= sunday)
                        {
                            string type = item.getSaveable()[0].ToString();
                            Rectangle pos = getCalendarItemRect(item, type);
                            if (e.X >= pos.X && e.X <= pos.X + pos.Width &&
                                e.Y >= pos.Y && e.Y <= pos.Y + pos.Height)
                            {
                                Console.WriteLine(item.getName()+" deleted");
                                _cal.deleteItem(item);
                                Invalidate();
                                break;
                            }
                        }
                    }
                    delete = false;
                    return;
                }
                else if (e.X >= buttonsX && e.X <= buttonsX + 50)
                {
                    if (e.Y >= saveButtonRect.Y && e.Y <= saveButtonRect.Y + 50)
                    {
                        InputForm saveForm = new InputForm("Save Calendar", "Filename:");
                        if (saveForm.ShowDialog() == DialogResult.OK)
                        {
                            string filename = saveForm.InputValue;
                            _cal.save(filename);
                        }
                    }
                    else if (e.Y >= loadButtonRect.Y && e.Y <= loadButtonRect.Y + 50)
                    {
                        InputForm loadForm = new InputForm("Load Calendar", "Filename:");
                        if (loadForm.ShowDialog() == DialogResult.OK)
                        {
                            string filename = loadForm.InputValue;
                            _cal.load(filename);
                        }
                        Invalidate();
                    }
                    else if (e.Y >= webButtonRect.Y && e.Y <= webButtonRect.Y + 50)
                    {
                        InputForm webForm = new InputForm("Get Web Calendar", "URL:");
                        if (webForm.ShowDialog() == DialogResult.OK)
                        {
                            string filename = webForm.InputValue;
                            Console.WriteLine(filename);
                            await _cal.SyncExternalCal(filename);
                            Console.WriteLine("Done");
                            Invalidate();
                        }
                    }
                    else if (e.Y >= newButtonRect.Y && e.Y <= newButtonRect.Y + 50)
                    {
                        newForm i = new newForm();
                        if (i.ShowDialog() == DialogResult.OK)
                        {
                            // CalendarItem newItem = newItemForm.GetCalendarItem();
                            // _cal.addItem(newItem);
                            // Invalidate();
                            CalendarItem newItem;
                            string[] types = {"E", "R", "A"};
                            if (i.TypeIndex == 0){
                                Console.WriteLine($"{types[i.TypeIndex]}|{i.InputValue}|{i.Description}|{i.InputDate}|{i.EndDate}");
                                newItem = new Event(i.InputValue, i.Description, i.InputDate, i.EndDate);

                            } else if (i.TypeIndex == 1){
                                Console.WriteLine($"{types[i.TypeIndex]}|{i.InputValue}|{i.Description}|{i.InputDate}");
                                newItem = new Reminder(i.InputValue, i.Description, i.InputDate);
                            } else {
                                Console.WriteLine($"{types[i.TypeIndex]}|{i.InputValue}|{i.Description}|{i.InputDate}");
                                newItem = new AllDay(i.InputValue, i.Description, DateOnly.FromDateTime(i.InputDate));
                            }
                            _cal.addItem(newItem);
                        }
                        Invalidate();
                    }
                    else if (e.Y >= deleteButtonRect.Y && e.Y <= deleteButtonRect.Y + 50)
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
}
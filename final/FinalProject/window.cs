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
        public Form1(Calender cal)
        {
            _cal = cal;
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
            this.Text = "Calender App"; 
            saveImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "save-2.png"));
            folderImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "folder-2.png"));
            webImg = Image.FromFile(Path.Combine(Application.StartupPath, "images", "web-2.png"));
        }
        Graphics g;
        int x = 0;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            g = e.Graphics;
            drawBackground(g);
            DateOnly monday = DateOnly.FromDateTime(DateTime.Now).AddDays(-(int)DateOnly.FromDateTime(DateTime.Now).DayOfWeek + 1);
            DateOnly sunday = monday.AddDays(6);
            foreach (CalendarItem item in _cal.getItems())
            {
                if (item.getDate() >= monday && item.getDate() <= sunday)
                {
                    drawCalendarItem(item);
                }
            }

            int buttonsX = width - width / 20 + width / 40 - 25;
            rectangle(g, new Rectangle(buttonsX, 60, 50, 50), Color.LightGray);
            g.DrawImage(saveImg, buttonsX+9, 69, 32, 32);
            rectangle(g, new Rectangle(buttonsX, 120, 50, 50), Color.LightGray);
            g.DrawImage(folderImg, buttonsX+9, 129, 32, 32);
            rectangle(g, new Rectangle(buttonsX, 180, 50, 50), Color.LightGray);
            g.DrawImage(webImg, buttonsX+9, 189, 32, 32);
        }
        int width = 1280;
        int height = 720;
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
            //  Console.WriteLine($"Name: {item.getName()}, x: {x}, y: {y}, h: {h}, Type: {type}");
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
        private async void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int buttonsX = width - width / 20 + width / 40 - 25;
                if (e.X >= buttonsX && e.X <= buttonsX + 50)
                {
                    if (e.Y >= 60 && e.Y <= 110)
                    {
                        InputForm saveForm = new InputForm("Save Calendar");
                        if (saveForm.ShowDialog() == DialogResult.OK)
                        {
                            string filename = saveForm.InputValue;
                            _cal.save(filename);
                        }
                    }
                    else if (e.Y >= 120 && e.Y <= 170)
                    {
                        InputForm saveForm = new InputForm("Save Calendar");
                        if (saveForm.ShowDialog() == DialogResult.OK)
                        {
                            string filename = saveForm.InputValue;
                            _cal.load(filename);
                        }
                        Invalidate();
                    }
                    else if (e.Y >= 180 && e.Y <= 230)
                    {
                        InputForm saveForm = new InputForm("Save Calendar");
                        if (saveForm.ShowDialog() == DialogResult.OK)
                        {
                            string filename = saveForm.InputValue;
                            await _cal.SyncExternalCal(filename);
                        }
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
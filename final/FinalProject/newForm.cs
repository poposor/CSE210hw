using System;
using System.Windows.Forms;

public class newForm : Form
{
    private TextBox _nameBox;
    public string getName()
    {
        return _nameBox.Text;
    }
    private ComboBox _typeDropdown;
    public int getType()
    {
        return _typeDropdown.SelectedIndex;
    }
    private DateTimePicker _datePicker;
    public DateTime getDate()
    {
        return _datePicker.Value;
    }
    private DateTimePicker _endDatePicker;
    public DateTime getEndDate()
    {
        return _endDatePicker.Value;
    }
    private TextBox _descriptionBox;
    public string getDesc()
    {
        return _descriptionBox.Text;
    }
    private Button _ok;
    

    public newForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "New Calender Item";
        this.Width = 600;
        this.Height = 400;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;

        //Name label
        this.Controls.Add(new Label
        {
            Text = "Name:",
            Left = 20,
            Top = 20,
            Width = 400,
            Height = 25
        });
        _nameBox = new TextBox
        {
            Left = 20,
            Top = 50,
            Width = 350,
            Height = 30
        };
        this.Controls.Add(_nameBox);

        //Type label
        this.Controls.Add(new Label
        {
            Text = "Item Type:",
            Left = 20,
            Top = 85,
            Width = 400,
            Height = 25
        });
        _typeDropdown = new ComboBox
        {
            Items = {"Event", "Reminder", "AllDay"},
            Top = 115,
            Left = 20,
            SelectedIndex = 0,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        this.Controls.Add(_typeDropdown);

        _typeDropdown.SelectedIndexChanged += (s, e) =>
        {
            if (_datePicker != null)
            {
                this.Controls.Remove(_datePicker);
            }
            if (_endDatePicker != null)
            {
                this.Controls.Remove(_endDatePicker);
            }
            if (_typeDropdown.SelectedIndex == 0) // Event
            {
                _datePicker = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "MM/dd/yyyy hh:mm tt",
                    Left = 20,
                    Top = 160,
                    Width = 200,
                    Height = 30
                };
                this.Controls.Add(_datePicker);
                _endDatePicker = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "MM/dd/yyyy hh:mm tt",
                    Left = 250,
                    Top = 160,
                    Width = 200,
                    Height = 30
                };
                this.Controls.Add(_endDatePicker);
            }
            else if (_typeDropdown.SelectedIndex == 1) // Reminder
            {
                _datePicker = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "MM/dd/yyyy hh:mm tt",
                    Left = 20,
                    Top = 160,
                    Width = 200,
                    Height = 30
                };
                this.Controls.Add(_datePicker);
            }
            else // AllDay
            {
                _datePicker = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Short,
                    Left = 20,
                    Top = 160,
                    Width = 200,
                    Height = 30
                };
                this.Controls.Add(_datePicker);
            }
        };
        
        this.Controls.Add(new Label
        {
            Text = "Date/Time:",
            Left = 20,
            Top = 135,
            Width = 400,
            Height = 25
        });

        this.Controls.Add(new Label
        {
            Text = "Description:",
            Left = 20,
            Top = 195,
            Width = 200,
            Height = 25
        });

        _descriptionBox = new TextBox
        {
            Left = 20,
            Top = 220,
            Width = 300,
            Height = 25,
        };
        this.Controls.Add(_descriptionBox);

        _ok = new Button
        {
            Text = "Done",
            Left = 150,
            Top = 265,
            Width = 100,
            Height = 30,
            DialogResult = DialogResult.OK
        };
        _ok.Click += (s, e) => this.DialogResult = DialogResult.OK;
        this.Controls.Add(_ok);

        this.AcceptButton = _ok;
    }
}
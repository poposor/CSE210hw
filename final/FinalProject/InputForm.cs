using System;
using System.Drawing;
using System.Windows.Forms;

public class InputForm : Form
{
    private TextBox _textBox;
    private Button _ok;
    public string InputValue => _textBox.Text;

    public InputForm(string title, string prompt)
    {
        InitializeComponent(title, prompt);
    }

    private void InitializeComponent(string title, string prompt)
    {
        this.Text = title;
        this.Width = 400;
        this.Height = 180;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;

        Label label = new Label
        {
            Text = prompt,
            Left = 20,
            Top = 20,
            Width = 400,
            Height = 25
        };
        this.Controls.Add(label);

        _textBox = new TextBox
        {
            Left = 20,
            Top = 50,
            Width = 350,
            Height = 30
        };
        this.Controls.Add(_textBox);

        _ok = new Button
        {
            Text = "OK",
            Left = 150,
            Top = 90,
            Width = 100,
            Height = 30,
            DialogResult = DialogResult.OK
        };
        _ok.Click += (s, e) => this.DialogResult = DialogResult.OK;
        this.Controls.Add(_ok);

        this.AcceptButton = _ok;
    }
}
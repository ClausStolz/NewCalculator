using System;
using System.Diagnostics;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        BuildUI();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void DigitButtonClick(object sender, EventArgs args)
    {
        this.calcLabel.Text += (sender as global::Gtk.Button).Label;
    }
}

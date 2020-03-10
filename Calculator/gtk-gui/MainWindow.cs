using System.Collections.Generic;

public partial class MainWindow
{
	private global::Gtk.Label calcLabel;

	private global::Gtk.Fixed fixedCont;

	private List<global::Gtk.Button> digitButtons;


	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name  = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");

		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth    = ((uint)(6));

		this.digitButtons = new List<global::Gtk.Button>();

		this.fixedCont = new global::Gtk.Fixed()
		{
			Name      = "FixedCont",
			HasWindow = false
		};

		BuildDigitButtons();

		this.Add(fixedCont);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}

		this.WidthRequest  = 240;
		this.HeightRequest = 320;
		this.DefaultWidth  = this.WidthRequest;
		this.DefaultHeight = this.HeightRequest;
		this.Resizable     = false;

		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
	}

    protected virtual void BuildDigitButtons()
    {
        for (int i = 1; i < 10; i++)
        {
			var button = new global::Gtk.Button()
			{
				WidthRequest  = 50,
                HeightRequest = 50,
                CanFocus      = true,
                Name          = "button" + i,
                UseUnderline  = true,
                Label         = global::Mono.Unix.Catalog.GetString(i.ToString())
			};

			this.fixedCont.Add(button);
			this.digitButtons.Add(button);
			global::Gtk.Fixed.FixedChild w = (global::Gtk.Fixed.FixedChild)this.fixedCont[button];
			w.X = 20 + ((i - 1) % 3) * 50;
			w.Y = 50 + ((i - 1) / 3) * 50;
        }
    }
}

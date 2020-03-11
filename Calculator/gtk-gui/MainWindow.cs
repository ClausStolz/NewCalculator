using System.Collections.Generic;
using System.Linq;

public partial class MainWindow
{

	private const int elementWidth  = 50;
	private const int elementHeight = 50;

	private const int offsetX = 20;
	private const int offsetY = 10;

	private const int defaultElementCountX = 4;
	private const int defaultElementCountY = 5;

	private global::Gtk.Label calcLabel;

	private global::Gtk.Fixed fixedCont;

	private List<global::Gtk.Button> digitButtons;


	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);

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

		this.calcLabel = new global::Gtk.Label()
		{
			WidthRequest  = elementWidth * defaultElementCountX,
            HeightRequest = elementHeight,
            Name          = "CalcLabel",
            Xalign        = 1F,
            Yalign        = 1F,
            Text          = "0"
		};

		this.fixedCont.Add(calcLabel);
		var w = (global::Gtk.Fixed.FixedChild)this.fixedCont[calcLabel];
		w.X   = offsetX;
		w.Y   = offsetY;

		BuildDigitButtons();

		this.Add(fixedCont);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}

		this.WidthRequest  = (2 * offsetX) + (defaultElementCountX * elementWidth);
		this.HeightRequest = (2 * offsetY) + (defaultElementCountY * elementHeight);
		this.DefaultWidth  = this.WidthRequest;
		this.DefaultHeight = this.HeightRequest;
		this.Resizable     = false;

		this.Show();

		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
	}

    protected virtual void BuildDigitButtons()
    {
        InitButton((2 * elementWidth), elementHeight, "0", "0", 0,
            ((defaultElementCountY - 2) * elementHeight), this.DigitButtonClick);

        for (int i = 1; i < 10; i++)
        {
			InitButton(elementWidth, elementHeight, i.ToString(), i.ToString(),
                    ((i - 1) % (defaultElementCountX - 1)) * elementWidth,
                    ((i - 1) / (defaultElementCountY - 2)) * elementHeight,
                    this.DigitButtonClick);
        }
    }

    private void InitButton(int width, int height, string suffix, string label,
        int positionX, int positionY, global::System.EventHandler clickEvent)
    {
		var button = new global::Gtk.Button()
		{
			WidthRequest  = width,
			HeightRequest = height,
			CanFocus      = true,
			Name          = "button" + suffix,
			UseUnderline  = true,
			Label         = global::Mono.Unix.Catalog.GetString(label)
		};

		button.Clicked += clickEvent;

		this.fixedCont.Add(button);
		this.digitButtons.Add(button);

        var w = (global::Gtk.Fixed.FixedChild)this.fixedCont[button];
		w.X   = offsetX + positionX;
		w.Y   = (offsetY + this.calcLabel.HeightRequest) + positionY;
	}
}

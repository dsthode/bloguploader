
// This file has been generated by the GUI designer. Do not modify.
namespace BlogUploader
{
	public partial class ResultWindow
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.Button btCopiar;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView tvResult;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget BlogUploader.ResultWindow
			this.Name = "BlogUploader.ResultWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("ResultWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child BlogUploader.ResultWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.btCopiar = new global::Gtk.Button ();
			this.btCopiar.CanFocus = true;
			this.btCopiar.Name = "btCopiar";
			this.btCopiar.UseUnderline = true;
			// Container child btCopiar.Gtk.Container+ContainerChild
			global::Gtk.Alignment w1 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w2 = new global::Gtk.HBox ();
			w2.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-copy", global::Gtk.IconSize.Menu);
			w2.Add (w3);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w5 = new global::Gtk.Label ();
			w5.LabelProp = global::Mono.Unix.Catalog.GetString ("Copiar texto");
			w5.UseUnderline = true;
			w2.Add (w5);
			w1.Add (w2);
			this.btCopiar.Add (w1);
			this.vbox1.Add (this.btCopiar);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.btCopiar]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.tvResult = new global::Gtk.TextView ();
			this.tvResult.CanFocus = true;
			this.tvResult.Name = "tvResult";
			this.tvResult.Editable = false;
			this.tvResult.AcceptsTab = false;
			this.tvResult.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow.Add (this.tvResult);
			this.vbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w11.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 806;
			this.DefaultHeight = 423;
			this.Show ();
			this.btCopiar.Clicked += new global::System.EventHandler (this.CopiarTexto);
		}
	}
}
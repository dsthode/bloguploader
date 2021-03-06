
// This file has been generated by the GUI designer. Do not modify.
namespace BlogUploader
{
	public partial class MainWindow
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label2;
		private global::Gtk.Label lbUserName;
		private global::Gtk.Button btAuthentication;
		private global::Gtk.Label label1;
		private global::Gtk.FileChooserWidget filechooserwidget3;
		private global::Gtk.HBox hbox1;
		private global::Gtk.CheckButton cbWatermark;
		private global::Gtk.CheckButton cbSignature;
		private global::Gtk.CheckButton cbFlickrUpload;
		private global::Gtk.Button btCargar;
		private global::Gtk.ProgressBar progressbar3;
		private global::Gtk.ScrolledWindow GtkScrolledWindow2;
		private global::Gtk.TextView tvLog;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget BlogUploader.MainWindow
			this.Name = "BlogUploader.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Blog Uploader");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.BorderWidth = ((uint)(2));
			// Container child BlogUploader.MainWindow.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Autorizado como:");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.lbUserName = new global::Gtk.Label ();
			this.lbUserName.Name = "lbUserName";
			this.lbUserName.LabelProp = global::Mono.Unix.Catalog.GetString ("No autorizado");
			this.hbox2.Add (this.lbUserName);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.lbUserName]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btAuthentication = new global::Gtk.Button ();
			this.btAuthentication.CanFocus = true;
			this.btAuthentication.Name = "btAuthentication";
			this.btAuthentication.UseUnderline = true;
			this.btAuthentication.Label = global::Mono.Unix.Catalog.GetString ("Autorizar programa");
			this.vbox2.Add (this.btAuthentication);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btAuthentication]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Seleccione la carpeta que contiene las imágenes que desea procesar...");
			this.vbox2.Add (this.label1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.label1]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.filechooserwidget3 = new global::Gtk.FileChooserWidget (((global::Gtk.FileChooserAction)(2)));
			this.filechooserwidget3.Name = "filechooserwidget3";
			this.vbox2.Add (this.filechooserwidget3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.filechooserwidget3]));
			w6.Position = 3;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.cbWatermark = new global::Gtk.CheckButton ();
			this.cbWatermark.CanFocus = true;
			this.cbWatermark.Name = "cbWatermark";
			this.cbWatermark.Label = global::Mono.Unix.Catalog.GetString ("Añadir marca de agua");
			this.cbWatermark.Active = true;
			this.cbWatermark.DrawIndicator = true;
			this.cbWatermark.UseUnderline = true;
			this.hbox1.Add (this.cbWatermark);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.cbWatermark]));
			w7.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.cbSignature = new global::Gtk.CheckButton ();
			this.cbSignature.CanFocus = true;
			this.cbSignature.Name = "cbSignature";
			this.cbSignature.Label = global::Mono.Unix.Catalog.GetString ("Añadir firma");
			this.cbSignature.Active = true;
			this.cbSignature.DrawIndicator = true;
			this.cbSignature.UseUnderline = true;
			this.hbox1.Add (this.cbSignature);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.cbSignature]));
			w8.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.cbFlickrUpload = new global::Gtk.CheckButton ();
			this.cbFlickrUpload.CanFocus = true;
			this.cbFlickrUpload.Name = "cbFlickrUpload";
			this.cbFlickrUpload.Label = global::Mono.Unix.Catalog.GetString ("Subir a Flickr");
			this.cbFlickrUpload.Active = true;
			this.cbFlickrUpload.DrawIndicator = true;
			this.cbFlickrUpload.UseUnderline = true;
			this.hbox1.Add (this.cbFlickrUpload);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.cbFlickrUpload]));
			w9.Position = 2;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w10.Position = 4;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btCargar = new global::Gtk.Button ();
			this.btCargar.CanFocus = true;
			this.btCargar.Name = "btCargar";
			this.btCargar.UseUnderline = true;
			// Container child btCargar.Gtk.Container+ContainerChild
			global::Gtk.Alignment w11 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w12 = new global::Gtk.HBox ();
			w12.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w13 = new global::Gtk.Image ();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			w12.Add (w13);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w15 = new global::Gtk.Label ();
			w15.LabelProp = global::Mono.Unix.Catalog.GetString ("Cargar imágenes");
			w15.UseUnderline = true;
			w12.Add (w15);
			w11.Add (w12);
			this.btCargar.Add (w11);
			this.vbox2.Add (this.btCargar);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btCargar]));
			w19.Position = 5;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.progressbar3 = new global::Gtk.ProgressBar ();
			this.progressbar3.Name = "progressbar3";
			this.vbox2.Add (this.progressbar3);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.progressbar3]));
			w20.Position = 6;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.tvLog = new global::Gtk.TextView ();
			this.tvLog.CanFocus = true;
			this.tvLog.Name = "tvLog";
			this.tvLog.Editable = false;
			this.tvLog.CursorVisible = false;
			this.tvLog.AcceptsTab = false;
			this.tvLog.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow2.Add (this.tvLog);
			this.vbox2.Add (this.GtkScrolledWindow2);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow2]));
			w22.Position = 7;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 661;
			this.DefaultHeight = 470;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.btAuthentication.Clicked += new global::System.EventHandler (this.btPerformAuthentication_Click);
			this.btCargar.Clicked += new global::System.EventHandler (this.btCargarImagenes_Click);
		}
	}
}

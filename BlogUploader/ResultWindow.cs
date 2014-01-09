using System;
using Gtk;

namespace BlogUploader
{
	public partial class ResultWindow : Gtk.Window
	{
		public ResultWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		
		public void DisplayText(string text)
		{
			tvResult.Buffer.Text = text;				
		}

		protected void CopiarTexto(object sender, EventArgs e)
		{
			Clipboard clip = GetClipboard (Gdk.Atom.Intern ("CLIPBOARD", false));
			clip.Text = tvResult.Buffer.Text;
			System.Windows.Forms.Clipboard.SetText (tvResult.Buffer.Text);
		}

	}
}


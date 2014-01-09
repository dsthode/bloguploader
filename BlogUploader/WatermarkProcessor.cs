using System;
using System.Drawing;
using System.IO;

namespace BlogUploader
{
	public class WatermarkProcessor
	{
		private string path;
		private bool addWatermarks;
		private bool addSignature;
		static int count = 0;
		
		public WatermarkProcessor (string path)
		{
			this.path = path;
		}
		
		public void Process(bool addWatermarks, bool addSignature)
		{
			this.addWatermarks = addWatermarks;
			this.addSignature = addSignature;
			DirectoryInfo di = new DirectoryInfo (path);
			Directory.CreateDirectory (Path.Combine (path, "proc"));
			switch (Environment.OSVersion.Platform) {
			case PlatformID.MacOSX:
			case PlatformID.Unix:
				ProcessMacLinux (di);
				break;
			default:
				ProcessWindows (di);
				break;
			}
		}

		private void ProcessMacLinux(DirectoryInfo di)
		{
			foreach (FileInfo fi in di.GetFiles("*.jpg")) {
				ProcessFile (fi.Name);
			}
			foreach (FileInfo fi in di.GetFiles("*.JPG")) {
				ProcessFile (fi.Name);
			}
		}

		private void ProcessWindows(DirectoryInfo di)
		{
			foreach (FileInfo fi in di.GetFiles("*.jpg")) {
				ProcessFile (fi.Name);
			}
		}
		
		public void ProcessFile(string fileName)
		{
			Image i = Image.FromFile (Path.Combine (path, fileName));
			Graphics g = Graphics.FromImage (i);
			if (this.addWatermarks) {
				Font f = new Font (FontFamily.GenericSansSerif, 12, FontStyle.Bold);
				SolidBrush b = new SolidBrush (Color.FromArgb (150, 255, 255, 255));
				SizeF sz = g.MeasureString ("http://clarabelen.com/inspiraciones", f);
				PointF p1 = new PointF (1 * i.Width / 8, 1 * i.Height / 8);
				if ((p1.X + sz.Width) > (i.Width - i.Width / 10)) {
					p1.X = i.Width - (i.Width / 10) - sz.Width;
				}
				PointF p2 = new PointF (4 * i.Width / 8, 3 * i.Height / 8);
				if ((p2.X + sz.Width) > (i.Width - i.Width / 10)) {
					p2.X = i.Width - (i.Width / 10) - sz.Width;
				}
				PointF p3 = new PointF (1 * i.Width / 8, 5 * i.Height / 8);
				if ((p3.X + sz.Width) > (i.Width - i.Width / 10)) {
					p3.X = i.Width - (i.Width / 10) - sz.Width;
				}
				PointF p4 = new PointF (4 * i.Width / 8, 7 * i.Height / 8);
				if ((p4.X + sz.Width) > (i.Width - i.Width / 10)) {
					p4.X = i.Width - (i.Width / 10) - sz.Width;
				}
				g.DrawString ("http://clarabelen.com/inspiraciones", f, b, p1);
				g.DrawString ("http://clarabelen.com/inspiraciones", f, b, p2);
				g.DrawString ("http://clarabelen.com/inspiraciones", f, b, p3);
//				g.DrawString ("http://clarabelen.com/inspiraciones", f, b, p4);
			}
			if (addSignature) {
				try {
					Image sig = Image.FromFile ("logo.png");
					Rectangle dest = new Rectangle ();
					int destWidth = i.Width - (30 * i.Width / 100);
					int destHeight = destWidth / (sig.Width / sig.Height);
					dest.X = (i.Width - destWidth) / 2;
					dest.Y = i.Height - destHeight - (2 * i.Height / 100);
					dest.Width = destWidth;
					dest.Height = destHeight;
					g.DrawImage (sig, dest);
				} catch (Exception e) {
					Console.WriteLine (e.Message);
				}
			}
			i.Save (string.Format (Path.Combine (path, Path.Combine ("proc", fileName)), count++));
		}
	}
}


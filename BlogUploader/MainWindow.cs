using System;
using Gtk;
using System.IO;
using FlickrNet;
using System.Threading;
using System.Text;

namespace BlogUploader
{
	public partial class MainWindow: Gtk.Window
	{	
		const int MAX_TRY_COUNT = 3;

		WatermarkProcessor wp = null;
		FlickUploader uploader = null;
		AuthenticationWindow authWindow = null;
		Flickr flickr = null;
		Thread imageUploadProgressThread = null;
		bool imageUploadStop;
		ResultWindow resWin = null;
		bool isFlickrAuthorized = false;
		
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			Build ();
			flickr = new Flickr ("4b922a62fcd6aaadd459d3115523d0c8", "58f33c2804b3af34");
			LoadFlickrAuthorization ();
			TestFlickrAuthorization ();
		}
	
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
		
		private void btPerformAuthentication_Click(object sender, EventArgs eventArgs)
		{
			if (authWindow == null) {
				Application.Invoke (delegate {
					authWindow = new AuthenticationWindow (flickr);
					authWindow.AuthenticationSucceeded += authWindow_AuthOK;
					authWindow.Show ();
				}
				);
			}
		}
		
		private void authWindow_AuthOK(Auth authData)
		{
			Application.Invoke (delegate {
				if (authWindow != null) {
					authWindow.Hide ();
					authWindow.Dispose ();
					authWindow = null;
				}
				lbUserName.Text = authData.User.UserName;
				isFlickrAuthorized = true;
			}
			);
			if (!string.IsNullOrEmpty (flickr.OAuthAccessToken) 
				&& !string.IsNullOrEmpty (flickr.OAuthAccessTokenSecret)) {
				SaveFlickrAuthorization ();
			}
		}
		
		private void LoadFlickrAuthorization()
		{
			try {
				FileStream fs = new FileStream ("flickrauth.data", FileMode.Open);
				StreamReader sr = new StreamReader (fs);
				string token = sr.ReadLine ();
				string secret = sr.ReadLine ();
				sr.Close ();
				fs.Close ();
				flickr.OAuthAccessToken = token;
				flickr.OAuthAccessTokenSecret = secret;
			} catch (Exception e) {
				Console.WriteLine (e.Message);
			}
		}

		private void TestFlickrAuthorization()
		{
			try {
				Auth auth = flickr.AuthOAuthCheckToken ();
				lbUserName.Text = auth.User.UserName;
				isFlickrAuthorized = true;
			} catch (Exception e) {
				lbUserName.Text = "No autorizado";
				Console.WriteLine (e.Message);
			}
		}
		
		private void SaveFlickrAuthorization()
		{
			FileStream fs = new FileStream ("flickrauth.data", FileMode.Create);
			StreamWriter sw = new StreamWriter (fs);
			sw.Write (string.Format ("{0}\n{1}", flickr.OAuthAccessToken, flickr.OAuthAccessTokenSecret));
			sw.Flush ();
			sw.Close ();
			fs.Close ();
		}
	
		private void btCargarImagenes_Click(object sender, EventArgs eventArgs)
		{
			LogMessage ("Comenzando proceso...\n");
			string path = System.IO.Path.Combine (filechooserwidget3.CurrentFolder, filechooserwidget3.Filename);
			if (!string.IsNullOrEmpty (path) && Directory.Exists (path)) {
				StartProcess (path);
			}
		}
	
		private void StartProcess(string path)
		{
			string curPath = path;
			DirectoryInfo di = new DirectoryInfo (path);
			if (cbFlickrUpload.Active && !isFlickrAuthorized) {
				MessageBox.Show ("No se pueden subir las fotos a Flickr sin estar autorizado");
			} else {
				if (cbWatermark.Active || cbSignature.Active) {
					wp = new WatermarkProcessor (path);
					wp.Process (cbWatermark.Active, cbSignature.Active);
					curPath = System.IO.Path.Combine (path, "proc");
				}
				if (cbFlickrUpload.Active) {
					uploader = new FlickUploader (flickr, curPath, di.Name);
					uploader.ImageUploaded += HandleImageUploaded;
					uploader.ImageUploadStart += HandleImageUploadStart;
					uploader.ImageUploadStop += HandleImageUploadStop;
					uploader.ImagesUploaded += HandleImagesUploaded;
					uploader.run ();
				} else {
					LogMessage ("Proceso terminado!\n");
				}
			}
		}

		void HandleImageUploadStart()
		{
			LogMessage ("Iniciando la carga de las imágenes\n");
			imageUploadProgressThread = new Thread (new ThreadStart (ImageUploadThreadProc));
			imageUploadStop = false;
			imageUploadProgressThread.Start ();
		}

		void HandleImageUploaded(string filename)
		{
			LogMessage (string.Format ("Cargando imágen {0}\n", filename));
		}

		void HandleImageUploadStop()
		{
			Application.Invoke (delegate {
				LogMessage ("Carga de las imágenes completada.\n");
			}
			);
		}

		void LogMessage(string message)
		{
			Application.Invoke (delegate {
				tvLog.Buffer.Text += message;
				tvLog.ScrollToIter (tvLog.Buffer.EndIter, 0.0, false, 0.0, 0.0);
			}
			);
		}

		void HandleImagesUploaded(System.Collections.Generic.List<string> imageIds)
		{
			StringBuilder sb = new StringBuilder ();
			PhotoInfo info = null;
			int count = 1;
			bool done = false;
			int tryCount = 0;
			LogMessage ("Obteniendo información de las imágenes. Espere, por favor.\n");
			foreach (string id in imageIds) {
				tryCount = 1;
				done = false;
				while (!done) {
					try {
						LogMessage ("Obteniendo información de la imágen " + count + " de " + imageIds.Count + "...\n");
						info = flickr.PhotosGetInfo (id);
						done = true;
						sb.Append (string.Format ("<img src=\"{0}\" alt=\"{1}\">\r\n\r\n",
					              info.OriginalUrl,
					              info.Title)
						);
					} catch (Exception ex) {
						LogMessage ("Error obteniendo datos (intento " + tryCount + " de " + MAX_TRY_COUNT + ")\n");
						if (++tryCount > MAX_TRY_COUNT) {
							done = true;
							sb.Append ("(Error obteniendo datos)\r\n\r\n");
							Console.WriteLine (ex.Message);
						}
					}
				}
				count += 1;
			}
			imageUploadStop = true;
			LogMessage ("Copie el código de la ventana y péguelo en el nuevo post.\n");
			Application.Invoke (delegate {
				resWin = new ResultWindow ();
				resWin.DisplayText (sb.ToString ());
				resWin.Modal = true;
				resWin.Show ();
			}
			);
		}
		
		private void ImageUploadThreadProc()
		{
			Application.Invoke (delegate {
				progressbar3.Fraction = 0;
			}
			);
			while (!imageUploadStop) {
				Application.Invoke (delegate {
					progressbar3.Pulse ();
				}
				);
				Thread.Sleep (150);
			}
			Application.Invoke (delegate {
				progressbar3.Fraction = 1;
			}
			);
		}
	}
}

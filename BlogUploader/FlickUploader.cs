using System;
using System.Threading;
using FlickrNet;
using System.Collections.Generic;
using System.IO;

namespace BlogUploader
{
	public class FlickUploader
	{
		string path;
		Thread thread;
		Flickr flickr = null;
		List<string> uploadedIds = null;
		string title;
		
		public delegate void ImagesUploadedDelegate (List<string> imageIds);
		public event ImagesUploadedDelegate ImagesUploaded;

		public delegate void ImageUploadedDelegate (string filename);
		public event ImageUploadedDelegate ImageUploaded;

		public delegate void ImageUploadStartDelegate ();
		public event ImageUploadStartDelegate ImageUploadStart;

		public delegate void ImageUploadStopDelegate ();
		public event ImageUploadStopDelegate ImageUploadStop;

		public FlickUploader (Flickr flickr, string path, string title)
		{
			this.flickr = flickr;
			this.path = path;
			this.title = title;
			uploadedIds = new List<string> ();
		}
		
		public void run()
		{
			thread = new Thread (new ThreadStart (threadProc));
			thread.Start (); 
		}
		
		private void threadProc()
		{
			if (ImageUploadStart != null) {
				ImageUploadStart ();
			}
			Console.WriteLine (string.Format ("Starting process with folder {0}", path));
			DirectoryInfo di = new DirectoryInfo (path);
			foreach (FileInfo fi in di.GetFiles("*.jpg")) {
				if (ImageUploaded != null) {
					ImageUploaded (fi.Name);
				}
				uploadedIds.Add (flickr.UploadPicture (fi.FullName, title, string.Empty, string.Empty, false, true, false));
			}
			Console.WriteLine ("Process completed");
			if (ImageUploadStop != null) {
				ImageUploadStop ();
			}
			if (ImagesUploaded != null) {
				ImagesUploaded (uploadedIds);
			}
		}
	}
}

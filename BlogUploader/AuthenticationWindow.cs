using System;
using FlickrNet;

namespace BlogUploader
{
	public partial class AuthenticationWindow : Gtk.Window
	{
		private Flickr flickr;
		public delegate void AuthenticationSucceededDelegate (Auth authData);
		public event AuthenticationSucceededDelegate AuthenticationSucceeded;
		private OAuthRequestToken reqToken;
		
		public AuthenticationWindow (Flickr flickr) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.flickr = flickr;
			try {
				reqToken = flickr.OAuthGetRequestToken ("oob");
			} catch (OAuthException) {
				flickr.OAuthAccessToken = string.Empty;
				flickr.OAuthAccessTokenSecret = string.Empty;
				reqToken = flickr.OAuthGetRequestToken ("oob");
			}
			string url = flickr.OAuthCalculateAuthorizationUrl (reqToken.Token, AuthLevel.Write);
			System.Diagnostics.Process.Start (url);
		}
		
		private void btAutenticate_Click(object sender, EventArgs eventArgs)
		{
			if (!string.IsNullOrEmpty (tbOAuthCode.Text.Trim ())) {
				try {
					OAuthAccessToken accessTok = flickr.OAuthGetAccessToken (reqToken, tbOAuthCode.Text.Trim ());
					flickr.OAuthAccessToken = accessTok.Token;
					flickr.OAuthAccessTokenSecret = accessTok.TokenSecret;
					Auth auth = flickr.AuthOAuthCheckToken ();
					if (AuthenticationSucceeded != null) {
						AuthenticationSucceeded (auth);
					}
				} catch (Exception e) {
					Console.WriteLine (e.Message);
				}
			}
		}
	}
}

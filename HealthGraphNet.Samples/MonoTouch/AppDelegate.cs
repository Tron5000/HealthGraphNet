using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using HealthGraphNet;
using HealthGraphNet.Models;

namespace HealthGraphNet.Samples.MonoTouch
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		#region Fields and Properties

		private const string HealthGraphAuthorizeEndpoint = "https://runkeeper.com/apps/authorize";
		protected UIWindow window;
		protected UINavigationController viewController;
		protected string ClientId { get; set; }
		protected string ClientSecret { get; set; }
		protected string RequestUri { get; set; }
		protected string Code { get; set; }

		//HealthGraphNet Objects
		protected AccessTokenManager TokenManager { get; set; }
		protected UsersModel User { get; set; }
		protected ProfileModel Profile { get; set; }

		//MonoTouch.Dialog Objects
		private EntryElement _clientIdEntry = new EntryElement("Client Id", string.Empty, string.Empty);
		private EntryElement _clientSecretEntry = new EntryElement("Client Secret", string.Empty, string.Empty);
		private EntryElement _requestUriEntry = new EntryElement("Request Uri", string.Empty, string.Empty);

		#endregion

		#region Overrides, Events and Helper Methods

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			var root = new RootElement("HealthGraph API App")
			{
				new Section(string.Empty, "If you don't have this info, register your app here: http://runkeeper.com/partner/applications")
				{
					_clientIdEntry,
					_clientSecretEntry,
					_requestUriEntry
				}
			};
			var vc = new DialogViewController(UITableViewStyle.Grouped, root, false);
			viewController = new UINavigationController(vc);
			vc.NavigationItem.RightBarButtonItem = new UIBarButtonItem("Next", UIBarButtonItemStyle.Done, AttemptAuth); 
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();			
			return true;
		}

		protected void AttemptAuth(object sender, EventArgs e)
		{
			_clientIdEntry.FetchValue();
			ClientId = _clientIdEntry.Value;
			_clientSecretEntry.FetchValue();
			ClientSecret = _clientSecretEntry.Value;
			_requestUriEntry.FetchValue();
			RequestUri = _requestUriEntry.Value;

			if ((string.IsNullOrEmpty(ClientId)) || (string.IsNullOrEmpty(ClientSecret)) || (string.IsNullOrEmpty(RequestUri)))
			{
				UIAlertView firstPageValidationAlert = new UIAlertView("Whoops!", "Please provide a Client Id, Client Secrent and Request Uri.", null, "Okay");
				firstPageValidationAlert.Show();
			}
			else
			{
				//Elements for Second Page - authorization
				var secondPage = new UIViewController();
				secondPage.Title = "Authorize";
				var authorizeWebView = new UIWebView(secondPage.View.Frame);
				secondPage.View.AddSubview(authorizeWebView);
				viewController.VisibleViewController.NavigationController.PushViewController(secondPage, true);
				authorizeWebView.LoadFinished += delegate(object s, EventArgs ev) {
					string currentUrl = authorizeWebView.Request.Url.AbsoluteString;
					const string CodeIdentifier = "code=";
					if (currentUrl.Contains(CodeIdentifier))
					{
						//We've received an authorization code - initialize the token manager to get a create a token
						Code = currentUrl.Substring(currentUrl.IndexOf(CodeIdentifier) + CodeIdentifier.Length);
						TokenManager = new AccessTokenManager(ClientId, ClientSecret, RequestUri);
						InvokeOnMainThread(() => {
							UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
						});
						TokenManager.InitAccessToken(Code);
						var userRequest = new UsersEndpoint(TokenManager);
						User = userRequest.GetUser();
						var profileRequest = new ProfileEndpoint(TokenManager, User);
						Profile = profileRequest.GetProfile();
						InvokeOnMainThread(() => {
							UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
						});
						ShowUserAndProfile();
					}
				};
				authorizeWebView.LoadRequest(new NSUrlRequest(new NSUrl(HealthGraphAuthorizeEndpoint + "?client_id=" + ClientId + "&redirect_uri=" + HttpUtility.UrlEncode(RequestUri) + "&response_type=code")));
			}
		}

		protected void ShowUserAndProfile()
		{
			var root = new RootElement("User & Profile")
			{
				new Section()
				{
					new StringElement("User Id", User.UserID.ToString()),
					new StringElement("Name", Profile.Name)
				}
			};
			var vc = new DialogViewController(UITableViewStyle.Grouped, root, false);
			viewController.NavigationController.TopViewController.PresentViewController(vc, false, null);
		}

		#endregion
	}
}
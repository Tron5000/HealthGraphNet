## HealthGraphNet - .NET Client Library for the Runkeeper HealthGraph API

##### Getting Started:
First, register your application with the HealthGraph API (http://developer.runkeeper.com/healthgraph/getting-started). This will assign you a ClientId & ClientSecret.  Hold onto these values along with the RequestUri you specified during the registration process.  Next, obtain an auth code from the authorization endpoint.  Using this code, the AccessTokenManager will be used to initialize an OAuth2 access token as follows. 

```csharp
    var tokenManager = new AccessTokenManager(CLIENT_ID, CLIENT_SECRET, REQUEST_URI);
	tokenManager.InitAccessToken(AUTH_CODE);
```

Then, make a call to the Users endpoint to retrieve all available endpoints.

```csharp
	var userWrapper = new Users(TokenManager);
    var user = userWrapper.GetUser();
```

Now, the available service endpoints may be called as needed.  Here is an example of how to retrieve profile data.

```csharp
	var profileWrapper = new Profile(TokenManager, user);
    var profile = profileWrapper.GetProfile();
```
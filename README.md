## HealthGraphNet :: A .NET Library for the Runkeeper HealthGraph API

##### Getting Started:
First, register your application with the HealthGraph API (http://developer.runkeeper.com/healthgraph/getting-started). This will assign you a ClientId & ClientSecret.  Hold onto these values along with the RequestUri you specified during the registration process.  Next, obtain an auth code from the authorization endpoint.  Using this code, the AccessTokenManager will be used to initialize an OAuth2 access token as follows: 

```csharp
    var tokenManager = new AccessTokenManager(CLIENT_ID, CLIENT_SECRET, REQUEST_URI);
	tokenManager.InitAccessToken(AUTH_CODE);
```

Then, make a call to the UsersEndpoint to retrieve the endpoints available to the user.

```csharp
	var userRequest = new UsersEndpoint(TokenManager);
    var user = userRequest.GetUser();
```

Now the endpoints may be called as needed.  Here is an example of how to retrieve profile data.

```csharp
	var profileRequest = new ProfileEndpoint(TokenManager, user);
    var profile = profileRequest.GetProfile();
```

Every endpoint request is synchronous and has a corresponding asynchronous method.  To make the above retrieval of profile data an asynchronous call, we'd change the code to the following:

```csharp
	var profileRequest = new ProfileEndpoint(TokenManager, user);
    profileRequest.GetProfileAsync((prof) =>
	{
		//ProfileModel was successfully retrieved as prof.
	}, 
	(ex) =>
	{
		//An exception happened while trying to retrieve the ProfileModel.
	});
```

#####Navigating the Endpoints
Care is taken to only use endpoint Uri's delivered by the HealthGraph API itself instead of trying to construct Uri's based on assumed paths and Ids (as per http://developer.runkeeper.com/healthgraph/overview#navigating-healthgraph).
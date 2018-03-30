# Facebook Messenger Webhook
###### A .NET Core Implementation
This a .NET Core implementation of the __Facebook Messenger Webhook__ used for Facebook Messenger Bots.

The following commands are used to test and verify that the application is working:

```curl -X GET "localhost:5000/api/webhook?hub.verify_token=63ogWaweN8&hub.challenge=CHALLENGE_ACCEPTED&hub.mode=subscribe"```

```curl -H "Content-Type: application/json" -X POST "localhost:5000/api/webhook" -d '{"object": "page", "entry": [{"messaging": [{"message": "TEST_MESSAGE"}]}]}'```

__** NOTE that the `verify_token` query parameter cooresponds to the token referenced in the `appsettings.Development.json` file__

You can find Facebook's documentation of a Node.js implementation here: https://developers.facebook.com/docs/messenger-platform/getting-started/webhook-setup

## PUBLISHING
For security purposes, be sure to change the `Token` value in `appsettings.json` or, better yet, set the value on the server, as I have done in the `appsettings.json` file with `__TOKEN__`, when publishing to a server

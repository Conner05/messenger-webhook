# messenger-webhook
This a .NET Core implementation of the Facebook Messenger Webhook used for Facebook Messenger bots.

The following commands are used to test and verify that the application is working:

curl -X GET "localhost:5000/api/webhook?hub.verify_token=63ogWaweN8&hub.challenge=CHALLENGE_ACCEPTED&hub.mode=subscribe"

curl -H "Content-Type: application/json" -X POST "localhost:5000/api/webhook" -d '{"object": "page", "entry": [{"messaging": [{"message": "TEST_MESSAGE"}]}]}'

** NOTE that the verify_token query parameter cooresponds to the token referenced in the appsettings.Development.json file

You can find Facebook's documentation of a Node.js implementation here: https://developers.facebook.com/docs/messenger-platform/getting-started/webhook-setup

PUBLISHING
For security purposes, be sure to change the verify token when publishing to a server.

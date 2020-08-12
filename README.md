# HappeningsQuote
 Happenings Quote app, .net Core (EF) Backend with a RestAPI to the SQL database. The .net app is written with clean/onion architecture

## Get the project up and running
Step 1

Open the project and select the `RestAPI` as the __startup__ project.

Step 2

Build and start the app, this should create the context and setup the initial `Quote.db` SQL database, located in the `RestAPI` project.

Step 3

Use either the provided `Postman` exported json file, to get an easy and premade collection of HTTP Requests to send the API.
- You can, and should, also be able to interact with the API through the related `Angular_HappeningsQuote` App.

## Install and setup finished

### InMemory DB instead of SQL

You are able to use an `In Memory` database instead, should you want that. The way to swap these is to simply, in the `RestAPI/Startup` class, follow the instructions and
swap the comment section to use your desired database.

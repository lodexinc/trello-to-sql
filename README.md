# Trello to SQL

Well, this is pretty straight forward. This web application will access your Trello board and then create a local MS SQL database with all your boards, lists, cards and their actions. This makes reporting a breeze. You can calculate the duration of a card in a list, resources assigned etc.

**Trello API key:**

Get an Application Key from Trello and insert it in the web.config file:

[https://trello.com/app-key/](https://trello.com/app-key/)

**Getting started:**

Now you need to create the database using the script provided:

![alt text](http://burgstudio.co.za/images/git/1.png "Create your database")

Then, you need to specify your connection string:

![alt text](http://burgstudio.co.za/images/git/2.png "Setup the connection")

You also need to then give permissions to the application to access your Trello board:

![alt text](http://burgstudio.co.za/images/git/4.png "Authorise Trello")

OK, you are ready... as soon as you run the application you should see (holding thumbs) the folders piling up in the output folder:

![alt text](http://burgstudio.co.za/images/git/5.png "Folders created")

If you get stuck or can't get this working, just pop us a mail and we'll gladly help you out: [info@burgstudio.co.za](mailto:info@burgstudio.co.za).

Enjoy!

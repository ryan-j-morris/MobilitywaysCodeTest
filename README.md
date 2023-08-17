# MobilitywaysCodeTest

For this test, please create a minimal dotnet (C#) REST API that has the following endpoints:  

1.     Create user: 

  a.     This endpoint should require name, email and password and create a new user and store in-memory.  

2.     Get JWT token: 

  a.     This endpoint should require an email and password and generate a Jason Web Token (JWT) for the matching user if found in in-memory store. 

3.     List users: 

  a.     This endpoint should list all users in the in-memory store. This endpoint should require bearer authentication using a valid JWT (obtained from above endpoint).  

Considerations I've taken when approaching this project:

- In the task you requested that the API should be minimal, so I've tried to bear this in mind when coding this. I think there are other end points that could be added to the API in the future to make it potentially more useful, such as:
Delete userFind user (by providing either full or partial email address for example)Edit user
- I've tried to put code into logical files and then those files in a logical folder structure. For a solution of this size it probably wasn't necessary, but I think it makes it easier to start with a good structure if the project grows rather than try to introduce one at a later date. I also think that it will help with maintainability and if any need for reuse should arise.
- I've used some NuGet packages, EntityFrameWorkCore.InMemory to store information in memory in place of a database, as well as Microsoft.AspNetCore.Authentication.JwtBearer and System.IdentityModel.Tokens.Jwt to help with the JSON web token authentication.
- I've added an Id to the user. It's not really needed currently, as email address could be used as the primary key, but I would rather have this in place now than to add it later.
- I've added code to hash the passwords, as I don't think storing passwords in plain text is a great idea. I think there are better ways to do the hashing, but are more complicated and would have taken more time.
- I've removed the password from the List Users function, as it didn't seem secure to return that. Also it wouldn't make much sense to the user as the password would be hashed.
- I've added code to prevent the same email address being added more than once, as I thought this should be unique.
- I've created a return object for the user creation so that a success and message parameter can be passed back so that if the post isn't a success they will get a friendly error message to tell them what the problem was.
- I've added some code to validate the email address. I considered using a regex expression to do this, but none of them are perfect. I'm not sure the method I've chosen is perfect either, but it seemed to work fairly well.
- I considered adding password length and complexity requirements, but it seemed like something that could be added in the future, so I left it out for now.
- I considered adding unit tests for the project, but thought it was probably overkill for this project, so I've included a Postman Collection for testing with examples on GitHub. I've also left the swagger config in to help with testing.
- I've added some comments, but kept them fairly minimal as I think that most of the code is fairly easy to follow. I've known some developers who are very anti comments and some who are very comment happy so I've tried to aim somewhere in the middle.

# Software Requirements

## Vision
Our Guild API team has set out to help other software engineers reduce their workload by creating an API for multiplayer development. 
This API will create the basic structure of a guild or clan with roles, permissions and a hierarchy. Our users will have store the user information
into a database on our server and be able to remove users from the database, change roles and anything else they require to make a functioning guild.

## Scope
### In
* The API Server will provide users the ability to create a Guild/Clan within their game and store that information into a database
* Users will be able to set roles of the users in the database
* Users will be able to set permissions of those roles
* Users will be able to utilize the API for their game and/or a front end web application to display to their users all the guild/clan information

### Out
* Users will not be able to give permissions to their users to modify/delete the game database
* Users will not be able to get the code

## Minimum Viable Product
What will your MVP functionality be?
- Create new GameGuildDatabase
- API Calls: Create new Guild (post), Add new GuildRank's (post), Add GuildMember to Guild (post), Set GuildRank of GuildMember (put), Kick GuildMember (delete), View Guilds by Game (get)
- Authentication: Account 'per game'
- Authorization: Anonymous users can only make 'get' calls to view Guilds, Administrator users can create new games for an organization, Manager users are assigned to specific games and only manage guilds for that game
Two structures for authorization/authentication
API End: Accounts for devs
Guild End: Accounts for users

### Stretch
- Develop a web app that makes Guild API calls from the backend
- More API Calls: Add RankPolicy's (post), Set RankPolicy to GuildRank (put)

## Functional Requirements
1) An Admin will be able to create a database for games and full rights to the database they are assigned to

2) An Admin can create account Managers and assign roles up to Manager.

3) An Admin and a Manager can create guilds

4) An Admin and a Manager can delete guilds

5) An Admin and a Manager can add Guild Members and remove Guild members

6) An Admin and a Manager can update Guilds and Guild Members

7) An anonymous user can view/get game information.

3) A Manager will have full rights to guilds within the game they are assigned to. 


### Data Flow

![Data Flow](./Assets/Data-Flow.jpg)


## Non-Functional Requirements

## Security
* Will be secured by only authorizing users with permissions to access the database
* DTO's will provide an additional layer of security
* API will be deployed on Azure which provides an additional layer of security

## Usability
* Will provide very clear documentation on how to do API Calls.
* Documentation will present the structure of what the JSON file will look like
* Documentation will include examples of API Calls
* Documentation will be as simplified as possible as to not overcomplicate it


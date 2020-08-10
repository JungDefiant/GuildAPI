![Actions Status](https://github.com/jeremymaya/Code-401-Async-Inn-API/workflows/build/badge.svg)  
# GuildAPI
**Authors:** Bryant Davis, Lesley Rivera, Peyton Cysewski, Bade Habib  

# Description
This is a service that allows game developers to outsource their guild information

* Developers can make API calls on their servers to keep track of what guilds are in their games

* Developers will have their games registered into our databases.

* By default, the service allows clients to create new guilds within their games.

# Table of Contents
| Link     |Name       |
|----------|:-----------------------------------------------------------------------------:|
|[Process](#process) 	|Process Documention(ERD, Data Flow, Domain Model)       	|
|[Project Board](#project-board) 	|Project Board       	|
|[ERD](#erd) 	|ERD       	|
|[Data Flow](#data-flow) 	|Data Flow    	|
|[Domain Model](#domain-model) 	|Domain Model    	|
|[API Calls](#api-calls) 	|API Calls    	|
|[Registration](#registration) 	|Register an Account    	|
|[Login](#login) 	|Login with your Account    	|
|[Guild](#guild) 	|Guild API Calls    	|
|[Create Guild](#create-guild) 	|Create Guild  	|
|[Update Guild](#update-guild) 	|Update Guild  	|
|[Delete Guild](#delete-guild) 	|Delete Guild  	|
|[Get](#get) 	|Get Routes  	|
|[Get All Games](#get-all-games) 	|Get All Games  	|
|[Get Individual Game](#get-individual-game) 	|Get Get Individual Game  	|
|[Get All Guilds](#get-all-guilds) 	|Get All Guilds  	|
|[Get Individual Guild](#get-individual-guild) 	|Get Individual Guild  	|




## Process
[Top](#table-of-contents)


### Project Board
[Top](#table-of-contents)

[Project Board](https://github.com/JungDefiant/GuildAPI/projects/1)

### ERD
[Top](#table-of-contents)


![ERD](./Assets/ERD.png)

### Data Flow
[Top](#table-of-contents)

![Data Flow](./Assets/Data-Flow.jpg)

### Domain Model
[Top](#table-of-contents)

![Domain Model](./Assets/DomainModelDiagram.png)

## API Calls
[Top](#table-of-contents)

In This section we will show you how to do each API call

### Registration
[Top](#table-of-contents)

To register an account please Email us at admin@GuildApi.com with the following information:
* First Name
* Last Name
* Email address
* Name of Game(s)

### Login
[Top](#table-of-contents)

`https://guildapi.azurewebsites.net/api/Account/Login
{
	"Email" : Admin@gmail.com
	"Password" : Testing123!@
}`

You will then receive a token that is good for 24hrs and will need to use this token for Authorization.

## Guild
[Top](#table-of-contents)

You must be authenticated by loggin in and passing that in as a Bearer to create, update or delete guilds.

### Create Guild
[Top](#table-of-contents)


Route:
`/api/Guilds/Game/{gameId}`
`{
  "name": "string",
}`


### Update Guilds
[Top](#table-of-contents)


Route:
`/api/Guilds/{id}`
`{
  "id": 0,
  "name": "string",
}`

### Delete Guilds
[Top](#table-of-contents)


Route:
`/api/Guilds/{guildId}/Game/{gameId}`

### Games
[Top](#table-of-contents)


In order to update the Game Name, Deletion of your Game, or to add more managers to your game please contact us at admin@GuildAPI.com

Please note if you delete a game, you will no longer have access to it, all information regarding your game will be removed from our database.
If their are multiple developers attached to a game we will need all of their permission to delete a game.

## Get
[Top](#table-of-contents)


No account is required for get routes.

### Get All Games
[Top](#table-of-contents)


Route:
`/api/Games`

### Get Individual Game
[Top](#table-of-contents)


Route:
`/api/Games/{id}`

### Get All Guilds
[Top](#table-of-contents)


Route:
`/api/Guilds`

### Get Individual Guild
[Top](#table-of-contents)


Route:
`/api/Guilds/{id}`

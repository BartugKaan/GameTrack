# Game Treack

GameTrack is an ASP.NET Core 7.0 application designed for listing and managing games and their genres. Additionally, games can be categorized by genre. The application supports CRUD operations such as viewing, adding, updating, and deleting games and Genres.

## Features

- View and Display Detailed information about games.
- Add, Edit and Delete Games and Genres.
- User-friendly interface with Bootstrap support.
- SQLite database integration with bootstrap support.
- Data acess layer with Enity Framework Core.
- Follows the MVC structure.

## Usage

1. Clone the repository or download the Zip file and extract it:

```bash
git clone https://github.com/BartugKaan/GameTrack.git
```

2. Navigate to the project directory:

```bash
cd GameTrack
```

3. Install the required dependencies:

```bash
dotnet restore
```

4. Create the database and apply migrations:

```bash
dotnet ef database update
```

5. Run the application:

```bash
dotnet run
```

## Project Structure

- <b> Controllers/ </b> - Contains the MVC controllers (GameController, GenreController and HomeController)
- <b> Views/ </b> - Contains the .cshtml views(Game, Genre and Home)
- <b> Models/ </b> - Holds Game and Genre entities.
- <b> Data/ </b> - Database context and Ef Code configurations

## Images

## Contributing

If you would like to contribute, please submit a pull request or open an issue.

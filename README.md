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
<img width="1080" alt="Screenshot 2024-10-20 at 14 33 18" src="https://github.com/user-attachments/assets/2049bff5-a48c-4401-8e4a-862fd0345a1a">
<img width="1080" alt="Screenshot 2024-10-20 at 14 34 05" src="https://github.com/user-attachments/assets/ed32b84b-88b3-4a66-babe-eae914f4c259">
<img width="1080" alt="Screenshot 2024-10-20 at 14 33 24" src="https://github.com/user-attachments/assets/49e96da9-902f-4cdb-900e-f4f9fa8cc654">
<img width="1080" alt="Screenshot 2024-10-20 at 14 33 28" src="https://github.com/user-attachments/assets/514362b2-fe52-4d73-b310-3bd7deb39d04">


## Contributing

If you would like to contribute, please submit a pull request or open an issue.

/* 
Nathan Hillhouse
10/24/2025
Lab 8 - Maze
*/

Random rand = new Random();

string[] maprows = File.ReadAllLines("./map.txt");
char playercharacter = '█';
char[,] grid = new char[maprows.Length, maprows[0].Length];
char walls = '#';
char finish = '*';

//Transfer data into grid
for (int i = 0; i < maprows.Length; i++)
    for (int j = 0; j < maprows[0].Length; j++)
        grid[i, j] = maprows[i][j];

(int x, int y) playerlocation = (0, 0);

grid[playerlocation.y, playerlocation.x] = playercharacter;

Console.CursorVisible = false;
DrawGrid();

do
{
    ConsoleKey key = Console.ReadKey(true).Key;

    Console.SetCursorPosition(playerlocation.x, playerlocation.y+2);

    if (key == ConsoleKey.Escape)
    {
        Console.WriteLine("You exited the game.");
        break;
    }
    else if (key == ConsoleKey.RightArrow)
    {
        if (Collision(grid, new(playerlocation.x + 1, playerlocation.y)))
        {
            Console.Write(" ");

            playerlocation.x = playermovement(1, playerlocation.x);

            if (grid[playerlocation.y, playerlocation.x] == finish) break;

            grid[playerlocation.y, playerlocation.x] = playercharacter;

            Console.SetCursorPosition(playerlocation.x, playerlocation.y+2);
            Console.Write(playercharacter);
        }
        continue;
    }
    else if (key == ConsoleKey.LeftArrow)
    {
        if (Collision(grid, new(playerlocation.x - 1, playerlocation.y)))
        {
            Console.Write(" ");

            playerlocation.x = playermovement(-1, playerlocation.x);

            if (grid[playerlocation.y, playerlocation.x] == finish) break;

            grid[playerlocation.y, playerlocation.x] = playercharacter;

            Console.SetCursorPosition(playerlocation.x, playerlocation.y+2);
            Console.Write(playercharacter);
        }
        continue;
    }
    else if (key == ConsoleKey.UpArrow)
    {
        if (Collision(grid, new(playerlocation.x, playerlocation.y - 1)))
        {
            Console.Write(" ");

            playerlocation.y = playermovement(-1, playerlocation.y);

            if (grid[playerlocation.y, playerlocation.x] == finish) break;

            grid[playerlocation.y, playerlocation.x] = playercharacter;

            Console.SetCursorPosition(playerlocation.x, playerlocation.y+2);
            Console.Write(playercharacter);
        }
        continue;
    }
    else if (key == ConsoleKey.DownArrow)
    {
        if (Collision(grid, new(playerlocation.x, playerlocation.y + 1)))
        {
            Console.Write(" ");
            playerlocation.y = playermovement(1, playerlocation.y);

            if (grid[playerlocation.y, playerlocation.x] == finish) break;

            grid[playerlocation.y, playerlocation.x] = playercharacter;

            
            Console.SetCursorPosition(playerlocation.x, playerlocation.y+2);
            Console.Write(playercharacter);
        }
        continue;
    }

} while (true);

Console.SetCursorPosition(0, grid.GetLength(0) + 3);
Console.WriteLine("You Win! ");

bool Collision(char[,] grid, (int x, int y) location)
{
    if (location.x < 0 || location.y < 0 || location.x >= grid.GetLength(1) || location.y >= grid.GetLength(0) ||
        grid[location.y, location.x] == walls)
        return false;

    return true;
}

int playermovement(int movement, int location)
{
    grid[playerlocation.y, playerlocation.x] = ' ';
    location += movement;
    return location;
}

void DrawGrid()
{
    Console.Clear();
    Console.WriteLine("Welcome to the Maze! You will use your arrow keys to navigate the maze.");
    Console.WriteLine();

    for (int i = 0; i < maprows.Length; i++)
    {
        for (int j = 0; j < maprows[0].Length; j++)
        {
            Console.Write(grid[i, j]);
        }
        Console.WriteLine();
    }
}

/*
Nathan Hillhouse
10/24/2025
Lab 8 - Maze
*/


Console.Clear();
Console.WriteLine("Welcome to the Maze! You will use your arrow keys to navigate the maze.");
Console.WriteLine();

string[] maprows = File.ReadAllLines("./map.txt");
foreach (string item in maprows) Console.WriteLine(item);
(int x, int y) cursorPosition = (0, 2);
Console.SetCursorPosition(cursorPosition.x, cursorPosition.y);

do
{
    System.ConsoleKey key = Console.ReadKey(true).Key;
    if (key == ConsoleKey.Escape) break;
    else if (key == ConsoleKey.UpArrow) cursorPosition.y--;
    else if (key == ConsoleKey.DownArrow) cursorPosition.y++;
    else if (key == ConsoleKey.RightArrow) cursorPosition.x++;
    else if (key == ConsoleKey.LeftArrow) cursorPosition.x--;
    else continue;
    if (cursorPosition.x < 0) cursorPosition.x = 0;
    if (cursorPosition.y < 0) cursorPosition.y = 0;
    Console.SetCursorPosition(cursorPosition.x, cursorPosition.y);
}
while (true);
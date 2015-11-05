namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Minesweeper
    {
        public static void Main()
        {
            const int MaximumCellsToOpen = 35;

            string command = string.Empty;
            char[,] board = CreateGameBoard();
            char[,] bombs = GenerateBombs();
            int pointCounter = 0;
            bool openedMine = false;
            int row = 0;
            int col = 0;
            bool noGameActive = true;
            bool wonTheGame = false;

            List<Score> topPlayers = new List<Score>(6);

            do
            {
                if (noGameActive)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    ShowBoardOnConsole(board);
                    noGameActive = false;
                }

                Console.Write("Daj red i kolona : ");

                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowHighScores(topPlayers);
                        break;
                    case "restart":
                        board = CreateGameBoard();
                        bombs = GenerateBombs();
                        ShowBoardOnConsole(board);
                        openedMine = false;
                        noGameActive = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                OpenPositionOnBoard(board, bombs, row, col);
                                pointCounter++;
                            }

                            if (MaximumCellsToOpen == pointCounter)
                            {
                                wonTheGame = true;
                            }
                            else
                            {
                                ShowBoardOnConsole(board);
                            }
                        }
                        else
                        {
                            openedMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (openedMine)
                {
                    ShowBoardOnConsole(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. Daj si niknejm: ", pointCounter);
                    string name = Console.ReadLine();
                    Score currentPlayer = new Score(name, pointCounter);
                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < currentPlayer.Points)
                            {
                                topPlayers.Insert(i, currentPlayer);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    topPlayers.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    ShowHighScores(topPlayers);

                    board = CreateGameBoard();
                    bombs = GenerateBombs();
                    pointCounter = 0;
                    openedMine = false;
                    noGameActive = true;
                }

                if (wonTheGame)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvori 35 kletki bez kapka kryv.");
                    ShowBoardOnConsole(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Score currentPlayer = new Score(name, pointCounter);
                    topPlayers.Add(currentPlayer);
                    ShowHighScores(topPlayers);
                    board = CreateGameBoard();
                    bombs = GenerateBombs();
                    pointCounter = 0;
                    wonTheGame = false;
                    noGameActive = true;
                }
            }
            while (command != "exit");
            
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowHighScores(List<Score> listOfHighScores)
        {
            Console.WriteLine("\nPoints:");
            if (listOfHighScores.Count > 0)
            {
                for (int i = 0; i < listOfHighScores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, listOfHighScores[i].Name, listOfHighScores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty High Score List!\n");
            }
        }

        private static void OpenPositionOnBoard(char[,] board, char[,] bombs, int row, int col)
        {
            char countBombs = CountBombs(bombs, row, col);
            bombs[row, col] = countBombs;
            board[row, col] = countBombs;
        }

        private static void ShowBoardOnConsole(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateBombs()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '-';
                }
            }

            var bombs = new List<int>();
            while (bombs.Count < 15)
            {
                var random = new Random();
                int randonNumber = random.Next(50);
                if (!bombs.Contains(randonNumber))
                {
                    bombs.Add(randonNumber);
                }
            }

            foreach (int bomb in bombs)
            {
                int col = bomb / boardColumns;
                int row = bomb % boardColumns;
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = boardColumns;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        private static void CheckNumberOfNeighbourBombs(char[,] board)
        {
            int col = board.GetLength(0);
            int row = board.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char numberOfNeighbourBombs = CountBombs(board, i, j);
                        board[i, j] = numberOfNeighbourBombs;
                    }
                }
            }
        }

        private static char CountBombs(char[,] board, int row, int col)
        {
            int count = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    count++;
                }
            }
            
            if (col + 1 < cols)
            {
                if (board[row, col + 1] == '*')
                {
                    count++;
                }
            }
            
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
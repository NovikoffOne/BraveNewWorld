using System;

namespace BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsWork = true;
            char playerIcon = '@';
            char barrierIcon = '#';

            int playerSpeed = 1;
            int playerPositionX = 1;
            int playerPositionY = 1;
            int playerDirectionX = 0;
            int playerDirectionY = 0;

            char[,] map =
            {
                {barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon,barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', barrierIcon },
                {barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon,
                    barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon, barrierIcon },
            };

            Console.CursorVisible = false;

            while (IsWork)
            {
                playerDirectionX = 0;
                playerDirectionY = 0;

                DrawMap(map);
                DrawPlayer(playerPositionX, playerPositionY, playerIcon);

                ConsoleKeyInfo charKey = Console.ReadKey();

                if (charKey.Key == ConsoleKey.Spacebar)
                {
                    CreateBarrier(ref map, playerPositionY, playerPositionX, barrierIcon);
                }
                else if (charKey.Key == ConsoleKey.Escape)
                {
                    IsWork = false;
                }
                else
                {
                    ChangeDirection(charKey, ref playerDirectionX, ref playerDirectionY, playerSpeed);

                    GetNextPosition(playerPositionX, playerPositionY, ref playerDirectionX, ref playerDirectionY);

                    if (CanMove(map, playerDirectionX, playerDirectionY, barrierIcon) == false)
                        Move(ref playerPositionX, ref playerPositionY, playerDirectionX, playerDirectionY);
                }

                Console.Clear();
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY, int speed)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionY = -speed;
                    break;

                case ConsoleKey.DownArrow:
                    directionY = speed;
                    break;

                case ConsoleKey.LeftArrow:
                    directionX = -speed;
                    break;

                case ConsoleKey.RightArrow:
                    directionX = speed;
                    break;

                default:
                    return;
            }
        }

        static void CreateBarrier(ref char[,] map, int positionX, int positionY, char barrierIcon)
        {
            map[positionX, positionY] = barrierIcon;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void GetNextPosition(int positionX, int positionY, ref int directionX, ref int directionY)
        {
            directionX += positionX;
            directionY += positionY;
        }

        static void Move(ref int playerPositionX, ref int playerPositionY, int playerDirectionX, int playerDirectionY)
        {
            playerPositionX = playerDirectionX;
            playerPositionY = playerDirectionY;
        }

        static void DrawPlayer(int playerPositionX, int playerPositionY, char playerIcon)
        {
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(playerIcon);
        }

        static bool CanMove(char[,] map, int directionX, int directionY, char barrierIcon)
        {
            return map[directionY, directionX] == barrierIcon;
        }
    }
}

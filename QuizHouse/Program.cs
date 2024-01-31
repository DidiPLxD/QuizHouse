// See https://aka.ms/new-console-template for more information
namespace QuizHouse
{
    class Program
    {
        public static void Main(string[] args) {
            mainMenu();
        }

        public static void mainMenu()
        {
            Console.WriteLine("Wybierz grę: ");//1.1
            Console.WriteLine("Ciepło-zimno: 1 ");
            Console.WriteLine("Ciepło-zimno multiplayer: 2");
            Console.WriteLine("Zakończ: 0 ");

            int selectedGame = Convert.ToInt32(Console.ReadLine());//7

            switch (selectedGame)//3
            {
                case 1:
                    Console.WriteLine("Wybrano ciepło-zimno");
                    playSingle();
                    break;
                case 2:
                    Console.WriteLine("Wybrano ciepło-zimno multiplayer");
                    playMulti();
                    break;
                default:
                    Console.WriteLine("Papa!");
                    break;
            }

        }

        public static void playSingle()//11
        {
            int numberOfLives = 5;//4
            Console.WriteLine("Zgadnij liczbę:");

            int randomNumber = generateRandomNumber();
            

            while (numberOfLives > 0)
            {
                Console.WriteLine("Pozostało żyć: " + numberOfLives);//4
                int playerGuess = Convert.ToInt32(Console.ReadLine());//4

                if (playerGuess == randomNumber)
                {
                    Console.WriteLine("Win");
                    break;
                }
                else
                {
                    equalityResolver(playerGuess, randomNumber);
                    numberOfLives--;//4
                }

            }

            if (numberOfLives == 0)
            {
                Console.WriteLine("Gra skończona chodziło o liczbę: " + randomNumber);
            }
            mainMenu();

        }

        public static void playMulti()//11
        {
            int randomNumber = generateRandomNumber();
            int numberOfTurns = 3;

            List<string> playerList = new List<string>();
            Console.WriteLine("Podaj liczbe graczy: ");
            int numberOfPlayers = Convert.ToInt32(Console.ReadLine());//4;7

            for (int i = 0; i < numberOfPlayers; i++) //6
            {
                Console.WriteLine("Podaj imie gracza nr: " + (i+1L));
                playerList.Add(Console.ReadLine());
            }

            bool isInProgress = true;//4

            do //6
            {
                Console.WriteLine("Pozostało tur: " + numberOfTurns);
                foreach (var playerName in playerList) //6
                {
                    Console.WriteLine(playerName + " zgaduje liczbę:");//1.2
                    int playerGuess = Convert.ToInt32(Console.ReadLine());//2;7

                    if (playerGuess == randomNumber)//3;8
                    {
                        Console.WriteLine(playerName + " win");
                        Console.WriteLine("Koniec gry");
                        isInProgress = false;//4
                        break;
                    }
                    else
                    {
                        equalityResolver(playerGuess, randomNumber);
                    }
                }

                numberOfTurns--;//9

            } while (isInProgress && numberOfTurns > 0); //5;8

            if (numberOfTurns == 0 && isInProgress) 
            {
                Console.WriteLine("Gra skończona chodziło o liczbę: " + randomNumber);
            }

            mainMenu();

        }

        public static void equalityResolver(int playerGuess, int randomNumber)
        { //11
            if (Math.Abs(playerGuess - randomNumber) > 10)//3
            {
                Console.WriteLine("ZIMNO");
            }
            else
            {
                Console.WriteLine("CIEPŁO");
            }
            if (playerGuess > randomNumber)
            {
                Console.WriteLine("Podana liczba jest za duża");
            }
            else
            {
                Console.WriteLine("Podana liczba jest za mała");
            }

        }

        public static int generateRandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 100);
        }
    }
}


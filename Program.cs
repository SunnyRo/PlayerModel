using System.Text.RegularExpressions;
// Declare variable
string userInput;
string option;
int numOfPlayer;
string[] userInfo;
bool run = true;
// input validation method check if the input is empty or null
static bool isValid(String para)
{
    if (String.IsNullOrEmpty(para))
    {
        Console.WriteLine("Name cannot be null or empty");
        return false;
    }
    return true;
}
// input email validation method 
static bool isEmail(string email)
{
    string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$";
    if (!Regex.IsMatch(email, pattern))
    {
        Console.WriteLine("Email is invalid! please try again");
        return false;
    }
    return true;
}
static void PrintPlayerInfo(PlayerModel player)
{
    Console.WriteLine($"Name:{player.Name}");
    Console.WriteLine($"Email:{player.Email}");
    Console.WriteLine($"Id:{player.Id}");
}

try
{
    Console.WriteLine("-------------------------------------Hellow World-------------------------------------");
    Console.WriteLine("Please enter the number of players you want to create");
    userInput = Console.ReadLine();
    if (int.TryParse(userInput, out numOfPlayer))
    {
        // declare and initialize an array of PlayerModel
        PlayerModel[] allPlayer = new PlayerModel[numOfPlayer];
        for (int i = 0; i < numOfPlayer; i++)
        {
            allPlayer[i] = new PlayerModel();
        }
        while (numOfPlayer > 0)
        {
            Console.WriteLine("Please enter information of a player in the follow form:\nName,Email");
            userInput = Console.ReadLine();
            userInfo = userInput.Split(",");
            // validate the input and store it in each PlayModel in the array.
            if (isValid(userInfo[0]))
            {
                if (isEmail(userInfo[1]))
                {
                    allPlayer[numOfPlayer - 1].Email = userInfo[1];
                    allPlayer[numOfPlayer - 1].Name = userInfo[0];
                }
                else
                {
                    numOfPlayer++;
                }
            }
            numOfPlayer--;
        }
        Console.WriteLine("Thank you");
        while (run)
        {
            Console.WriteLine("--------------------------------Main Menu---------------------------------------------");
            Console.WriteLine("Please choose an option that you want to:");
            Console.WriteLine("Enter 1 Print information of all players");
            Console.WriteLine("Enter 2 Print information of a player base on their email");
            Console.WriteLine("Enter 3 Write all user data to data.txt");
            Console.WriteLine("Enter 4 Stop");
            option = Console.ReadLine();
            Console.WriteLine($"You've entered \"{option}\"!");
            if (option == "1")
            {
                foreach (PlayerModel player in allPlayer)
                {
                    player.Print(PrintPlayerInfo, player);
                }

            }
            else if (option == "2")
            {
                Console.WriteLine("Please enter an email of a player that you want to see");
                userInput = Console.ReadLine();
                foreach (PlayerModel player in allPlayer)
                {
                    if (player.Email == userInput)
                    {
                        player.Print(PrintPlayerInfo, player);
                    }
                }

            }
            else if (option == "3")
            {
                // writting all user data to data.txt
                using (StreamWriter sw = new StreamWriter("data.txt"))
                {
                    foreach (PlayerModel player in allPlayer)
                    {
                        sw.WriteLine(player.Name + "," + player.Email + "," + player.Id);
                    }
                }
                Console.WriteLine("Done writting to a file.");
            }
            else if (option == "4")
            {
                run = false;
            }
            else
            {
                Console.WriteLine("Invalid input! please enter either 1, 2 or 3!");
            }
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("Something went wrong!");
}
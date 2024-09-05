namespace hotel;

class Program
{
    static void Main(string[] args)
    {
        displayMenu();

        Room room = promptRoomType();

        Console.WriteLine("\n-----------------------------------\n");

        int numberOfDays = promptNumberOfDays();
        bool hasRefrigerator = promptYesOrNo("Refrigerator in the room? (Y/N): ");
        bool hasExtraBed = promptYesOrNo("Extra Bed in the room? (Y/N): ");

        Console.WriteLine("\n-----------------------------------\n");

        room.calculateBill(numberOfDays);
    }

    static Room promptRoomType()
    {
        char roomType;
        Room room = new Room();

        do
        {
            Console.Write("Please select your Room Type: ");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("ERROR: Invalid input.");
                continue;
            }

            input = input.Trim().ToLower();

            if (input.Length == 1 && "gpl".Contains(input))
            {
                roomType = input[0];
                break;
            }

            Console.WriteLine("ERROR: Invalid room type.");
        } while (true);

        switch (roomType)
        {
            case 'g':
                // room = new Room("Garden Pool View", 125, 2.5, 15);
                room.setRoomName("Garden Pool View");
                room.setRoomDailyRate(125);
                room.setRefrigeratorDailyRate(2.5);
                room.setExtraBedDailyRate(15);
                break;
            case 'p':
                // room = new Room("Pool View", 145, 2.5, 15);
                room.setRoomName("Pool View");
                room.setRoomDailyRate(145);
                room.setRefrigeratorDailyRate(2.5);
                room.setExtraBedDailyRate(15);
                break;
            case 'l':
                // room = new Room("Lake View", 180, 2.5, 20);
                room.setRoomName("Lake View");
                room.setRoomDailyRate(180);
                room.setRefrigeratorDailyRate(2.5);
                room.setExtraBedDailyRate(20);
                break;
        }

        return room;
    }

    static int promptNumberOfDays()
    {
        int numberOfDays;

        do
        {
            Console.Write("Number of Days Staying: ");

            if (int.TryParse(Console.ReadLine(), out numberOfDays) && numberOfDays > 0)
            {
                break;
            }

            Console.WriteLine("FAILURE: Invalid amount.\n");
        } while (true);

        return numberOfDays;
    }

    static bool promptYesOrNo(string prompt)
    {
        do
        {
            Console.Write(prompt);

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("ERROR: Invalid input.");
                continue;
            }

            input = input.Trim().ToLower();

            switch (input)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    Console.WriteLine("ERROR: Invalid input.");
                    break;
            }
        } while (true);
    }

    static void displayMenu()
    {
        Console.WriteLine("Welcome to Easy Living Resort Hotel");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine();

        Console.WriteLine("Room Type                Daily Rate");
        Console.WriteLine("---------                ----------");
        Console.WriteLine("G - Garden Pool View     $125.00");
        Console.WriteLine("P - Pool View            $145.00");
        Console.WriteLine("L - Lake View            $180.00");
        Console.WriteLine();
    }
}

class Room
{
    string roomName = "";
    double roomDailyRate;
    double refrigeratorDailyRate;
    double extraBedDailyRate;

    public Room()
    {

    }

    public Room(string roomName, double roomDailyRate, double refrigeratorDailyRate, double extraBedDailyRate)
    {
        this.roomName = roomName;
        this.roomDailyRate = roomDailyRate;
        this.refrigeratorDailyRate = refrigeratorDailyRate;
        this.extraBedDailyRate = extraBedDailyRate;
    }

    public void calculateBill(int numberOfDays)
    {
        double roomTotalBill = this.roomDailyRate * numberOfDays;
        double refrigeratorTotalBill = this.refrigeratorDailyRate * numberOfDays;
        double extraBedTotalBill = this.extraBedDailyRate * numberOfDays;
        double totalBill = roomTotalBill + refrigeratorTotalBill + extraBedTotalBill;

        Console.WriteLine("Room Type:\n");

        Console.WriteLine("{0}     : {1:C2}", this.roomName, roomTotalBill);
        Console.WriteLine("Refrigerator  : {0:C2}", refrigeratorTotalBill);
        Console.WriteLine("Extra Bed     : {0:C2}", extraBedTotalBill);
        Console.WriteLine("Number of Days: {0}", numberOfDays);
        Console.WriteLine();
        Console.WriteLine("Your Total Bill is: {0:C2}", totalBill);
    }

    public void setRoomName(string name) {
        this.roomName = name;
    }

    public void setRoomDailyRate(double rate) {
        this.roomDailyRate = rate;
    }

    public void setRefrigeratorDailyRate(double rate) {
        this.refrigeratorDailyRate = rate;
    }

    public void setExtraBedDailyRate(double rate) {
        this.extraBedDailyRate = rate;
    }
}

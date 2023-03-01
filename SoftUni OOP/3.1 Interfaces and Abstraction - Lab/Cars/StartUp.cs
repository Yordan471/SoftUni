namespace Cars
{
    public class StartUp
    {
        public static void Main()
        {
            Tesla tesla = new("A1", "Red", 2);
            Seat seat = new("A2", "Yellow");

            Console.WriteLine(tesla);
            tesla.Start();
            tesla.Stop();

            Console.WriteLine(seat);
            seat.Start();
            seat.Stop();
        }
    }
}
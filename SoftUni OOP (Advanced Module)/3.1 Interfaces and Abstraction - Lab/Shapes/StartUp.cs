using Shapes;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Circle cirlce = new(3);
            Rectangle rec = new(4, 5);

            cirlce.Draw();
            rec.Draw();
        }
    }
}


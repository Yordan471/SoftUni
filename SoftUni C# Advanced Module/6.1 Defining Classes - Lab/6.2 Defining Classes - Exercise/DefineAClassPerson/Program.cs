using DefineAClassPerson;
using System.Runtime.CompilerServices;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            Person Peter = new("Peter", 20);
            Person George = new("George", 18);
            Person Jose = new("Jose", 43);

            Person Jordan = new();
            Jordan.Name = "Jordan";
            Jordan.Age = 16;
            
            Person Natalia = new();
            {
                Natalia.Name = "Natalia";
                Natalia.Age = 17;
            }


                
            

        }
    }
}




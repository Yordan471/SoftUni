﻿namespace Farm
{
    public class StartUp
    {
        public static void Main()
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Bark();

            Puppy puppy = new();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();

            Cat cat = new();
            cat.Eat();
            cat.Meow();
        }
    }
}
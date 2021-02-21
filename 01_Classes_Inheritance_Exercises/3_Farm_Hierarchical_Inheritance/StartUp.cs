namespace Farm
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            Dog dog = new Dog();
            Dog.Eat();
            Dog.Bark();

            Cat cat = new Cat();
            Cat.Eat();
            Cat.Meow();
        }
    }
}

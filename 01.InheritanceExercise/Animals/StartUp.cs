using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                string type = input;
                input = Console.ReadLine();
                string[] props = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = props[0];
                int age = int.Parse(props[1]);
                string gender = props[2];
                Animal animal = new Animal();
                try
                {
                    if (type == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (type == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (type == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (type == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (type == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    animals.Add(animal);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }

            foreach (Animal animal1 in animals)
            {
                Console.WriteLine(animal1);
                animal1.ProduceSound();
            }
        }
    }
}

using System;

namespace CreateClass
{
    class Program
    {

        static T CreateClass<T>() where T : new()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
        static void Main(string[] args)
        {
            Person a = CreateClass<Person>();
            Person b = CreateClass<Teacher>();
            Animal c = CreateClass<Animal>();

            Console.WriteLine("Hello World!");
        }
    }

    class Person
    {

    }
    class Teacher:Person
    {

    }
    class Animal
    { }

}

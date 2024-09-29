/*
 This exercise is meant to help understand about how to work with classes and its various characteristics.
 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace classExampleProgram
{
    abstract class Vehicle
    {
        public abstract string Describe();
    }

    class Car:Vehicle
    {
        //Property that holds the characteristics of the car class. 
        private string color;
        private string name;
        private string description;
        private double horsepower;

        //making fields publicly available for manipulation
        public string Color { get => this.color; set => this.color = value; }
        public string Name{ get=> this.name; set=>this.name= value;}
        public string Description { get => this.description; set => this.description = value; }
        public double Horsepower { get => this.horsepower; set => this.horsepower= value; }

        //define the constructor for the Car class 
        public Car(string color, string name, string description, double horsepower)
        {
            Color = color;
            Name = name;
            Description = description;
            Horsepower = horsepower;
        }

        public override string Describe()
        {   
            return $@"

                This is a {Name}. 
                It is {Color} in color and has atleast {Horsepower} horsepower. 

                The car is described as a {Description}";
        }

    }
    class mainProgram
    {
        //start of the main function where the program runs. 

        static void Main(string[] args)
        {
            // Declare a variable of type Car--this is the class that defines what a car will look like. 

            Car porshe;
            Car lambo;

            // Creates an new instance
            //(string color, string name, string description, double horsepower)
            porshe = new Car("Red", "Porshe", "a fast italian car", 500);

            // New instance gives us method access
            Console.WriteLine(porshe.Describe());

            lambo = new Car("Green", "lambo", "another fast Italian car", 685);
            Console.WriteLine(lambo.Describe());

            Console.ReadLine();

        }
    }





}


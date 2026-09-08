
using OOP_04;
using OOP04;
using System.Reflection.Metadata;

namespace OOP04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OOP 05 - Smart Delivery Management System 
            #region Part 01 : Theoretical Questions


            #region Q1 Object Copying
            //a) What happens when you assign one object variable to another object variable?
            // we are copying the reference of the object, not the actual object itself.Both variables will point to the same object in memory.

            //b) Does assigning one object to another create a new object? Explain.
            // No, assigning one object to another does not create a new object. It copies the reference of the existing object to the new variable.
            // the two variables will refer to the same object in memory, so changes made through one variable will affect the other.

            //c) What is the difference between copying an object and copying its reference?
            // copying an object creates a new instance of the object with the same values, while copying its reference only copies the memory address of the existing object.

            #endregion

            #region Q2 Shallow Copy vs Deep Copy
            //a) What is a Shallow Copy?
            // Shallow copy creates a new object which is a copy of the original object, but it only copies the values of the original object's fields.

            //b) What is a Deep Copy?
            // Deep copy creates a new object which is a copy of the original object, and it also creates copies of all the objects referenced by the original object.

            //c) What happens to reference-type members when a Shallow Copy is created?
            // it copies the references of the reference-type members, so both the original and copied objects will point to the same reference-type members in memory.

            //d) What happens to reference-type members when a Deep Copy is created?
            // it creates new instances of the reference-type members, so the original and copied objects will have their own separate copies of the reference-type members in memory.

            //e) Give one situation where Deep Copy would be safer than Shallow Copy.
            // When you have an object that contains reference-type members that can be modified, and you want to ensure that changes made to the copied object do not affect the original object.
            #endregion

            #region Q3 Static Members
            //a) What is a static field, and how is it different from an instance field ?
            // a static field belongs to the class itself, while an instance field belongs to an object of the class.

            //b) What is a static method? Can a static method directly access instance members?
            // it's a method that belongs to the class . It can be called without creating an object of the class

            //c) What is a static constructor, and when is it executed ?
            // A static constructor is a special constructor that is used to initialize static members of a class. It is executed only once, when the class is first accessed or loaded into memory.

            //d) What is a static class? Can you create an object from a static class?
            // A static class is a class that cannot be instantiated. You cannot create an object from a static class.

            #endregion

            #region Q4 Extension Methods
            //a) What is an Extension Method?
            // it's a special kind of static method that allows you to add new methods to an existing class without modifying the original class or creating a new derived class.

            //b) What keyword must be used in the first parameter of an extension method?
            // "this" keyword , followed by the type that the method is extending. 

            //c) Where must an extension method be declared?
            // An extension method must be declared in a static class.

            //d) Can an extension method access private members of the class it extends?
            // No, an ti can't access private members of the class it extends.

            #endregion

            #region Q5 Partial Classes and Partial Methods
            //a) What is a Partial Class?
            // A partial class is a class that can be split into multiple files, to let many developers to work on the same class or to organize code in a more manageable way.

            //b) Why would a developer split one class into multiple files?
            // to improve code organization, maintainability and It allows different developers to work on different parts of the class  without causing conflicts.

            //c) What is a Partial Method?
            // A partial method is a method that is declared in one part of a partial class or struct, but its implementation can be provided in another part of the same class or struct.

            //d) What happens if a declared partial method has no implementation?
            // The compiler will remove the method declaration and any calls to it from the compiled code. This means that the method will not be included in the final assembly, and any calls to it will be ignored.

            #endregion

            #endregion



            #region part02 ass05

            try
            {
                    DeliveryUtilities.PrintSystemTitle("Smart Delivery Management System");
                    Console.WriteLine();

                    DeliveryUtilities.PrintSystemTitle("Creating Shipments...");
                    Console.WriteLine();

                    StandardShipment standard = new StandardShipment(
                        "SH001", "Laptop", 3, 80, new DeliveryAddress("Cairo", "Tahrir Street", 15));
                    Console.WriteLine("Standard Shipment Created");

                    ExpressShipment express = new ExpressShipment(
                        "SH002", "Mobile Phone", 2, 60, new DeliveryAddress("Giza", "Al Haram", 8), 30);
                    Console.WriteLine("Express Shipment Created");

                    InternationalShipment international = new InternationalShipment(
                        "SH003", "Television", 8, 120, new DeliveryAddress("Alexandria", "Corniche", 20),
                        "Germany", 100);
                    Console.WriteLine("International Shipment Created");
                    Console.WriteLine();

                    Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
                    Console.WriteLine();

                    DeliveryUtilities.PrintSystemTitle("Object Copying");
                    Console.WriteLine();

                    Shipment assignedShipment = standard;
                    Console.WriteLine($"Original Shipment : {standard.TrackingCode}");
                    Console.WriteLine($"Assigned Shipment : {assignedShipment.TrackingCode}");
                    Console.WriteLine();
                    Console.WriteLine($"Same Object : {ReferenceEquals(standard, assignedShipment)}");
                    Console.WriteLine();

                    Shipment copiedShipment = standard.CopyShipment();
                    Console.WriteLine($"Same Object (After CopyShipment) : {ReferenceEquals(standard, copiedShipment)}");
                    Console.WriteLine();

                    Console.WriteLine(new string('-', 42));
                    Console.WriteLine("Shallow Copy");
                    Console.WriteLine(new string('-', 42));
                    Console.WriteLine();

                    Shipment shallow = standard.ShallowCopy();
                    Console.WriteLine($"Original Shipment Address : {standard.Destination.City}");
                    Console.WriteLine($"Copied Shipment Address   : {shallow.Destination.City}");
                    Console.WriteLine();
                    Console.WriteLine("Changing copied shipment address...");
                    Console.WriteLine();
                    shallow.Destination.City = "Giza";
                    Console.WriteLine($"Original Shipment Address : {standard.Destination.City}");
                    Console.WriteLine($"Copied Shipment Address   : {shallow.Destination.City}");
                    Console.WriteLine();
                    Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(standard.Destination, shallow.Destination)}");
                    Console.WriteLine();

                    standard.Destination.City = "Cairo";

                    Console.WriteLine(new string('-', 42));
                    Console.WriteLine("Deep Copy");
                    Console.WriteLine(new string('-', 42));
                    Console.WriteLine();

                    Shipment deep = standard.DeepCopy();
                    Console.WriteLine($"Original Shipment Address : {standard.Destination.City}");
                    Console.WriteLine($"Copied Shipment Address   : {deep.Destination.City}");
                    Console.WriteLine();
                    Console.WriteLine("Changing copied shipment address...");
                    Console.WriteLine();
                    deep.Destination.City = "Giza";
                    Console.WriteLine($"Original Shipment Address : {standard.Destination.City}");
                    Console.WriteLine($"Copied Shipment Address   : {deep.Destination.City}");
                    Console.WriteLine();
                    Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(standard.Destination, deep.Destination)}");
                    Console.WriteLine();

                    DeliveryUtilities.PrintSystemTitle("Extension Methods");
                    Console.WriteLine();

                    Console.WriteLine(standard.GetSummary());
                    Console.WriteLine(express.GetSummary());
                    Console.WriteLine(international.GetSummary());
                    Console.WriteLine();

                    Console.WriteLine($"{standard.TrackingCode} Is Delivered : {standard.IsDelivered()}");
                    Console.WriteLine($"{international.TrackingCode} Is Delivered : {international.IsDelivered()}");
                    Console.WriteLine();

                    DeliveryUtilities.PrintSystemTitle("Tracking Status");
                    Console.WriteLine();

                    standard.UpdateTrackingStatus("Out For Delivery");
                    Console.WriteLine();

                    DeliveryUtilities.PrintSystemTitle("Static Utilities");
                    Console.WriteLine();

                    DeliveryUtilities.PrintSystemTitle("Delivery Center");
                    Console.WriteLine();
                    Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
                    Console.WriteLine();

                    DeliveryUtilities.PrintSystemTitle("Partial Method");
                    Console.WriteLine();

                    standard.UpdateTrackingStatus("Delivered");
                    Console.WriteLine();

                    DeliveryUtilities.PrintSystemTitle("Assignment Completed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("!!! An error occurred !!!");
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        
            #endregion
    }
}
    

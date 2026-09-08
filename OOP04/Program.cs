
using OOP04;

namespace OOP04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OOP 03 - Smart Delivery Management System 
            #region Part 01 : Theoretical Questions

            #region Q1  Overloading, Overriding, and Binding
            //a)  What is the difference between Method Overloading and Method Overriding?
            //overloading is a compile-time polymorphism where multiple methods have the same name but different parameters (type, number, or order).
            //Overriding is a run-time polymorphism where a derived class provides a specific implementation of a method that is already defined in its base class.

            //b)  What is the difference between Static Binding and Dynamic Binding?
            //Static binding  occurs at compile time, where the method to be called is determined based on the reference type.

            //Dynamic binding  occurs at runtime, where the method to be called is determined based on the actual object type.

            #endregion

            #region //Q2 Sealed Classes and Methods
            //a)  What is the purpose of the sealed keyword when applied to a class?
            //The sealed keyword is used to prevent a class from being inherited. When a class is marked as sealed, it cannot serve as a base class for any other class
            //b)  What is the difference between a sealed class and a sealed method?
            //A sealed class is a class that cannot be inherited, while a sealed method is a method that cannot be overridden in derived classes. A sealed class prevents any further inheritance, while a sealed method allows inheritance of the class but restricts overriding of that specific method.
            //c)  Can a sealed method be overridden? Why?
            //No, a sealed method cannot be overridden. When a method is marked as sealed, it indicates that the method has been finalized and cannot be further overridden in derived classes         
           
            #endregion


            #endregion



            #region part02 ass03
            try
            {
                //  Create a Driver

                Console.Write("Enter Driver Name: ");
                Driver driver = new Driver(Console.ReadLine());

                //  Create a DeliveryCenter
                DeliveryCenter center = new DeliveryCenter();

                Console.Write("Enter Delivery Center Name: ");
                center.CenterName = Console.ReadLine();

                //  Assign the Driver to the DeliveryCenter
                center.AssignedDriver = driver;
                Console.WriteLine();

                //  Create one StandardShipment
                Console.WriteLine("--- Standard Shipment Data ---");
                StandardShipment standard = ReadStandardShipment();
                Console.WriteLine();

                //  Create one ExpressShipment
                Console.WriteLine("--- Express Shipment Data ---");
                ExpressShipment express = ReadExpressShipment();
                Console.WriteLine();

                // Create one InternationalShipment
                Console.WriteLine("--- International Shipment Data ---");
                InternationalShipment international = ReadInternationalShipment();
                Console.WriteLine();

                //  Add all shipments to the DeliveryCenter
                center.AddShipment(standard);
                center.AddShipment(express);
                center.AddShipment(international);

                //  Print all shipments using PrintAllShipments()
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("Delivery Center");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();
                center.PrintAllShipments();

                //  Call DeliveryHelper.PrintShipmentDetails() for each shipment
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("Printing Using DeliveryHelper...");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();
                DeliveryHelper.PrintShipmentDetails(standard);
                DeliveryHelper.PrintShipmentDetails(express);
                DeliveryHelper.PrintShipmentDetails(international);

                //  Demonstrate both versions of UpdateWeight()
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("Updating Weight...");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();
                Console.WriteLine($"Original Weight : {standard.Weight} KG");

                standard.UpdateWeight(5);                
                Console.WriteLine($"Updated Weight : {standard.Weight} KG");

                standard.UpdateWeight(5, 0.5m);            
                Console.WriteLine($"Updated Weight After Packing : {standard.Weight} KG");
                Console.WriteLine();

                //  Build a Shipment[] holding mixed types and print all in a loop
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("Printing Using Shipment[]...");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();

                Shipment[] mixedShipments = { standard, express, international };
                foreach (Shipment s in mixedShipments)
                {
                    Console.WriteLine($"{s.ShipmentTypeName}...");
                    s.PrintShipment();
                    Console.WriteLine();
                }

                //  Demonstrate the sealed class and sealed method
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("Sealed Class & Sealed Method Demo");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();

              
                CompletedShipment completed = new CompletedShipment(
                    "SH999", "Finished Order", 4, 70, new DeliveryAddress("Giza", "Al Haram", 12));
                Console.WriteLine("Completed Shipment created successfully (sealed class):");
                completed.PrintShipment();
                Console.WriteLine();

             
                PriorityInternationalShipment priority = new PriorityInternationalShipment(
                    "SH777", "Urgent Documents", 1, 90, new DeliveryAddress("Cairo", "Zamalek", 3),
                    "France", 50);
                priority.GenerateCustomsReport();
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

       
        static DeliveryAddress ReadAddress()
        {
            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("Street: ");
            string street = Console.ReadLine();

            Console.Write("Building Number: ");
            int buildingNumber = int.Parse(Console.ReadLine());

            return new DeliveryAddress(city, street, buildingNumber);
        }

        static StandardShipment ReadStandardShipment()
        {
            Console.Write("Tracking Code: ");
            string trackingCode = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Weight: ");
            decimal weight = decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal deliveryFee = decimal.Parse(Console.ReadLine());

            DeliveryAddress address = ReadAddress();

            return new StandardShipment(trackingCode, description, weight, deliveryFee, address);
        }

        static ExpressShipment ReadExpressShipment()
        {
            Console.Write("Tracking Code: ");
            string trackingCode = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Weight: ");
            decimal weight = decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal deliveryFee = decimal.Parse(Console.ReadLine());

            DeliveryAddress address = ReadAddress();

            Console.Write("Extra Fee: ");
            decimal extraFee = decimal.Parse(Console.ReadLine());

            return new ExpressShipment(trackingCode, description, weight, deliveryFee, address, extraFee);
        }

        static InternationalShipment ReadInternationalShipment()
        {
            Console.Write("Tracking Code: ");
            string trackingCode = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Weight: ");
            decimal weight = decimal.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal deliveryFee = decimal.Parse(Console.ReadLine());

            DeliveryAddress address = ReadAddress();

            Console.Write("Destination Country: ");
            string destinationCountry = Console.ReadLine();

            Console.Write("Customs Fee: ");
            decimal customsFee = decimal.Parse(Console.ReadLine());

            return new InternationalShipment(trackingCode, description, weight, deliveryFee, address,
                                              destinationCountry, customsFee);
        }
    }
            #endregion
}
    

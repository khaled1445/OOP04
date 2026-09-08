
using OOP_04;
using OOP04;

namespace OOP04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OOP 03 - Smart Delivery Management System 
            #region Part 01 : Theoretical Questions

            #region Q1  Abstraction
            //a)  What is Abstraction in Object - Oriented Programming?
            //it's a way to hide the implementation details of a class and only expose the essential features to the user.
            //It allows the user to interact with an object without needing to understand its internal workings.

            //b)  Why is abstraction considered one of the four pillars of OOP?
            // because it allows for the creation of abstract classes and interfaces,
            // which can be used to define common behavior for a group of related classes, This promotes code reusability and maintainability

            #endregion

            #region Q2  Abstract Classes vs.Interfaces
            //a)  What is the difference between an Abstract Class and an Interface?
            // abstract class can have both abstract and concrete methods, while an interface can only have abstract methods.

            //b)  When would you choose an Interface instead of an Abstract Class?
            // when you want to define a contract that multiple classes can implement, without seeing their inheritance hierarchy.

            //c)  Can a class inherit from multiple abstract classes? Can it implement multiple interfaces?
            // No, a class can only inherit from one abstract class, but it can implement multiple interfaces.
            
            #endregion


            #endregion



            #region part02 ass04
            try
            {
                DeliveryCenter center = new DeliveryCenter();

                Console.Write("Enter Delivery Center Name: ");
                center.CenterName = Console.ReadLine();
                Console.WriteLine();

                // Create one StandardShipment
                Console.WriteLine("--- Standard Shipment Data ---");
                StandardShipment standard = ReadStandardShipment();
                Console.WriteLine();

                // Create one ExpressShipment
                Console.WriteLine("--- Express Shipment Data ---");
                ExpressShipment express = ReadExpressShipment();
                Console.WriteLine();

                // Create one InternationalShipment
                Console.WriteLine("--- International Shipment Data ---");
                InternationalShipment international = ReadInternationalShipment();
                Console.WriteLine();

                // Add all shipments to the DeliveryCenter
                center.AddShipment(standard);
                center.AddShipment(express);
                center.AddShipment(international);

                // Print all shipment details
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("Delivery Center");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();
                center.PrintAllShipments();

                //  Print the tracking status of every shipment
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("Tracking Status");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();
                center.PrintTrackingStatuses();
                Console.WriteLine();

                // Print the insurance cost of every shipment
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("Insurance");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();
                Console.Write($"{standard.ShipmentTypeName} Insurance : ");
                DeliveryReport.PrintInsurance(standard);
                Console.Write($"{express.ShipmentTypeName} Insurance : ");
                DeliveryReport.PrintInsurance(express);
                Console.Write($"{international.ShipmentTypeName} Insurance : ");
                DeliveryReport.PrintInsurance(international);
                Console.WriteLine();

                // Store the shipment objects in an ITrackable[] array and print statuses
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("ITrackable[] Demo");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();
                ITrackable[] trackables = { standard, express, international };
                foreach (ITrackable t in trackables)
                {
                    Console.WriteLine(t.GetTrackingStatus()); // dynamic binding through the interface
                }
                Console.WriteLine();

                //  Store the shipment objects in an IInsurable[] array and print insurance values
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine("IInsurable[] Demo");
                Console.WriteLine("=".PadRight(42, '='));
                Console.WriteLine();
                IInsurable[] insurables = { standard, express, international };
                foreach (IInsurable i in insurables)
                {
                    Console.WriteLine($"Insurance : {i.CalculateInsurance():0.00} EGP");
                }
                Console.WriteLine();

                Console.WriteLine("Interface Polymorphism Demonstrated Successfully.");
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
            #endregion
    }
}
    

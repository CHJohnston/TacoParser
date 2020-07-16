using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            logger.LogInfo("Read .csv a file containing Taco Bell Locations and Determine the two with the Max Distance.");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"The .csv file is converted to an array called Lines:");
            logger.LogInfo($"Lines first entry: {lines[0]}");

            var parser = new TacoParser();

            logger.LogInfo($"The Taco Bell Parser reads the cells in the Lines array.");
            
            var locations = lines.Select(parser.Parse).ToArray();
            logger.LogInfo($"The cells in the Lines array have been converted to the ITrackable locations array.");

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops
            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line

            // Create a new instance of your TacoParser class
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);

            // Now, here's the new code

            // Done - Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            // Done - Create a `double` variable to store the distance
            ITrackable locA = null;
            ITrackable locB = null;
            double distance = 0;

            //This will be the two points that are the greatest distance apart
            ITrackable p1 = null;
            ITrackable p2 = null;
            double maxDistance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // Create a new corA Coordinate with your locA's lat and long
            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // Create a new Coordinate with your locB's lat and long
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            logger.LogInfo($"Calculating the Distance between all locations....");

            for (int i = 0; i < locations.Length; i++ )
                {
                    locA = locations[i];
                    GeoCoordinate CordA = new GeoCoordinate();
                    CordA.Latitude = locA.Location.Latitude;
                    CordA.Longitude = locA.Location.Longitude;
                    for (int j = i; j < locations.Length; j++) 
                    {
                        locB = locations[j];
                        GeoCoordinate CordB = new GeoCoordinate();
                        CordB.Latitude = locB.Location.Latitude;
                        CordB.Longitude = locB.Location.Longitude;
                        distance = CordA.GetDistanceTo(CordB);
                        if (distance > maxDistance) 
                        {
                            p1 = locA;
                            p2 = locB;
                            maxDistance = distance;
                        }
                    }
                }

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
            double inMiles = 0.000621371 * maxDistance;
            double inMilesRounded = Math.Ceiling(inMiles);            
            logger.LogInfo("Here are the two locations with the Max Distance:");
            logger.LogInfo($"Location A {p1.Name} Location B {p2.Name}  Distance {inMilesRounded}" );           
        }
    }
}
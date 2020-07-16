using System;
using System.Globalization;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");
            //logger.LogInfo(line);

            // Do not fail if one record parsing fails, return null
            // TODO Implement
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','

            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length != 3 || cells == null)
            {
                logger.LogError("Parse Method Failed");
                return null;
            }

            // grab the latitude from your array at index 0
            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            double latitude = 0;            
            latitude = Double.Parse(cells[0]);

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            // grab the longitude from your array at index 1           
            double longitude = Double.Parse(cells[1]);

            // grab the name from your array at index 2
            string name = cells[2];

            // DONE - You'll need to create a TacoBell class
            //        that conforms to ITrackable


            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            var location = new Point()
            {
                Latitude = latitude,
                Longitude = longitude
            };
            TacoBell tacoBell = new TacoBell()
            {
                Name = name,
                Location = location
            };

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;
        }
    }
}
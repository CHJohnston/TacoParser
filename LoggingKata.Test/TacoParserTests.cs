using System;
using System.Collections.Generic;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
            //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse("34,88,Taco Bell Atmore");

            //Assert
            Assert.NotNull(actual);            
          
        }

        [Theory]
        [InlineData("34.073638, -84.677017,Taco Bell Acwort...", 34.073638, -84.677017, "Taco Bell Acwort...")]
        [InlineData("33.544403, -85.073656,Taco Bell Carrollton...", 33.544403, -85.073656, "Taco Bell Carrollton...")]
        [InlineData("33.205302, -87.569628,Taco Bell Tuscaloos...", 33.205302, -87.569628, "Taco Bell Tuscaloos...")]
        [InlineData("34.649837,-86.034065,Taco Bell Scottsbor...",34.649837, -86.034065, "Taco Bell Scottsbor...")]

        public void ShouldParse(string str, double lat,double log, string expected)
        {  
            // TODO: Complete Should Parse
            //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse(str);

            //Assert
            Assert.Equal(expected, actual.Name);
            Assert.Equal(lat, actual.Location.Latitude);
            Assert.Equal(log, actual.Location.Longitude);
        }

        [Theory]
        //[InlineData(null)]
        [InlineData("")]
        [InlineData("34.649837, -86.034065, Taco Bell Scottsbor..., Taco Bell")]
        [InlineData("34.649837,  Taco Bell Scottsbor... ")]
        public void ShouldFailParse(string str)
        { // TODO: Complete Should Fail Parse
          //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse(str);

            //Assert
            Assert.Equal(null, actual);
        }
    }
}

using System;
using System.IO;
using CryptoCurrency.Models;
using CryptoCurrency.Models.Enums;
using CryptoCurrency.Services;
using Xunit;

namespace CryptoCurrencyTests
{
    public class ProgramTests
    {
        [Fact]
        public void TestProcessOrders1()
        {
            // Arrange
            var orderBookService = new OrderBookService();

            var input = "1 1\nFirstCoin\n5\n" +
                        "1003 ADD c buy FirstCoin 4410 100\n" +
                        "1008 ADD d buy FirstCoin 4418 157\n" +
                        "1009 ADD e sell FirstCoin 4438 120\n" +
                        "1010 REM d 80\n" +
                        "1015 ADD g sell FirstCoin 4427 100\n";

            // Create a StringWriter to capture the program's output
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Program.ProcessOrders(new StringReader(input));

            // Assert
            var expectedOutput = "1003 sell FirstCoin 4410.00\n" +
                                 "1008 sell FirstCoin 4418.00\n" +
                                 "1009 buy FirstCoin 4438.00\n" +
                                 "1015 buy FirstCoin 4427.00\n";

            Assert.Equal(expectedOutput, sw.ToString());
        }
    }
}
using System;
using System.IO;
using CryptoCurrency.Models;
using CryptoCurrency.Models.Enums;
using CryptoCurrency.Services;
using Xunit;

namespace CryptoCurrency.Tests
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
        
        [Fact]
        public void TestProcessOrders2()
        {
            // Arrange
            var orderBookService = new OrderBookService();

            var input = "200 1\nFirstCoin\n5\n" +
                        "1003 ADD c buy FirstCoin 44.10 100\n" +
                        "1008 ADD d buy FirstCoin 44.18 157\n" +
                        "1009 ADD e sell FirstCoin 44.38 120\n" +
                        "1010 REM d 80\n" +
                        "1015 ADD g sell FirstCoin 44.27 100\n";

            // Create a StringWriter to capture the program's output
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Program.ProcessOrders(new StringReader(input));

            // Assert
            var expectedOutput = "1008 sell FirstCoin 8832.56\n" +
                                 "1010 sell FirstCoin NA\n" +
                                 "1015 buy FirstCoin 8865.00\n";

            Assert.Equal(expectedOutput, sw.ToString());
        }
        
        [Fact]
        public void TestProcessOrders3()
        {
            // Arrange
            var orderBookService = new OrderBookService();

            var input = "150 1\nFirstCoin\n5\n" +
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
            var expectedOutput = "1008 sell FirstCoin 662700.00\n" +
                                 "1010 sell FirstCoin 662116.00\n" +
                                 "1015 buy FirstCoin 664600.00\n";

            Assert.Equal(expectedOutput, sw.ToString());
        }

        [Fact]
        public void TestProcessOrders4()
        {
            // Arrange
            var orderBookService = new OrderBookService();

            var input = "10 1\ncoin_00\n11\n" +
                        "10000 ADD order_001 sell coin_00 15009 8\n" +
                        "10001 ADD order_002 buy coin_00 16057 5\n" +
                        "10002 ADD order_003 sell coin_00 15024 8\n" +
                        "10003 ADD order_004 buy coin_00 16125 9\n" +
                        "10004 ADD order_005 sell coin_00 15074 6\n" +
                        "10005 REM order_001 8\n" +
                        "10006 ADD order_006 sell coin_00 15076 7\n" +
                        "10007 REM order_005 6\n" +
                        "10008 ADD order_007 buy coin_00 16184 7\n" +
                        "10009 ADD order_008 sell coin_00 15141 7\n" +
                        "10010 REM order_004 9\n";

            // Create a StringWriter to capture the program's output
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Program.ProcessOrders(new StringReader(input));

            // Assert
            var expectedOutput = "10002 buy coin_00 150120.00\n" +
                                 "10003 sell coin_00 161182.00\n" +
                                 "10005 buy coin_00 150340.00\n" +
                                 "10007 buy coin_00 150344.00\n" +
                                 "10008 sell coin_00 161663.00\n" +
                                 "10010 sell coin_00 161459.00\n";

            Assert.Equal(expectedOutput, sw.ToString());
        }
        
        [Fact]
        public void TestProcessOrders5()
        {
            // Arrange
            var orderBookService = new OrderBookService();

            var input = "10 1\ncoin_00\n11\n" +
                        "10000 ADD order_001 sell coin_00 14991 8\n" +
                        "10001 ADD order_002 buy coin_00 15994 9\n" +
                        "10002 ADD order_003 sell coin_00 14906 8\n" +
                        "10003 ADD order_004 sell coin_00 14829 5\n" +
                        "10004 REM order_001 8\n" +
                        "10005 ADD order_005 sell coin_00 14740 7\n" +
                        "10006 ADD order_006 buy coin_00 15974 8\n" +
                        "10007 ADD order_007 buy coin_00 15946 6\n" +
                        "10008 REM order_004 5\n" +
                        "10009 REM order_002 9\n" +
                        "10010 ADD order_008 buy coin_00 15884 9\n";

            // Create a StringWriter to capture the program's output
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            Program.ProcessOrders(new StringReader(input));

            // Assert
            var expectedOutput = "10002 buy coin_00 149230.00\n" +
                                 "10003 buy coin_00 148675.00\n" +
                                 "10005 buy coin_00 147667.00\n" +
                                 "10006 sell coin_00 159920.00\n" +
                                 "10008 buy coin_00 147898.00\n" +
                                 "10009 sell coin_00 159684.00\n";

            Assert.Equal(expectedOutput, sw.ToString());
        }

    }
}
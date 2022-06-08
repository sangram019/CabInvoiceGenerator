using CabInvoiceGenerator;
using CabInVoiceGeneratorProblem;
using NUnit.Framework;

namespace InvoiceTester
{
    public class Tests
    {
        [Test]
        public void InputInInteger_ShouldReturn_SingleRides_TotalFare()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL);
            double actual = invoice.CalculateFare(6, 5);
            Assert.AreEqual(actual, 65);
        }

        [Test]
        public void InputInInteger_ShouldReturn_MultipleRides_TotalFare()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2, 3), new Ride(4, 5) };
            double result = invoice.CalculateMultipleRides(rides);
            Assert.AreEqual(result, 23, 45);
        }

        [Test]
        public void InputInInteger_ShouldReturn_MultipleRides_TotalFair_InvoiceSummary()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 3), new Ride(4, 5), new Ride(5, 6) };
            InvoiceSummary result = invoice.MultipleRides(rides);
            Assert.AreEqual(result.totalNumberOfRides, rides.Length);
        }
    }
}
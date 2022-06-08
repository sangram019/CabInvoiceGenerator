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

    }
}
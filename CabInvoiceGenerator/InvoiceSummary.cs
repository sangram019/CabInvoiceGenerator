using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int totalNumberOfRides;
        public double totalFare;
        public double AvgFairPerRide;
        public InvoiceSummary(int totalNumberOfRides, double totalFare)
        {
            this.totalNumberOfRides = totalNumberOfRides;
            this.totalFare = totalFare;
            this.AvgFairPerRide = this.totalFare / this.totalNumberOfRides;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) ; return false;
            if (!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputesObject = (InvoiceSummary)obj;
            return this.totalNumberOfRides == inputesObject.totalNumberOfRides && this.totalFare == inputesObject.AvgFairPerRide && this.AvgFairPerRide == inputesObject.AvgFairPerRide;
        }
        public override int GetHashCode()
        {
            return this.totalNumberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.AvgFairPerRide.GetHashCode();
        }
    }
}
using CabInVoiceGeneratorProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, Ride[]> rideDict = new Dictionary<string, Ride[]>();
        public RideRepository()
        {
            this.rideDict = new Dictionary<string, Ride[]>();
        }
        public void Addrides(string userId, Ride[] rides)
        {
            try
            {
                if (!rideDict.ContainsKey(userId))
                {
                    rideDict.Add(userId, rides);
                }
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
            }
        }
        public Ride[] GetRide(string userId)
        {
            try
            {
                foreach (var data in rideDict)
                {
                    if (data.Key == userId)
                    {
                        return data.Value;
                    }
                }
                return null;
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "User id is Invalid");
            }
        }
    }
}
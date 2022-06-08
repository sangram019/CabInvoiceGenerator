using CabInvoiceGenerator;
using CabInVoiceGeneratorProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInVoiceGeneratorProblem
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private readonly int MIN_FARE = 5;
        private readonly int FARE_PER_KM = 10;
        private readonly int FARE_PER_MIN = 1;
        RideRepository repo = new RideRepository();
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            try
            {
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MIN_FARE = 5;
                    this.FARE_PER_KM = 10;
                    this.FARE_PER_MIN = 1;
                }
                else if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MIN_FARE = 20;
                    this.FARE_PER_KM = 15;
                    this.FARE_PER_MIN = 2;
                }
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride");
            }
        }
        public double CalculateFare(int distance, int time)
        {
            double CalculateFare = 0;
            try
            {
                CalculateFare = FARE_PER_KM * distance + time * FARE_PER_MIN;
            }
            catch (InvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride");
                }
                if (distance == 0)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Please Tell me Valid Distance");
                }
                if (time < 0)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Time is invalid");
                }
            }
            return Math.Max(CalculateFare, MIN_FARE);
        }
        public double CalculateMultipleRides(Ride[] rides)
        {
            double result = 0;
            try
            {
                foreach (var data in rides)
                {
                    result += CalculateFare((int)data.distance, (int)data.time);
                }
            }
            catch (InvoiceException)
            {
                if (rides == null)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return result / rides.Length;

        }
        public InvoiceSummary MultipleRides(Ride[] rides)
        {
            double result = 0;
            try
            {
                foreach (var data in rides)
                {
                    result += CalculateFare((int)data.distance, (int)data.time);
                }
            }
            catch (InvoiceException)
            {
                if (rides == null)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return new InvoiceSummary(rides.Length, result);
        }
        public void MapUserId(string userId, Ride[] rides)
        {
            this.repo.Addrides(userId, rides);
        }
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            Ride[] result = this.repo.GetRide(userId);
            return MultipleRides(result);
        }
        public InvoiceSummary InvoiceSummaryForPremiumRides(Ride[] rides)
        {
            double result = 0;
            try
            {
                foreach (var data in rides)
                {
                    result = CalculateFare((int)data.distance, (int)data.time);
                }
            }
            catch (InvoiceException)
            {
                if (rides == null)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return new InvoiceSummary(rides.Length, result);
        }
    }
}
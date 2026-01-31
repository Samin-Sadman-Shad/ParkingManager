using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerDomain.Enums
{
    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        DebitCard,
        MobilePayment,
        Other
    }

    public enum MobilePaymentMethod
    {
        BKash,
        Nagad,
        GPay
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public enum EnlistedVehicles
    {
        Sedan,
        SUVs,
        Seven_Seaters,
        Nine_Seaters,
        Bike,
        Truck,
        Bus,
        Other
    }

    public enum CarType
    {
        Petrol,
        Diesel,
        Electric,
        Hybrid,
        Other
    }

    public enum CarLevel
    {
        Regualar,
        Large,
        Premium,
        LowCost
    }

    public enum BookingStatus
    {
        Reserved,       // Booked but not yet checked in
        Active,         // Currently parked
        Completed,      // Successfully finished
        Cancelled,      // Cancelled by user or system
        NoShow,         // User didn't show up
        Expired         // Booking time passed without check-in
    }

    public enum SessionStatus
    {
        CheckedIn,      // Vehicle entered, currently parked
        CheckedOut,     // Vehicle exited, session completed
        Overstayed,     // Exceeded booked EndTime
        Abandoned       // Vehicle not retrieved after extended period
    }
}

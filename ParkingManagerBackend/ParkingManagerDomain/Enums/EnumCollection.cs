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
}

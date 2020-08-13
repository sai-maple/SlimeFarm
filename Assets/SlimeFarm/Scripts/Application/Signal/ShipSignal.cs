using System.Numerics;

namespace SlimeFarm.Scripts.Application.Signal
{
    public class ShipSignal
    {
        public BigInteger ShipMoney { get; }

        public ShipSignal(BigInteger shipMoney)
        {
            ShipMoney = shipMoney;
        }
    }
}
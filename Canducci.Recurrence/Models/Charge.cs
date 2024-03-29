﻿using Canducci.Recurrence.Extensions;
namespace Canducci.Recurrence.Models
{
    public sealed class Charge
    {
        public Charge(int chargeId, string status, int total, int parcel)
        {
            ChargeId = chargeId;
            Status = status;
            Total = total;
            Parcel = parcel;
        }
        public int ChargeId { get; }
        public string Status { get; }
        public int Total { get; set; }
        public decimal Valor { get { return Total.ToDivise(); } }
        public int Parcel { get; }
    }
}

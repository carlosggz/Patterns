using System;

namespace Observer
{
    public class LasMinuteFlight
    {
        public string FlightName { get; set; }
        public float NewPrice { get; set; }

        public override string ToString()
        {
            return $"Flight {FlightName} has a new price of {NewPrice.ToString("0.00")}";
        }
    }

    public class LastArrivalFlightSubject : Subject
    {
        private LasMinuteFlight _lastOffer;

        public LasMinuteFlight LastFlightOffer
        {
            get
            {
                return _lastOffer;
            }
            set
            {
                _lastOffer = value;
                Notify(new ObserverEventArgs() { PropertyName = nameof(LastFlightOffer), NewValue = value });
            }
        }
    }
}

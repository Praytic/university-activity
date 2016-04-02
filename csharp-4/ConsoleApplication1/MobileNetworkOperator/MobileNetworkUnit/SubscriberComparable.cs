using System;

namespace ConsoleApplication1.MobileNetworkOperator.MobileNetworkUnit {
    public class SubscriberComparable : Subscriber, IComparable<Subscriber>, IComparable {

        public SubscriberComparable(Subscriber subscriber) : base(subscriber.PhoneNumber, subscriber.Name, subscriber.Rate) {
            FieldComparer = SubscriberComparer.Default;
        }

        public SubscriberComparable(Subscriber subscriber, SubscriberComparer comparer) : base (subscriber.PhoneNumber, subscriber.Name, subscriber.Rate)
        {
            FieldComparer = comparer;
        }

        public SubscriberComparable(string phoneNumber, string name, string rate) : base(phoneNumber, name, rate) {
            FieldComparer = SubscriberComparer.Default;
        }

        public SubscriberComparable(string phoneNumber, string name, string rate, SubscriberComparer comparer) : base(phoneNumber, name, rate) {
            FieldComparer = comparer;
        }

        private SubscriberComparer FieldComparer { get; }

        public int CompareTo(object obj) {
            if (obj == null) return 1;

            var otherSubscriber = obj as Subscriber;
            if (otherSubscriber != null) {
                return FieldComparer.Compare(this, otherSubscriber);
            }
            throw new ArgumentException("Invalid Object Type");
        }

        public int CompareTo(Subscriber other) {
            if (other == null) return 1;

            return FieldComparer.Compare(this, other);
        }

        public override string ToString() {
            var result = string.Format("[{0}, {1}, {2}]",
                (FieldComparer == SubscriberComparer.ByNumber ||
                 FieldComparer == SubscriberComparer.Default)
                    ? '<' + PhoneNumber + '>'
                    : PhoneNumber,
                (FieldComparer == SubscriberComparer.ByName) ? '<' + Name + '>' : Name,
                (FieldComparer == SubscriberComparer.ByRate) ? '<' + Rate + '>' : Rate);
            return result;
        }

        public override int GetHashCode()
        {
            return FieldComparer.GetHashCode(this);
        }

        public override bool Equals(object obj)
        {
            return FieldComparer.Equals(this, obj);
        }
    }
}
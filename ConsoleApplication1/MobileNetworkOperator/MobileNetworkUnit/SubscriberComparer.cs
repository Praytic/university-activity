using System;
using System.Collections.Generic;

namespace ConsoleApplication1.MobileNetworkOperator.MobileNetworkUnit
{
    public abstract class SubscriberComparer : IComparer<Subscriber>
    {
        public static SubscriberComparer Default { get; } = new PhoneNumberComparer();
        public static SubscriberComparer ByRate { get; } = new RateComparer();
        public static SubscriberComparer ByNumber { get; } = new PhoneNumberComparer();
        public static SubscriberComparer ByName { get; } = new NameComparer();

        public abstract int Compare(Subscriber x, Subscriber y);

        public abstract object GetField(Subscriber subscriber);

        public abstract Subscriber GetDummy(object value);

        public sealed class NameComparer : SubscriberComparer
        {
            public override int Compare(Subscriber x, Subscriber y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                return x.Name.CompareTo(y.Name);
            }

            public override object GetField(Subscriber subscriber)
            {
                return subscriber.Name;
            }

            public override Subscriber GetDummy(object value)
            {
                var dummy = new Subscriber {Name = (string) value};
                return dummy;
            }
        }

        public sealed class PhoneNumberComparer : SubscriberComparer
        {
            public override int Compare(Subscriber x, Subscriber y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                return x.PhoneNumber.CompareTo(y.PhoneNumber);
            }

            public override object GetField(Subscriber subscriber)
            {
                return subscriber.PhoneNumber;
            }

            public override Subscriber GetDummy(object value)
            {
                var dummy = new Subscriber {PhoneNumber = (string) value};
                return dummy;

            }
        }

        public sealed class RateComparer : SubscriberComparer
        {
            public override int Compare(Subscriber x, Subscriber y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                return x.Rate.CompareTo(y.Rate);
            }

            public override object GetField(Subscriber subscriber)
            {
                return subscriber.Rate;
            }

            public override Subscriber GetDummy(object value) {
                var dummy = new Subscriber {Rate = (string) value};
                return dummy;
            }
        }
    }
}
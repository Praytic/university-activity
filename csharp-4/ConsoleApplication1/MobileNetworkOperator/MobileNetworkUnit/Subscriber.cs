namespace ConsoleApplication1.MobileNetworkOperator.MobileNetworkUnit
{
    public class Subscriber
    {
        public Subscriber() { }

        public Subscriber(string phoneNumber, string name, string rate)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            Rate = rate;
        }

        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
    }
}
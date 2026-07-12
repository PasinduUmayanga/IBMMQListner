namespace IBMMQL.Main
{
    public class IBMMQConfig
    {
        public string IpAddress { get; set; }
        public int PortNumber { get; set; }
        public int CheckTimeIntervalMiliSeconds { get; set; }
        public string QueueManagerName { get; set; }
        public string QueueName { get; set; }
        public string ChannelName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

namespace HexMaster.Parcheesi.IdentityService
{
    public class ServicesSettings
    {
        public bool AzureServiceBusEnabled { get; set; }
        public bool AzureStorageEnabled { get; set; }

        public string SubscriptionClientName { get; set; }
        public string EventBusConnection { get; set; }
        public string EventBusUserName { get; set; }
        public string EventBusPassword { get; set; }
        public string EventBusRetryCount { get; set; }
    }
}

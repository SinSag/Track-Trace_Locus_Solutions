namespace locustrace.Shared
{
    //class for PrivateOrder
    public class PrivateOrder
    {
        //PrivateOrder members
        public int orderId { get; set; }
        public int externOrderId { get; set; }
        public string consignmentNo { get; set; }
        public string customerName { get; set; }
        public DateTime collectDate { get; set; }
        public DateTime collectLatestDate { get; set; }
        public string collectPlaceName { get; set; }
        public string collectPlaceStreet { get; set; }
        public int collectPlacePostalCode { get; set; }
        public string collectPlacePostalDistrict { get; set; }
        public string collectPlaceCountry { get; set; }
        public float collectPlaceLatitude { get; set; }
        public float collectPlaceLongitude { get; set; }
        public DateTime deliverDate { get; set; }
        public DateTime deliverLatestDate { get; set; }
        public string deliverPlaceName { get; set; }
        public string deliverPlaceStreet { get; set; }
        public int deliverPlacePostalCode { get; set; }
        public string deliverPlacePostalDistrict { get; set; }
        public string deliverPlaceCountry { get; set; }
        public float deliverPlaceLatitude { get; set; }
        public float deliverPlaceLongitude { get; set; }
        public DateTime etaCollect { get; set; }
        public DateTime etaDelivery { get; set; }
        public DateTime plannedETACollect { get; set; }
        public DateTime plannedETADelivery { get; set; }
        public int transportType { get; set; }
        public int tripId { get; set; }
        public double sumQuantity { get; set; }
        public double sumWeight { get; set; }
        public double sumVolume { get; set; }
        public double sumPallets { get; set; }
        public DateTime registeredTime { get; set; }
        public DateTime timeModified { get; set; }
        public DateTime timeStatus { get; set; }
        public PrivateParcelnumber[] parcelNumbers { get; set; }
    }

    public class PrivateParcelnumber
    {
        public string parcelNumber { get; set; }
        public int cargoLineIndex { get; set; }
        public float timeStatus { get; set; }
        public bool isScanned { get; set; }
        public int status { get; set; }
        public int subStatus { get; set; }
        public string loadCarrierNo { get; set; }
        public float setTimeStatus { get; set; }
    }
}

namespace locustrace.Shared
{
    //class for OpenOrder
    public class OpenOrder
    {
        //OpenOrder members
        public int orderId { get; set; }
        public int externOrderId { get; set; }
        public string consignmentNo { get; set; }
        public DateTime collectDate { get; set; }
        public DateTime collectLatestDate { get; set; }
        public string collectPlaceName { get; set; }
        public int collectPlacePostalCode { get; set; }
        public string collectPlacePostalDistrict { get; set; }
        public string collectPlaceCountry { get; set; }
        public DateTime deliverDate { get; set; }
        public DateTime deliverLatestDate { get; set; }
        public string deliverPlaceName { get; set; }
        public int deliverPlacePostalCode { get; set; }
        public string deliverPlacePostalDistrict { get; set; }
        public string deliverPlaceCountry { get; set; }
        public double sumQuantity { get; set; }
        public double sumWeight { get; set; }
        public double sumVolume { get; set; }
        public double sumPallets { get; set; }
        public DateTime registeredTime { get; set; }
        public DateTime timeModified { get; set; }
        public DateTime timeStatus { get; set; }
        public Parcelnumber[] parcelNumbers { get; set; }

        public class Parcelnumber
        {
            public string parcelNumber { get; set; }
            public int cargoLineIndex { get; set; }
            public double timeStatus { get; set; }
            public bool isScanned { get; set; }
            public int status { get; set; }
            public int subStatus { get; set; }
            public string loadCarrierNo { get; set; }
            public double setTimeStatus { get; set; }
        }
    }
}


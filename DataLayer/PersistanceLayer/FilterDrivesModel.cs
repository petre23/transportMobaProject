namespace DataLayer.PersistanceLayer
{
    public class FilterDrivesModel
    {
        public FilterDrivesModel()
        {
            FilterDriver = string.Empty;
            FilterTruck = string.Empty;
            FilterTrail = string.Empty;
            FilterVlaplan = string.Empty;
            FilterVlarref = string.Empty;
        }
        public string FilterDriver { get; set; }
        public string FilterTruck { get; set; }
        public string FilterTrail { get; set; }
        public string FilterVlaplan { get; set; }
        public string FilterVlarref { get; set; }
    }
}

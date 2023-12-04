namespace viewBlazor.Models
{
    public class WorkRezult
    {
        public long? ID { get; set; }
        public long? uniq { get; set; }
        public string? name { get; set; }
        public DateTime tBegin { get; set; }
        public string? project { get; set; }
        public DateTime tEnd { get; set; }
        public float timeOfWork { get; set; }
        public int price { get; set; }
        public decimal salary { get; set; }
    }
}

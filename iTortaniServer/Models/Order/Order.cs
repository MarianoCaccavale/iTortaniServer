namespace iTortaniServer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = "";
        public int NumHalfTortani { get; set; }
        public int NumTortani { get; set; }
        public int NumPizzeRipiene { get; set; }
        public int NumPizzeScarole { get; set; }
        public int NumHalfPizzeScarole { get; set; }
        public int NumPizzeSalsiccie { get; set; }
        public int NumHalfPizzeSalsiccie { get; set; }
        public int NumRustici { get; set; }
        public string Description { get; set; } = "";
        public int CellNum { get; set; }
        public DateTime DataRitiro { get; set; }
        public DateTime? Ritirato { get; 
            set; }
    }
}

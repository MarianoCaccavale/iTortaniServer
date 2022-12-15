namespace iTortaniServer.Models.Spese
{
    public class Spese
    {
        public int Id { get; set; }

        public string Cliente { get; set; } = "";

        public long CellNum { get; set; }

        public string Descrizione { get; set; } = "";

        public string Luogo { get; set; } = "";

        public bool CheckTortani { get; set; } = false;

        public DateTime DataRitiro { get; set; }

        public DateTime? Ritirato { get; set; }

    }
}

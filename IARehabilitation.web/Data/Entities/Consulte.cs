namespace IARehabilitation.web.Data.Entities
{
    public class Consulte
    {
        public int Id_Consulte { get; set; }
        public DateTime Date { get; set; }
        public string? Address { get; set; }
        public int Id_Deportista { get; set; }
        public int Id_Profesional { get; set; }
    }
}


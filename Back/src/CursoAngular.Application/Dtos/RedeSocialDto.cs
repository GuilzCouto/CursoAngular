namespace CursoAngular.Application.Dtos
{
    public class RedeSocialDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoID { get; set; }
        public EventoDto Evento { get; set; }
        public int? PalestranteID { get; set; }
        public PalestranteDto Palestrante { get; set; }
    }
}
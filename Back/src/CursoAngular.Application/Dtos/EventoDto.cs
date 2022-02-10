using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CursoAngular.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        
        [Required(ErrorMessage ="O campo {0} é obrigatório"),
        // MinLength(3, ErrorMessage ="O {0} deve ter mais de 3 caracteres"),
        // MaxLength(50, ErrorMessage ="O {0} deve ter menos de 50 caracteres")
         StringLength(50, MinimumLength =3, ErrorMessage ="O campo {0} deve ter de 3 à 50 caracteres")]
        public string TemaEvento { get; set; }

        [Display(Name = "quantidade de pessoas"),
        Range(1,120000, ErrorMessage ="A {0} deve ser de 1 a 120.000")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage ="Não é uma imagem válida (gif, jpg, jpeg, bmp e png")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório"),
        Phone(ErrorMessage = "O campo {0} está com o número inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório"),
         Display(Name = "e-mail"),
         EmailAddress(ErrorMessage ="É necessário ser um {0} válido")]
        public string Email { get; set; }

        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
   
    }
}
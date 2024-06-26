
using System.ComponentModel.DataAnnotations;


namespace Fophex.Application.Shared.HumanResource.Master.Groups.Dto
{
    public class UpdateGroupDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

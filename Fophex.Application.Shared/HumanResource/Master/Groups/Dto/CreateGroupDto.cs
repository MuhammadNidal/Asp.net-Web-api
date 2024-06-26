
using System.ComponentModel.DataAnnotations;


namespace Fophex.Application.Shared.HumanResource.Master.Groups.Dto
{
    public class CreateGroupDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public long GroupTypeId { get; set; }
    }
}

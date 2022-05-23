using FluentValidation;
using FluentValidation.Validators;
using System.ComponentModel;

namespace Warehouse.Model.Unit
{
    public class UnitModel
    {
        public string? Id { get; set; }

        [DisplayName("Tên đơn vị")]
        public string UnitName { get; set; }

        public bool Inactive { get; set; }
    }

    public partial class UnitValidator : AbstractValidator<UnitModel>
    {
        public UnitValidator()
        {
            RuleFor(x => x.UnitName).NotEmpty().WithMessage("Tên không được để trống")
                .MaximumLength(255).WithMessage("độ dài tối đa 255 ký tự");
        }
    }
}
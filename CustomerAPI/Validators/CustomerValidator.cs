using Data.Entities;
using FluentValidation;

namespace Data.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FullName)
                .NotEmpty()
                .MinimumLength(4);

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(customer => customer.EmailConfirmation)
                .NotEmpty()
                .Equal(customer => customer.Email).WithMessage("Email confirmation is different than Email");

            RuleFor(customer => customer.Cpf)
                .NotEmpty()
                .Must(IsCpfValid).WithMessage("'Cpf' did not match the expected format");

            RuleFor(customer => customer.Cellphone)
                .NotEmpty();

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .Must(IsOver18).WithMessage("'Customer' must be legal age");

            RuleFor(customer => customer.Country)
                .NotEmpty();

            RuleFor(customer => customer.City)
                .NotEmpty();

            RuleFor(customer => customer.Postalcode)
                .NotEmpty();

            RuleFor(customer => customer.Address)
                .NotEmpty();

            RuleFor(customer => customer.Number)
                .NotEmpty();

            static bool IsCpfValid(string Cpf)
            {
                int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string hasCpf;
                string digit;
                int sum;
                int rest;

                if (Cpf.Length != 11)
                    return false;

                hasCpf = Cpf.Substring(0, 9);
                sum = 0;

                for (int i = 0; i < 9; i++)
                    sum += int.Parse(hasCpf[i].ToString()) * mult1[i];

                rest = sum % 11;

                if (rest < 2)
                    rest = 0;
                else

                    rest = 11 - rest;

                digit = rest.ToString();

                hasCpf = hasCpf + digit;

                sum = 0;

                for (int i = 0; i < 10; i++)
                    sum += int.Parse(hasCpf[i].ToString()) * mult2[i];

                rest = sum % 11;

                if (rest < 2)
                    rest = 0;
                else
                    rest = 11 - rest;

                digit = digit + rest.ToString();

                return Cpf.EndsWith(digit);
            }

            static bool IsOver18(System.DateTime dateOfBirth)
            {
                return dateOfBirth <= System.DateTime.Now.AddYears(-18);
            }
        }
    }
}
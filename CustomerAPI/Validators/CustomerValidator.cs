using Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() 
        {
           
            RuleFor(customer => customer.FullName)
                .NotEmpty().WithMessage("Name cannot remain empty")
                .MinimumLength(4);

            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Email cannot remain empty")
                .EmailAddress().WithMessage("Email is not valId");

            RuleFor(customer => customer.EmailConfirmation)
                .NotEmpty().WithMessage("Confirm Email")
                .Equal(customer => customer.Email).WithMessage("Email confirmation is different than Email");

            RuleFor(customer => customer.Cpf)
                .NotEmpty().WithMessage("Cpf cannot remain empty")
                .Must(CpfValIdation);

            RuleFor(customer => customer.Cellphone)
                .NotEmpty().WithMessage("Cellphone cannot remain empty");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty().WithMessage("Date_of_birth cannot remain empty")
                .Must(VerifyAge).WithMessage("Customer cannot be registered if he is a minor");

            RuleFor(customer => customer.Country)
                .NotEmpty().WithMessage("Country cannot remain empty");

            RuleFor(customer => customer.City)
                .NotEmpty().WithMessage("City cannot remain empty");

            RuleFor(customer => customer.Postalcode)
                .NotEmpty().WithMessage("Postal cannot remain empty");

            RuleFor(customer => customer.Address)
                .NotEmpty().WithMessage("Address cannot remain empty");

            RuleFor(customer => customer.Number)
                .NotEmpty().WithMessage("Number cannot remain empty");
  

            static bool CpfValIdation(string Cpf)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                Cpf = Cpf.Trim();
                Cpf = Cpf.Replace(".", "").Replace("-", "");
                if (Cpf.Length != 11)
                    return false;
                tempCpf = Cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return Cpf.EndsWith(digito);
            }

            static bool VerifyAge(System.DateTime dateOfBirth)
            {
                return dateOfBirth <= System.DateTime.Now.AddYears(-18);
            }


        }
    }
}

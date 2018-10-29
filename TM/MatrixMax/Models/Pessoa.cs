using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MatrixMax.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public string Telefone { get; set; }

        public char TipoPessoa { get; set; }
        [MaxLength(50)]
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        [MaxLength(50)]
        public string NomeFantasia { get; set; }

        public Endereco Endereco { get; set; }

        public bool Valida()
        {
            if (NomeRazaoSocial == null || Telefone == null || Email == null || CpfCnpj == null)
                return false;

            if (NomeRazaoSocial.Length < 5 || NomeRazaoSocial.Length > 50) return false;
            if (Telefone.Length < 14 || Telefone.Length > 15) return false;
            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"))
                return false;

            if (TipoPessoa == 'F')
            {
                if (CpfCnpj.Length != 14) return false;
                return true;
            }
            else if (TipoPessoa == 'J')
            {
                if (CpfCnpj.Length != 18) return false;

                if (InscricaoEstadual == null || NomeFantasia == null)
                    return false;

                if (InscricaoEstadual.Length != 15) return false;
                if (NomeFantasia.Length < 5 || NomeRazaoSocial.Length > 50) return false;
                return true;
            }
            else return false;
        }

        public override bool Equals(object obj)
        {
            Pessoa outraPessoa = obj as Pessoa;

            if (outraPessoa == null) return false;

            return Id == outraPessoa.Id &&
                    Email == outraPessoa.Email &&
                    Telefone == outraPessoa.Telefone &&
                    TipoPessoa == outraPessoa.TipoPessoa &&
                    NomeRazaoSocial == outraPessoa.NomeRazaoSocial &&
                    CpfCnpj == outraPessoa.CpfCnpj &&
                    InscricaoEstadual == outraPessoa.InscricaoEstadual &&
                    NomeFantasia == outraPessoa.NomeFantasia;
        }

        public bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            if (cpf == null || string.IsNullOrEmpty(cpf))
            {
                return false;
            }
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
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
            return cpf.EndsWith(digito);
        }

        public bool ValidaCnpj(string cnpj)
        {
            if (cnpj == null || string.IsNullOrEmpty(cnpj))
            {
                return false;
            }
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
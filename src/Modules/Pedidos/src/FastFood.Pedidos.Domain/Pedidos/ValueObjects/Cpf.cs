using System.Text.RegularExpressions;
using FastFood.Pedidos.Domain.Pedidos.Exceptions;

namespace FastFood.Pedidos.Domain.Pedidos.ValueObjects;

public sealed record Cpf
{
    private Cpf()
    {
    }
    
    private Cpf(string valor)
    {
        Valor = valor;
    }
    
    public string Valor { get; }

    public static Cpf Criar(string valor)
    {
        if(!Validar(valor))
            throw new CpfInvalidoDomainException();
        
        valor = Regex.Replace(valor, @"[^\d]", "");
        
        return new(valor);
    }
    
    public static bool Validar(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor)) return false;

        var posicao = 0;
        var totalDigito1 = 0;
        var totalDigito2 = 0;
        var dv1 = 0;
        var dv2 = 0;

        bool digitosIdenticos = true;
        var ultimoDigito = -1;

        foreach (var c in valor)
        {
            if (!char.IsDigit(c)) continue;
            
            var digito = c - '0';
                
            if (posicao != 0 && ultimoDigito != digito)
                digitosIdenticos = false;

            ultimoDigito = digito;
            if (posicao < 9)
            {
                totalDigito1 += digito * (10 - posicao);
                totalDigito2 += digito * (11 - posicao);
            }
            else if (posicao == 9)
            {
                dv1 = digito;
            }
            else if (posicao == 10)
            {
                dv2 = digito;
            }

            posicao++;
        }

        if (posicao > 11) return false;
        
        if (digitosIdenticos) return false;

        var digito1 = totalDigito1 % 11;
        digito1 = digito1 < 2 
            ? 0 
            : 11 - digito1;

        if (dv1 != digito1) return false;

        totalDigito2 += digito1 * 2;
        var digito2 = totalDigito2 % 11;
        digito2 = digito2 < 2 
            ? 0 
            : 11 - digito2;

        return dv2 == digito2;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Application
{
    public class ArrayAppService : IArrayAppService
    {
        public List<int> ObterIndiceDoArray(int numeroAlvo)
        {
            List<int> arrayReturn = new List<int>();

            int[] arrayNumbers = { 1, 3, 5, 10};

            if (arrayNumbers[0] + arrayNumbers[1] == numeroAlvo)
            {
                arrayReturn.Add(0);
                arrayReturn.Add(1);
            }
            else if (arrayNumbers[0] + arrayNumbers[2] == numeroAlvo)
            {
                arrayReturn.Add(0);
                arrayReturn.Add(2);
            }
            else if (arrayNumbers[0] + arrayNumbers[3] == numeroAlvo)
            {
                arrayReturn.Add(0);
                arrayReturn.Add(3);
            }
            else if (arrayNumbers[1] + arrayNumbers[2] == numeroAlvo)
            {
                arrayReturn.Add(1);
                arrayReturn.Add(2);
            }
            else if (arrayNumbers[1] + arrayNumbers[3] == numeroAlvo)
            {
                arrayReturn.Add(1);
                arrayReturn.Add(3);
            }
            else if (arrayNumbers[2] + arrayNumbers[3] == numeroAlvo)
            {
                arrayReturn.Add(2);
                arrayReturn.Add(3);
            }

            return arrayReturn;
        }

        public string Brackets(string brackets)
        {
            string balanceado = "SIM";
            string naoBalanceado = "NÃO";            

            if (brackets.Length % 2 != 0)
                return naoBalanceado;

            if (VerifyIfCharIsBalanceada(brackets) == true)
            {
                return balanceado;
            }

            return naoBalanceado;
        }

        private bool VerifyIfCharIsBalanceada(string brackets)
        { 
            string ChavesBegin = "{";
            string ChavesClose = "}";

            string ParantesesBegin = "(";
            string ParantesesClose = ")";

            string ColchetesBegin = "[";
            string ColchetesClose = "]";

            var lenghtString = brackets.Length;

            var position = (lenghtString - 1);

            for (int i = 0; i <= (lenghtString / 2) - 1; i++)
            {
                if (brackets.Substring(i, 1) == ChavesBegin)
                {
                    if (brackets.Substring(position, 1) != ChavesClose)
                        return false;
                }

                if (brackets.Substring(i, 1) == ParantesesBegin)
                {
                    if (brackets.Substring(position, 1) != ParantesesClose)
                        return false;
                }

                if (brackets.Substring(i, 1) == ColchetesBegin)
                {
                    if (brackets.Substring(position, 1) != ColchetesClose)
                        return false;
                }

                position -= 1;
            }

            return true;
        }

        public string CompraVendaAcoes(string codigoUsuario, int dia)
        {
            Dictionary<string,int> user = GetInformationUserByCpf(codigoUsuario);

            var precoHoje = ObterPrecoDia(dia);
            if (!user.Any())
                return "Purchase Success in Value: " + string.Format("{0:0.00}", precoHoje.ToString());

            double precoCompra = new double();

            int diaCompra = new int();
            foreach (var item in user)
            {
                diaCompra = item.Value;
            }

            precoCompra  = ObterPrecoDia(diaCompra);

            var lucro = GetProfitFromPurchase(precoCompra, precoHoje);
            return "Total de lucro foi: " + string.Format("{0:0.00}", lucro.ToString());
        }

        private double GetProfitFromPurchase(double pricePurchase, double priceToday)
        {
            if (pricePurchase > priceToday)
            {
                return 0.00;
            }
            else
            {
                return priceToday - pricePurchase;
            }
        }

        private Dictionary<string, int> GetInformationUserByCpf(string cpfUser)
        {
            Dictionary<string, int> userReturn = new Dictionary<string, int>();

            Dictionary<string, int> user = new Dictionary<string, int>();
            user.Add("12345678987", 1);
            user.Add("12345678952", 4);
            user.Add("11640950729", 2);

            foreach (var item in user)
            {
                if (item.Key == cpfUser)
                {
                    userReturn.Add(item.Key, item.Value);
                }
            }

            return userReturn;
        }

        private double ObterPrecoDia(int dia)
        {
            double[] PriceByDayStockExchange = { 2.0, 1.0, 6.0, 10.0, 3.0, 5.0 };

            double priceOfSaleOrPurchase = new double();
            for (int i = 0; i < (PriceByDayStockExchange.Count() - 1); i++)
            {
                if (i == (dia - 1))
                    priceOfSaleOrPurchase = PriceByDayStockExchange[i];
            }

            return priceOfSaleOrPurchase;
        }

        public int CalcularAguaRetida(int?[] numeros)
        {
            //int?[] numbers = new int?[400];
            int value = 0;
            int[] numerosAnalisados = new int[400];

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] == null)
                    continue;

                if (!numerosAnalisados.Contains(numeros[i].Value))
                    numerosAnalisados[i] = numeros[i].Value;
            }

            for (int i = 0; i < numerosAnalisados.Length; i++)
            {
                if (numerosAnalisados[i] == 0)
                    continue;

                value += numerosAnalisados[i];
            }

            return value;
        }
    }
}

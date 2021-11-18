using System;

namespace TesteAudaz
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadastro();
        }
        private static void Cadastro()
        {
            var fare = new Fare();
            fare.Id = Guid.NewGuid();

            Console.WriteLine("O que deseja Cadastrar ? 1 - Operador , 2 - Tarifa");
            var opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.WriteLine("Informe o código do operador");

                var opeCodeInput = Console.ReadLine();
                var operatorController = new OperatorController();

                var ope = new Operator();
                ope.Id = Guid.NewGuid();
                ope.Code = opeCodeInput;

                var resultOperator = operatorController.CreateOperator(ope);
                Console.WriteLine(resultOperator);
                Cadastro();
            }

            if (opcao == "2")
            {
                Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                var fareValueInput = Console.ReadLine();
                fare.Value = decimal.Parse(fareValueInput);

                Console.WriteLine("Informe o código da operadora para a tarifa:");
                Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                var operatorCodeInput = Console.ReadLine();

                var fareController = new FareController();
                var resultFare = fareController.CreateFare(fare, operatorCodeInput);

                Console.WriteLine(resultFare);
                Cadastro();
            }
        }

    }
}


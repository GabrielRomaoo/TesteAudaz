using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteAudaz
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService _fareService;

        public FareController()
        {
            _operatorService = new OperatorService();
            _fareService = new FareService();
        }

        public string CreateFare(Fare fare, string operatorCode)
        {
            var newFare = new Fare();

            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            if(selectedOperator == null)
            {
                selectedOperator =  new Operator { Code = operatorCode, Id = Guid.NewGuid() };
            }
            newFare.Id = fare.Id;
            newFare.OperatorId = selectedOperator.Id;
            newFare.CreatedAt = DateTime.Today;
            newFare.Status = 1;

            var validFare = ValidateFare(newFare);

            if (validFare)
            {

                _fareService.Create(newFare);
                return "Tarifa cadastrada com sucesso!";

            }
            else
            {

                return "Operador possui uma tarifa ativa com o mesmo valor em menos de 6 meses!";
            }


        }

        private bool ValidateFare(Fare fare)
        {

            var allFares = _fareService.GetFares();

            var selectedFare = allFares.Where(x => x.Status == 1 && x.OperatorId == fare.OperatorId && x.CreatedAt <= DateTime.Today.AddMonths(-6).Date);

            if (selectedFare.Count() == 0)
            {

                return true;
            }
            else
            {

                return false;
            }


        }
    }
}

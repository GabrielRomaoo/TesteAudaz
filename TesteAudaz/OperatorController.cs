using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAudaz
{
    public class OperatorController
    {
        private OperatorService _operatorService;
        private FareService _fareService;

        public OperatorController()
        {
            _operatorService = new OperatorService();
        }

        public string CreateOperator(Operator ope)
        {
            if(ope.Code != null)
            {
                _operatorService.Create(ope);
                return "Operador Cadastrado com sucesso!";
            }
            else
            {
                return "Código em branco, por favor, digite um código!";
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompanyModel.Enums
{
   /// <summary>
   /// Виды договоров страхования
   /// </summary>
    public enum ContractType
    {
        ДоговорЛичногоСтрахования = 0,
        ДоговорИмущественногоСтрахования = 1,
        ДоговорСтрахованияРискаОтветственности = 2
    }
}

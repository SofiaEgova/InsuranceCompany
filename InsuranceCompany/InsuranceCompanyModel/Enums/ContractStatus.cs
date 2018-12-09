using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompanyModel.Enums
{
    /// <summary>
    /// Статус договора страхования
    /// </summary>
    public enum ContractStatus
    {
        Действует = 0,
        СрокЗакончен = 1,
        Перезаключен = 2
    }
}

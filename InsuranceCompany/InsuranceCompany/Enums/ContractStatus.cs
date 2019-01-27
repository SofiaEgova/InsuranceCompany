using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Enums
{
    public enum ContractStatus
    {
        Действует = 1,
        Закончился_срок = 0,
        Перезаключен = 2,
        Наступил_страховой_случай = 3
    }
}

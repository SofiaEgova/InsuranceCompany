using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.IServices
{
    public interface ISerializeService
    {
        string GetDataFromAdmin();

        string GetDataFromAgent();

        string GetDataFromBooker();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using InsuranceCompany.IServices;
using System.IO;
using InsuranceCompany.Models;

namespace InsuranceCompany.Services
{
    public class SerializeService : ISerializeService
    {
        private InsuranceCompanyDbContext _context;

        public SerializeService(InsuranceCompanyDbContext context)
        {
            this._context = context;
        }

        public string GetDataFromAdmin()
        {
            DataContractJsonSerializer userJS = new DataContractJsonSerializer(typeof(List<User>));
            MemoryStream msUser = new MemoryStream();
            userJS.WriteObject(msUser, _context.Users.ToList());
            msUser.Position = 0;
            StreamReader srUser = new StreamReader(msUser);
            string usersJSON = srUser.ReadToEnd();
            srUser.Close();
            msUser.Close();

            return
                "{\n" +  "    \"Users\": " + usersJSON + "}";
        }

        public string GetDataFromAgent()
        {
            var user = _context.Users.FirstOrDefault(u => u.IsActive == true);
            DataContractJsonSerializer contractJS = new DataContractJsonSerializer(typeof(List<Contract>));
            MemoryStream msContract = new MemoryStream();
            var resultContract = _context.Contracts.Where(c => c.Status != 1&&c.UserId==user.Id);
            contractJS.WriteObject(msContract, resultContract.ToList());
            msContract.Position = 0;
            StreamReader srContract = new StreamReader(msContract);
            string contractsJSON = srContract.ReadToEnd();
            srContract.Close();
            msContract.Close();
            _context.Contracts.RemoveRange(resultContract);

            List<Client> resultClient = new List<Client>(); ;
            foreach(var c in resultContract)
            {
                resultClient.Add(_context.Clients.FirstOrDefault(cl => cl.Id == c.ClientId));
            }
            DataContractJsonSerializer clientJS = new DataContractJsonSerializer(typeof(List<Client>));
            MemoryStream msClient = new MemoryStream();
            clientJS.WriteObject(msClient, resultClient);
            msClient.Position = 0;
            StreamReader srClient = new StreamReader(msClient);
            string clientsJSON = srClient.ReadToEnd();
            srClient.Close();
            msClient.Close();
            
            _context.Clients.RemoveRange(resultClient);
            _context.SaveChanges();

            return
                "{\n" + "    \"Contracts\": " + contractsJSON + ",\n" +
                "    \"Clients\": " + clientsJSON + "}";
        }

        public string GetDataFromBooker()
        {
            DataContractJsonSerializer salaryJS = new DataContractJsonSerializer(typeof(List<Salary>));
            MemoryStream msSalary = new MemoryStream();
            var resultSalary = _context.Salaries.Where(s => s.Date.Year != DateTime.Now.Year);
            salaryJS.WriteObject(msSalary, resultSalary.ToList());
            msSalary.Position = 0;
            StreamReader srSalary = new StreamReader(msSalary);
            string salariesJSON = srSalary.ReadToEnd();
            srSalary.Close();
            msSalary.Close();

            return
                "{\n" + "    \"Salaries\": " + salariesJSON + "}";
        }
    }
}

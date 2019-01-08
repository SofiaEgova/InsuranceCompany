using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany
{
    public class ResultService
    {
        public bool Succeeded { get; private set; }

        public List<KeyValuePair<string, string>> Errors { get; private set; }

        /// <summary>
        /// Какой-то объект, получаемый по результатам операции (например, id)
        /// </summary>
        public object Result { get; private set; }

        public ResultService()
        {
            Errors = new List<KeyValuePair<string, string>>();
            Succeeded = true;
        }

        public void AddError(string key, string value)
        {
            Errors.Add(new KeyValuePair<string, string>(key, value));
            if (Succeeded)
            {
                Succeeded = false;
            }
        }

        public void AddError(Exception error)
        {
            Errors.Add(new KeyValuePair<string, string>("Общая ошибка", error.Message));
            if (Succeeded)
            {
                Succeeded = false;
            }
        }
    }

    public class ResultService<T>
    {
        public bool Succeeded { get; private set; }

        public List<KeyValuePair<string, string>> Errors { get; private set; }

        public List<T> List { get; private set; }

        public T Result { get; private set; }

        public ResultService()
        {
            Errors = new List<KeyValuePair<string, string>>();
            Succeeded = true;
        }

        public void AddError(string key, string value)
        {
            Errors.Add(new KeyValuePair<string, string>(key, value));
            if (Succeeded)
            {
                Succeeded = false;
            }
        }
    }
}

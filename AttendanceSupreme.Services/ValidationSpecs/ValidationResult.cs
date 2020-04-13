using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Services.ValidationSpecs
{
    public class ValidationResult
    {
        
        public bool IsValid 
        {
            get => _errors.Count > 0;
            private set
            {
                IsValid = false;
            }
        }

        public IEnumerable<string> Errors => _errors;

        private List<string> _errors = new List<string>();

        public void AddError(string error)
        {
            if (String.IsNullOrEmpty(error))
                throw new ArgumentNullException("Error message cannot be null");

            _errors.Add(error);

        }

        public void AddError(IEnumerable<string> errors)
        {
            if (errors == null)
                throw new ArgumentNullException("Erros messages cannt be null");

            foreach(var error in errors)
            {
                _errors.Add(error);
            }
        }
    }
}

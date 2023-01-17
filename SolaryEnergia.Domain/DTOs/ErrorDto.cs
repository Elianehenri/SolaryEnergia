using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.DTOs
{
    public class ErrorDto
    {
        public string Error { get; set; }
        public ErrorDto(string error)
        {
            Error = error;
        }
    }
}

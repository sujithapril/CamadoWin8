using CamadoWin8.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Model
{
    public class LogInResponse: ILogInResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public string authToken { get; set; }
        public string userId { get; set; }
        public string orgId { get; set; }
    }
}

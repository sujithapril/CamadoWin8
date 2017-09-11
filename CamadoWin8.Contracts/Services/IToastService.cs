using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Services
{
      public interface IToastService
    {
        void SendSimpleTextToast(string text);
        void SendImageAndTextToast(string text, string imageUrl);
    }
}

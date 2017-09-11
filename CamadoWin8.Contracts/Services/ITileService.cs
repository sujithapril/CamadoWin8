using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Services
{
    public interface ITileService
    {
        void SendSimpleTextUpdate(string text);
        void SendImageAndTextUpdate(string text, string imageUrl);
    }
}

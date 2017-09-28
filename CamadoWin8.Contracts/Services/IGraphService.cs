using CamadoWin8.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Services
{
    public interface IGraphService
    {
        Task<IRootObject> GetBarGraph(string deviceId, string devicemacId);
        Task<IRootObject> GetBarGraph2(string deviceId, string devicemacId);
        Task<IRootObjectLIne> GetLineGraph2(string startDate, string endDate, string devicemacId, string aggregateFunction);
        Task<IRootObjectLIne> GetLineGraph(string startDate, string endDate, string devicemacId, string aggregateFunction);
    }  
}

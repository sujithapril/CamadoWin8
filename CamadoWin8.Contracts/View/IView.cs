using CamadoWin8.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadoWin8.Contracts.View
{
    public interface IView
    {
        IViewModel ViewModel { get; }
    }
}

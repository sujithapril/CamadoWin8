using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CamadoWin8.Repositories;
using System.Threading.Tasks;
using CamadoWin8.Shared;
using CamadoWin8.Contracts.Services;
using CamadoWin8.ViewModel;
using CamadoWin8.Contracts.ViewModels;

namespace CamadoWin8.Tests
{
    [TestClass]
    public class ContinentDetailViewModelTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            InstanceFactory.RegisterType<INavigationService, FakeNavigationService>();
            InstanceFactory.RegisterType<ITravelDataService, FakeTravelDataService>();
          
        }

        [TestMethod]
        public void CheckSelectedContinentNotEmptyAfterInitialize()
        {
            //Arrange
            var viewModel = InstanceFactory.GetInstance<ILogInViewModel>();


            //Act 
            viewModel.Initialize("1");//Europe


            //Assert
            Assert.IsNotNull(viewModel);
        }
    }
}

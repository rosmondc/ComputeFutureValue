using ComputeFutureValue.Api.Controllers;
using ComputeFutureValue.Api.Infrastructure.Interfaces;
using ComputeFutureValue.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ComputeFutureValue.Tests
{
    public class InvoiceControllerTests
    {
        private readonly Mock<IInvoiceService> _mockService;

        public InvoiceControllerTests()
        {
            _mockService = new Mock<IInvoiceService>();
        }


        [Fact]
        public void InvoiceController_Compute_Return_Valid_FutureValue()
        {
            var futureValue = 3217.5M;
            var invoiceViewModel = new InvoiceViewModel()
            {
                PresentValue = 1000M,
                LowerBoundInterestRate = 10M,
                UpperBoundInterestRate = 50M,
                Maturity = 4,
                IncrementalRate = 20,
                FutureValue = futureValue
            };

            _mockService.Setup(s => s.CalculateFutureAmount(invoiceViewModel)).Returns(invoiceViewModel.FutureValue);
            _mockService.Setup(s => s.SaveInvoiceComputation(invoiceViewModel)).ReturnsAsync(true);

            var controller = new InvoiceController(_mockService.Object);

            // Act
            var result = controller.Compute(invoiceViewModel).Result;

            //Assert
            Assert.True(result ==  invoiceViewModel.FutureValue);
        }

        [Fact]
        public void InvoiceController_Compute_Return_Invalid_FutureValue()
        {
            // Arrange
            var futureValue = 3217.5M;
            var invoiceViewModel = new InvoiceViewModel()
            {
                PresentValue = It.IsAny<decimal>(),
                LowerBoundInterestRate = It.IsAny<decimal>(),
                UpperBoundInterestRate = It.IsAny<decimal>(),
                Maturity = It.IsAny<int>(),
                IncrementalRate = It.IsAny<decimal>(),
                FutureValue = It.IsAny<decimal>()
            };

            _mockService.Setup(s => s.CalculateFutureAmount(invoiceViewModel)).Returns(futureValue);
            _mockService.Setup(s => s.SaveInvoiceComputation(invoiceViewModel)).ReturnsAsync(true);

            var controller = new InvoiceController(_mockService.Object);

            // Act
            var result = controller.Compute(invoiceViewModel).Result;

            //Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void InvoiceController_Compute_Return_Unable_To_Save_Invoice()
        {
            // Arrange
            var futureValue = 3217.5M;
            var invoiceViewModel = new InvoiceViewModel()
            {
                PresentValue = It.IsAny<decimal>(),
                LowerBoundInterestRate = It.IsAny<decimal>(),
                UpperBoundInterestRate = It.IsAny<decimal>(),
                Maturity = It.IsAny<int>(),
                IncrementalRate = It.IsAny<decimal>(),
                FutureValue = futureValue
            };

            _mockService.Setup(s => s.CalculateFutureAmount(invoiceViewModel)).Returns(invoiceViewModel.FutureValue);
            _mockService.Setup(s => s.SaveInvoiceComputation(invoiceViewModel)).ReturnsAsync(false);

            var controller = new InvoiceController(_mockService.Object);

            // Act
            var result = controller.Compute(invoiceViewModel).Result;

            //Assert
            Assert.True(result == 0);
        }

        [Fact]
        public void InvoiceController_Return_All_Product()
        {
            // Arrange
            var invoiceViewModels = new List<InvoiceViewModel>()
            {
                new InvoiceViewModel() {
                    PresentValue = It.IsAny<decimal>(),
                    LowerBoundInterestRate = It.IsAny<decimal>(),
                    UpperBoundInterestRate = It.IsAny<decimal>(),
                    Maturity = It.IsAny<int>(),
                    IncrementalRate = It.IsAny<decimal>(),
                }
            };

            _mockService.Setup(s => s.GetAllHistory(null)).ReturnsAsync(invoiceViewModels);
            var controller = new InvoiceController(_mockService.Object);

            // Act
            var results = controller.Index(null).Result;

            //Assert
            Assert.IsType<OkObjectResult>(results);
        }

        [Fact]
        public void InvoiceController_Return_No_Product()
        {
            // Arrange
            var invoiceViewModels = new List<InvoiceViewModel>();

            _mockService.Setup(s => s.GetAllHistory(null)).ReturnsAsync(invoiceViewModels);
            var controller = new InvoiceController(_mockService.Object);

            // Act
            var results = controller.Index(null).Result;

            //Assert
            Assert.IsType<NotFoundResult>(results);
        }
    }
}

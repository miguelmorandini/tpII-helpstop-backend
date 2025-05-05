using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product, with parameters Valid")]
        public void CreateProduct_WithValidParaneters_ResultObjetctValidState()
        {
            Action action = () => new Product(1, "Product Name", "product Descripition", 9.99m, 99, "img/productimage.jpg");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Create Product With Valid State Alone Name")]
        public void CreateProduct_WithAloneName_ResultObjectValidState()
        {
            Action action = () => new Category("Product Name");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos
        //id
        [Fact(DisplayName = "Create Product With Negative Id")]
        public void CreateProduct_WithNegativeId_ResultObjetctException()
        {
            Action action = () => new Product(-1, "Product Name", "Product Descripition", 9.99m, 99, "img/productimage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Update Invalid Id value"); 
        }

        //name
        [Fact(DisplayName = "Create Product With Name Empty")]
        public void CreateProduct_WithNameEmpty_ResultObjetctException()
        {
            Action action = () => new Product(1, "", "Product Descripition", 9.99m, 99, "img/productimage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required."); 
        }

        [Fact(DisplayName = "Create Product With Name Null")]
        public void CreateProduct_WithNameNull_ResultObjetctException()
        {
            Action action = () => new Product(1, null, "Product Descripition", 9.99m, 99, "img/productimage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Name Too Short")]
        public void CreateProduct_WithNameToShort_ResultObjetctException()
        {
            Action action = () => new Product(1, "Na", "Product Descripition", 9.99m, 99, "img/productimage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        //description
        [Fact(DisplayName = "Create Product With Description Empty")]
        public void CreateProduct_WithDescriptionEmpty_ResultObjetctException()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "img/productimage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, name is required.");
        }

        [Fact(DisplayName = "Create Product With Description Null")]
        public void CreateProduct_WithDescriptionNull_ResultObjetctException()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "img/productimage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, name is required.");
        }

        [Fact(DisplayName = "Create Product With Description Too Short")]
        public void CreateProduct_WithDescriptionToShort_ResultObjetctException()
        {
            Action action = () => new Product(1, "Product Name", "Desc", 9.99m, 99, "img/productimage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        //price
        [Theory(DisplayName = "Create Product With Negative Price")]
        [InlineData(-25)]
        public void CreateProduct_WithNegativePrice_ResultObjectException(decimal price)
        {
            Action action = () => new Product("Product Name", "Product Description", price, 99, "/img/productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        //stock
        [Theory(DisplayName = "Create Product With Negative Stock")]
        [InlineData(-1)]
        public void CreateProduct_WithNegativeStock_ResultObjectException(int stock)
        {
            Action action = () => new Product("Product Name", "Product Description", 9.99m, stock, "/img/productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }

        //image
        [Theory(DisplayName = "Create Product With Image Name Too Long")]
        [InlineData("img/123456789101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100101102103104105106107108109110111112113114115116117118119120121122123124125126127128129130131132133134135136137138139140141142143144145146147148149150.jpg")]
        public void CreateProduct_WithImageNameTooLong_ResultObjectException(string url)
        {
            Action action = () => new Product("Product Name", "Product Description", 9.99m, 99, url);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact(DisplayName = "Create Product With Name Image Empty")]
        public void CreateProduct_WithNameImageEmpty_ResultObjetctException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image, image is required");
        }
        #endregion
    }
}

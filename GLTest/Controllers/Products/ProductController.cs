using GLTest.Controllers.Products.InputModels;
using GLTest.Core.Commands.Products;
using Microsoft.AspNetCore.Mvc;

namespace GLTest.Controllers.Products
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ISetProductCategoryCommand _setProductCategoryCommand;

        public ProductController(ISetProductCategoryCommand setProductCategoryCommand)
        {
            _setProductCategoryCommand = setProductCategoryCommand;
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> SetProductCategory([FromRoute] Guid productId, [FromBody] SetCategoryInputModel model)
        { 
            var commandResult = await _setProductCategoryCommand.ExecuteAsync(productId, model.CategoryIdList);
            if (!commandResult.IsSuccessful)
                return BadRequest(commandResult.Error);

            return Ok();
        }
    }
}

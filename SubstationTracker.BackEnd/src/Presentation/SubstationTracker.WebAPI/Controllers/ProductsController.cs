using MediatR;
using Microsoft.AspNetCore.Mvc;
using SubstationTracker.Application.Features.Products._Bases.Commands.CreateProduct;
using SubstationTracker.Application.Features.Products._Bases.Commands.SoftDeleteProduct;
using SubstationTracker.Application.Features.Products._Bases.Commands.UpdateProduct;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProduct;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsForList;
using SubstationTracker.WebAPI.Controllers._Bases;

namespace SubstationTracker.WebAPI.Controllers;

[Route("products")]
public class ProductsController : ApiControllerBase
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateProductCommandRequest request)
        => GenerateResponse(await Mediator.Send(request));

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromForm] UpdateProductCommandRequest request)
        => GenerateResponse(await Mediator.Send(request));

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] SoftDeleteProductCommandRequest request)
        => GenerateResponse(await Mediator.Send(request));

    [HttpPost("get-list")]
    public async Task<IActionResult> GetListAsync(GetProductsForListQueryRequest request)
        => GenerateResponse(await Mediator.Send(request));

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetAsync([FromRoute] GetProductQueryRequest request)
        => GenerateResponse(await Mediator.Send(request));
    
    [HttpPost("get-list-by-substation")]
    public async Task<IActionResult> GetListBySubstationAsync(GetProductsBySubstationQueryRequest request)
        => GenerateResponse(await Mediator.Send(request));
}
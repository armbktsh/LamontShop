namespace Products.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize("Admin")]
public class JewelryController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly string _imagesDirectory;
    private readonly ISender _mediator;

    public JewelryController(IFileService fileService, ISender mediator)
    {
        _fileService = fileService;
        _imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","Images");
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(200, Type = typeof(List<JewelryListDto>))]
    public async Task<IActionResult> GetJewelries()
    {
        return Ok(await _mediator.Send(new GetJewelryListQuery()));
    }

    [HttpGet("{id:int}", Name = "GetJewelry")]
    [AllowAnonymous]
    [ProducesResponseType(200, Type = typeof(JewelryDetailDto))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetJewelry(int id)
        => Ok(await _mediator.Send(new GetJewelryDetailQuery(id)));

    [HttpPost]
    [ProducesResponseType(400)]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateJewelry([FromBody] CreateJewelryCommand jewelry)
    {
        var res = await _mediator.Send(jewelry);
        return CreatedAtRoute("GetJewelry", new { id = res }, jewelry);
    }

    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> UpdateJewelry(UpdateJewelryCommand jewelry)
    {
        if (jewelry.Image != jewelry.Image)
            _fileService.DeleteFile(_imagesDirectory, jewelry.Image!);

        await _mediator.Send(jewelry);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> DeleteJewelry(int id)
    {
        await _mediator.Send(new DeleteJewelryCommand(id));

        //_fileService.DeleteFile(_imagesDirectory, jewelry.Image!);

        return NoContent();
    }

    [HttpPost("UploadImage")]
    [ProducesResponseType(500)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UploadImage([Required] IFormFile image)
    {
        await _fileService.CreateFile(image, _imagesDirectory, image.FileName);
        return Ok();
    }

    [HttpGet("GetImage/{jewelryId:int}")]
    [AllowAnonymous]
    [ProducesResponseType(204)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetImage(int jewelryId)
    {
        var jewelry = await _mediator.Send(new GetJewelryDetailQuery(jewelryId));

        return File(await System.IO.File.ReadAllBytesAsync($"{_imagesDirectory}/{jewelry.Image!}"), "image/*");
    }
}

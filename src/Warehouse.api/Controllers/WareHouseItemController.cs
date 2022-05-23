﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Warehouse.Common;
using Warehouse.Model.WareHouseItem;
using Warehouse.Service;

namespace Warehouse.api.Controllers
{
    [Route("api/wareHouse-item")]
    [ApiController]
    public class WareHouseItemController : ControllerBase
    {
        #region Fields

        private readonly IWareHouseItemService _wareHouseItemService;

        public WareHouseItemController(IWareHouseItemService wareHouseItemService)
        {
            _wareHouseItemService = wareHouseItemService;
        }

        #endregion Fields

        #region List

        [Route("get-by-id-unit")]
        [HttpGet]
        public async Task<IActionResult> GetByIdUnit(string id)
        {
            var entity = await _wareHouseItemService.GetByIdUnitAsync(id);
            if (entity == null)
                NotFound(new ApiNotFoundResponse($"WareHouseItem with id: {id} is not found"));

            return Ok(entity);
        }

        [Route("get-available")]
        [HttpGet]
        public async Task<IActionResult> GetAvailableList(bool showHidden = true)
        {
            var user = _wareHouseItemService.GetMvcListItems(showHidden);
            return Ok(user);
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _wareHouseItemService.GetByIdAsyn(id);
            return Ok(user);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _wareHouseItemService.GetAll());
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetWareHouseItemPagingRequest request)
        {
            var products = await _wareHouseItemService.GetAllPaging(request);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var item = await _wareHouseItemService.GetById(id);

            if (item == null)
            {
                return NotFound(new ApiNotFoundResponse($"WareHouseItem with id: {id} is not found"));
            }

            return Ok(item);
        }

        [Route("get-by-whItem-unit-id")]
        [HttpGet]
        public async Task<IActionResult> GetByWHItemUnitId(string id)
        {
            var product = await _wareHouseItemService.GetByWHItemUnitId(id);
            if (product == null)
                return BadRequest("Cannot find warehouseitemunit");
            return Ok(product);
        }

        #endregion List

        #region Method

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] WareHouseItemModel model)
        {
            var result = await _wareHouseItemService.Create(model);

            if (result.Result > 0)
            {
                return RedirectToAction(nameof(Get), new { id = result.Id });
            }
            else
            {
                return BadRequest(new ApiBadRequestResponse("Create WareHouseItem failed"));
            }
        }

        [Route("edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var entity = await _wareHouseItemService.GetById(id);
            if (entity == null)
            {
                return NotFound(new ApiNotFoundResponse($"WareHouseItem with id: {id} is not found"));
            }

            return Ok(entity);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put([FromBody] WareHouseItemModel model, string id)
        {
            var item = await _wareHouseItemService.GetByWHItemUnitId(id);
            if (item == null)
                return NotFound(new ApiNotFoundResponse($"WareHouseItem with id: {id} is not found"));

            var result = await _wareHouseItemService.Update(id, model);

            if (result.Result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new ApiBadRequestResponse("Update WareHouseItem failed"));
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _wareHouseItemService.Delete(id);
            return Ok(result);
        }

        #endregion Method
    }
}
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Warehouse.Common;
using Warehouse.Model.Unit;
using Warehouse.Service;

namespace Warehouse.api.Controllers
{
    [Route("api/unit")]
    [ApiController]
    [Authorize("Bearer")]
    public class UnitController : ControllerBase
    {
        #region Fields

        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        #endregion Fields

        #region List

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _unitService.GetByIdAsyn(id);
            return Ok(user);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _unitService.GetAll());
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUnitPagingRequest request)
        {
            var products = await _unitService.GetAllPaging(request);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var item = await _unitService.GetById(id);

            if (item == null)
            {
                return NotFound(new ApiNotFoundResponse($"Unit with id: {id} is not found"));
            }

            return Ok(item);
        }

        [Route("get-available")]
        [HttpGet]
        public async Task<IActionResult> GetAvailableList(bool showHidden = true)
        {
            var user = _unitService.GetMvcListItems(showHidden);
            return Ok(user);
        }

        #endregion List

        #region Method

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] UnitModel model)
        {
            var result = await _unitService.Create(model);

            if (result.Result > 0)
            {
                return RedirectToAction(nameof(Get), new { id = result.Id });
            }
            else
            {
                return BadRequest(new ApiBadRequestResponse("Create unit failed"));
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put([FromBody] UnitModel model, string id)
        {
            var item = await _unitService.GetById(id);
            if (item == null)
                return NotFound(new ApiNotFoundResponse($"Unit with id: {id} is not found"));

            var result = await _unitService.Update(id, model);

            if (result.Result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new ApiBadRequestResponse("Update unit failed"));
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string unitId)
        {
            var result = await _unitService.Delete(unitId);
            return Ok(result);
        }

        #endregion Method
    }
}
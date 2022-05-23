﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Warehouse.Model.SerialWareHouse;

namespace Warehouse.Model.InwardDetail
{
    public class InwardDetailModel
    {
        public  string? Id { get; set; }
        public string? InwardId { get; set; }
        public string ItemId { get; set; }
        public string UnitId { get; set; }
        public decimal? Uiquantity { get; set; }
        public decimal? Uiprice { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? StationId { get; set; }
        public string? StationName { get; set; }
        public string? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? AccountMore { get; set; }
        public string? AccountYes { get; set; }
        public string ?Status { get; set; }

        public  string? AccObjectId { get; set; }
        public string? Serial { get; set; }

        public IList<SelectListItem>? AvailableItem { get; set; }
        public IList<SelectListItem>? AvailableUnit { get; set; }
        public IEnumerable<SerialWareHouselModel>? SerialWareHouses { get; set; }
    }
}
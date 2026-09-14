using System;

namespace WMS.Frontend.Models;

public class BreadcrumbLink
    {
        public int OrderIndex { get; set; }
        public required string Address { get; set; }
        public required string Title { get; set; }
        public bool IsActive { get; set; }
    }
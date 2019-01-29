using System;

namespace Celia.io.Core.MicroServices.Utilities
{
    public class PaginationResult<T>
    {
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public T[] Items { get; set; }
    }
}

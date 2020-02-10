using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace His6.Base
{
    public  class PageInfo
    {
        [JsonProperty("endRow")]
        public long EndRow { get; set; }

        [JsonProperty("firstPage")]
        public long FirstPage { get; set; }

        [JsonProperty("hasNextPage")]
        public bool HasNextPage { get; set; }

        [JsonProperty("hasPreviousPage")]
        public bool HasPreviousPage { get; set; }

        [JsonProperty("isFirstPage")]
        public bool IsFirstPage { get; set; }

        [JsonProperty("isLastPage")]
        public bool IsLastPage { get; set; }

        [JsonProperty("lastPage")]
        public long LastPage { get; set; }

        [JsonProperty("navigateFirstPage")]
        public long NavigateFirstPage { get; set; }

        [JsonProperty("navigateLastPage")]
        public long NavigateLastPage { get; set; }

        [JsonProperty("navigatePages")]
        public long NavigatePages { get; set; }

        public long[] NavigatepageNums { get; set; }

        [JsonProperty("nextPage")]
        public long NextPage { get; set; }

        [JsonProperty("pageNum")]
        public long PageNum { get; set; }

        [JsonProperty("pageSize")]
        public long PageSize { get; set; }

        [JsonProperty("pages")]
        public long Pages { get; set; }

        [JsonProperty("prePage")]
        public long PrePage { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("startRow")]
        public long StartRow { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}

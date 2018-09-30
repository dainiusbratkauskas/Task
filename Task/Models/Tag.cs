using System.Collections.Generic;
using Task.Models.Enums;

namespace Task.Models
{
    public abstract class Tag
    {
        public BannerTypes BannerType { get; }
        public abstract TagFormats TagFormat { get; set; }
        public abstract ServingMethods ServingMethod { get; set; }
        public virtual List<string> ImpressionPixels { get; set; }

        protected Tag(BannerTypes bannerType)
        {
            BannerType = bannerType;
        }
        
        protected Tag(BannerTypes bannerType, TagFormats tagFormat, ServingMethods servingMethod, List<string> impressionPixels = null)
        {
            BannerType = bannerType;
            TagFormat = tagFormat;
            ServingMethod = servingMethod;
            ImpressionPixels = impressionPixels;
        }
        
    }
}
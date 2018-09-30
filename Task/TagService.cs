using System.Collections.Generic;
using Task.Models;
using Task.Models.Enums;

namespace Task
{
    public static class TagService
    {

        public static Tag CreateTag(BannerTypes bannerType, TagFormats tagFormat, ServingMethods servingMethod,
            List<string> impressionPixels = null)
        {
            var tag = TagFactory.InitializeTag(bannerType);
            tag.TagFormat = tagFormat;
            tag.ServingMethod = servingMethod;
            tag.ImpressionPixels = impressionPixels;
            return tag;
        }
        
        public static Tag SetTag(Tag tag, BannerTypes bannerType, TagFormats tagFormat, ServingMethods servingMethod, List<string> impressionPixels = null)
        {
            if (tag.BannerType != bannerType)
            {
                tag = TagFactory.InitializeTag(bannerType);
            }
            tag.TagFormat = tagFormat;
            tag.ServingMethod = servingMethod;
            tag.ImpressionPixels = impressionPixels;

            return tag;
        }          
    }
}
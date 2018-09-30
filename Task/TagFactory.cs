using System;
using Task.Models;
using Task.Models.Enums;

namespace Task
{
    public static class TagFactory
    {
        public static Tag InitializeTag(BannerTypes bannerType)
        {
            switch (bannerType)
            {
                case BannerTypes.Html:
                    return new Html(BannerTypes.Html);
                case BannerTypes.Image:
                    return new Image(BannerTypes.Image);
                case BannerTypes.Video:
                    return new Video(BannerTypes.Video);
                case BannerTypes.Keyword:
                    return new Keyword(BannerTypes.Keyword);
                default:
                    throw new NotSupportedException("Banner type is not valid.");
            }
        }
    }
}
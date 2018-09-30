using System;
using System.Collections.Generic;
using Task.Models.Enums;

namespace Task.Models
{
    public sealed class Html : Tag
    {
        private TagFormats _tagFormat;
        private ServingMethods _servingMethod;

        public Html(BannerTypes bannerType) : base(bannerType)
        {
        }

        public Html(BannerTypes bannerType, TagFormats tagFormat, ServingMethods servingMethod,
            List<string> impressionPixels = null) :
            base(bannerType, tagFormat, servingMethod, impressionPixels)
        {
        }

        public override TagFormats TagFormat
        {
            get => _tagFormat;
            set
            {
                if (value == TagFormats.JavaScriptDefault ||
                    value == TagFormats.Iframe)
                {
                    _tagFormat = value;
                }
                else
                {
                    throw new Exception("This tag format is not valid for this banner type.");
                }
            }
        }

        public override ServingMethods ServingMethod
        {
            get => _servingMethod;
            set
            {
                if (value == ServingMethods.Impressions ||
                    value == ServingMethods.Clicks)
                {
                    _servingMethod = value;
                }
                else
                {
                    throw new Exception("This serving method is not valid for this banner type.");
                }
            }
        }
    }
}
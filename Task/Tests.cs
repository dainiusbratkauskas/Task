using System;
using System.Collections.Generic;
using Task.Models;
using Task.Models.Enums;
using Xunit;

namespace Task
{
    public class Tests
    {
        [Fact]
        public void CreateValidTag()
        {
            const BannerTypes bannerType = BannerTypes.Html;
            const TagFormats tagFormat = TagFormats.Iframe;
            const ServingMethods servingMethod = ServingMethods.Impressions;

            var newTag = TagService.CreateTag(bannerType, tagFormat, servingMethod);

            Assert.Equal(bannerType, newTag.BannerType);
            Assert.Equal(servingMethod, newTag.ServingMethod);
            Assert.Equal(tagFormat, newTag.TagFormat);
        }

        [Fact]
        public void CreateTagWithInvalidSettings()
        {
            const BannerTypes bannerType = BannerTypes.Video;
            const TagFormats tagFormat = TagFormats.JavaScriptDefault;
            const ServingMethods servingMethod = ServingMethods.Clicks;

            var ex = Assert.Throws<Exception>(() => TagService.CreateTag(bannerType, tagFormat, servingMethod));

            Assert.Equal("This tag format is not valid for this banner type.", ex.Message);
        }

        [Fact]
        public void EditValidTagSettings()
        {
            const BannerTypes bannerType = BannerTypes.Image;
            const TagFormats tagFormat = TagFormats.JavaScriptDefault;
            const ServingMethods servingMethod = ServingMethods.Clicks;

            var tag = new Image(bannerType, TagFormats.Iframe, ServingMethods.Impressions);
            var updatedTag = TagService.SetTag(tag, bannerType, tagFormat, servingMethod);

            Assert.Equal(bannerType, updatedTag.BannerType);
            Assert.Equal(servingMethod, updatedTag.ServingMethod);
            Assert.Equal(tagFormat, updatedTag.TagFormat);
        }

        [Fact]
        public void EditValidTagType()
        {
            const BannerTypes bannerType = BannerTypes.Html;
            const TagFormats tagFormat = TagFormats.JavaScriptDefault;
            const ServingMethods servingMethod = ServingMethods.Clicks;

            var imageTag = new Image(BannerTypes.Image, TagFormats.Iframe, ServingMethods.Impressions);

            var tag = TagService.SetTag(imageTag, bannerType, tagFormat, servingMethod);

            Assert.Equal(bannerType, tag.BannerType);
            Assert.Equal(servingMethod, tag.ServingMethod);
            Assert.Equal(BannerTypes.Html, BannerTypes.Html);
        }

        [Fact]
        public void EditTagWithInvalidSettings()
        {
            const BannerTypes bannerType = BannerTypes.Video;
            const TagFormats tagFormat = TagFormats.UrlToXml;
            const ServingMethods servingMethod = ServingMethods.Impressions;

            var videoTag = new Video(BannerTypes.Video, TagFormats.UrlToXml, ServingMethods.Xml);

            var ex = Assert.Throws<Exception>(() => TagService.SetTag(videoTag, bannerType, tagFormat, servingMethod));
            Assert.Equal("This serving method is not valid for this banner type.", ex.Message);
        }

        [Fact]
        public void AddImpressionPixels()
        {
            var impressionPixels = new List<string> {"5, 6", "8, 10"};
            var htmlTag = new Html(BannerTypes.Html, TagFormats.Iframe, ServingMethods.Clicks);

            var tag = TagService.SetTag(htmlTag, BannerTypes.Html, htmlTag.TagFormat, htmlTag.ServingMethod,
                impressionPixels);

            Assert.Equal(impressionPixels, tag.ImpressionPixels);
        }

        [Fact]
        public void RemoveImpressionPixels()
        {
            var htmlTag = new Html(BannerTypes.Html, TagFormats.Iframe, ServingMethods.Clicks);

            var tag = TagService.SetTag(htmlTag, htmlTag.BannerType, htmlTag.TagFormat, htmlTag.ServingMethod);

            Assert.Null(tag.ImpressionPixels);
        }

        [Fact]
        public void ChangeBannerImpressionPixelsThatDoesNotSupportIt()
        {
            var impressionPixels = new List<string> {"5, 6", "8, 10"};

            var tag = new Keyword(BannerTypes.Keyword, TagFormats.Iframe, ServingMethods.Clicks);

            var ex = Assert.Throws<Exception>(() =>
                TagService.SetTag(tag, tag.BannerType, tag.TagFormat, tag.ServingMethod, impressionPixels));
            Assert.Equal("This banner type does not supports impression pixels.", ex.Message);
        }
    }
}
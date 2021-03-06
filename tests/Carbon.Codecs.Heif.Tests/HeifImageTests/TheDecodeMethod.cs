﻿// Copyright (c) Carbon and contributors.
// Licensed under the MIT License.

using Xunit;

namespace Carbon.Codecs.Heif.Tests
{
    public partial class HeifImageTests
    {
        public class TheDecodeMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenFileIsInvalid()
            {
                var data = new byte[] { 42 };

                var exception = Assert.Throws<HeifException>(() => HeifImage.Decode(data));

                Assert.Equal("Unable to create heif context.", exception.Message);
            }

            [Fact]
            public void ShouldLoadTheMetadata()
            {
                using (var image = HeifImage.Decode(TestFiles.Camel))
                {
                    Assert.Equal(1596, image.Metadata.Width);
                    Assert.Equal(1064, image.Metadata.Height);
                }
            }

            [Fact]
            public void ShouldBeAbleToDecodeAvifFile()
            {
                using (var image = HeifImage.Decode(TestFiles.Bbb_4k))
                {
                    Assert.Equal(3840, image.Metadata.Width);
                    Assert.Equal(2160, image.Metadata.Height);
                }
            }
        }
    }
}

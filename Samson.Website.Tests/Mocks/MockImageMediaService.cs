using System;
using Samson.Services;
using Samson.Standard.MediaTypes;

namespace Samson.Website.Tests.Mocks
{
    public class MockImageMediaService : IStrongMediaService
    {
        public T GetMediaItem<T>(int id) where T : class, MediaTypes.IBasicMediaItem
        {
            return new Image
            {
                CreateDate = DateTime.MaxValue,
                Name = "Test",
                Id = 1
            } as T;
        }

        public MediaTypes.IBasicMediaItem GetMediaItem(int id)
        {
            return new Image
            {
                CreateDate = DateTime.MaxValue,
                Name = "Test",
                Id = 1
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Services;
using Samson.Standard.DocumentTypes;

namespace Samson.Website.Tests.Mocks
{
    public class MockWebsiteContentService : IStrongContentService
    {
        public IEnumerable<T> GetChildNodes<T>(int parentId) where T : class, DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentTypes.IBasicContentItem> GetChildNodes(int parentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildNodes<T>(DocumentTypes.IBasicContentItem parent) where T : class, DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentTypes.IBasicContentItem> GetChildNodes(DocumentTypes.IBasicContentItem parent)
        {
            throw new NotImplementedException();
        }

        public T GetCurrentNode<T>() where T : class, DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public DocumentTypes.IBasicContentItem GetCurrentNode()
        {
            throw new NotImplementedException();
        }

        public T GetNodeById<T>(int nodeId) where T : class, DocumentTypes.IBasicContentItem
        {
            return new Samson.Model.DocumentTypes.Website { Id = 1, LogoId = 1 } as T;
        }

        public DocumentTypes.IBasicContentItem GetNodeById(int nodeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetNodesByIds<T>(IEnumerable<int> ids) where T : class, DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentTypes.IBasicContentItem> GetNodesByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public T GetParent<T>(int childId) where T : class, DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public DocumentTypes.IBasicContentItem GetParent(int childId)
        {
            throw new NotImplementedException();
        }

        public T GetParent<T>(DocumentTypes.IBasicContentItem child) where T : class, DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public DocumentTypes.IBasicContentItem GetParent(DocumentTypes.IBasicContentItem child)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentTypes.IBasicContentItem> GetRootNodes()
        {
            return new List<DocumentTypes.IBasicContentItem> 
            { 
                new BasicContentItem { Id = 1 }
            };

        }


        public IEnumerable<T> GetDescendantNodes<T>(int parentId) where T : class, DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentTypes.IBasicContentItem> GetDescendantNodes(int parentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetDescendantNodes<T>(DocumentTypes.IBasicContentItem parent) where T : class, DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentTypes.IBasicContentItem> GetDescendantNodes(DocumentTypes.IBasicContentItem parent)
        {
            throw new NotImplementedException();
        }
    }
}

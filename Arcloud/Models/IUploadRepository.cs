using System.Collections.Generic;

namespace Arcloud.Models
{
    public interface IUploadRepository
    {
        public IEnumerable<Upload> AllUploads { get; }

        void AddUpload(Upload upload) { }
    }
}

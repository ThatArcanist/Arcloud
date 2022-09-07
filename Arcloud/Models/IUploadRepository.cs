using System.Collections.Generic;

namespace Arcloud.Models
{
    public class IUploadRepository
    {
        public IEnumerable<Upload> AllUploads { get; }
    }
}

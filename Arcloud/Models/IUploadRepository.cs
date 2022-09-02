using System.Collections.Generic;

namespace Arcloud.Models
{
    public class IUploadRepository
    {
        IEnumerable<Upload> AllUploads { get; }
    }
}

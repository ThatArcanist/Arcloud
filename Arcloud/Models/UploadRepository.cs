using System.Collections.Generic;

namespace Arcloud.Models
{
    public class UploadRepository: IUploadRepository
    {
        private readonly AppDbContext appDbContext;

        public UploadRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Upload> AllUploads => appDbContext.Uploads;

        public void AddUpload(Upload upload)
        {
            appDbContext.Uploads.Add(upload);
            appDbContext.SaveChanges();
        }
    }
}

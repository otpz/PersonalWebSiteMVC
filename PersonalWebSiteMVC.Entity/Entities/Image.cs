using PersonalWebSiteMVC.Core.Entities;

namespace PersonalWebSiteMVC.Entity.Entities
{
    public class Image : EntityBase
    {
        public Image()
        {

        }
        public Image(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}

namespace Generate_Image.Models
{
    public class ImageInfo
    {
        public string? ImageText
        {
            get;
            set;
        }
        
    }
    public class RequiredImage
    {
        public string? prompt
        {
            get;
            set;
        }
        public short? n
        {
            get;
            set;
        }
    }
    public class ImageUrls
    {
        public string? url
        {
            get;
            set;
        }
    }
    public class ResponseModel
    {
        public long created
        {
            get;
            set;
        }
        public List<ImageUrls> ? data
        {
            get;
            set;
        }
    }
}

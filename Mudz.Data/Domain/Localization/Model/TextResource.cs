namespace Mudz.Data.Domain.Localization.Model
{
    public class TextResource
    {
        public string Culture { get; set; }
        public TextResourceNames TextResourceName { get; set; }
        public string Content { get; set; }
    }
}

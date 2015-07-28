namespace Mudz.Data.Domain.Localization.Model
{
    public class TextResource
    {
        public string Culture { get; set; }
        public TextResourceName TextResourceName { get; set; }
        public string Content { get; set; }
    }
}

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class DocumentationAttribute : Attribute
    {
        public DocumentationAttribute(string moreInfo)
        {
            MoreInfo = moreInfo;
        }

        public string MoreInfo { get; set; }
    }
}

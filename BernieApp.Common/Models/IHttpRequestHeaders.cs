namespace BernieApp.Common.Models
{
    public interface IHttpRequestHeaders
    {
        void Clear();
        void Add(string name, string value);
    }
}

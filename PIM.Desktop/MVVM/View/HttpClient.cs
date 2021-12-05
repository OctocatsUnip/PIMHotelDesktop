using System;

namespace PIM.Desktop
{
    internal class HttpClient
    {
        public Uri BaseAddress { get; internal set; }
        public object DefaultRequestHeaders { get; internal set; }

        internal object GetStringAsync(string v)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace NormalApi.filters
{
    public class JsonpMediaFormatter : JsonMediaTypeFormatter
    {
        private string callback;

        public JsonpMediaFormatter(string cal = null)
        {
            this.callback = cal;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            if (string.IsNullOrEmpty(callback))
            {
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
            try
            {
                return Task.Run(() =>
                {
                    this.WriteToStream(type, value, writeStream, content);
                }
                    );
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
        {
            if (request.Method != HttpMethod.Get)
            {
                return this;
            }
            string callback;
            if (
                request.GetQueryNameValuePairs()
                    .ToDictionary(pair => pair.Key, pair => pair.Value)
                    .TryGetValue("callback", out callback))
            {
                return new JsonpMediaFormatter(callback);
            }
            return this;
        }

        private void WriteToStream(Type type, object value, Stream writestream, HttpContent content)
        {
            JsonSerializer serializer = JsonSerializer.Create(this.SerializerSettings);
            using (StreamWriter writer = new StreamWriter(writestream, this.SupportedEncodings.First()))
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(writer) { CloseOutput = false })
                {
                    jsonTextWriter.WriteRaw(this.callback + "(");
                    serializer.Serialize(jsonTextWriter, value);
                    jsonTextWriter.WriteRaw(")");
                }
            }

        }
    }
}
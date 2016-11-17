using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;

namespace AstonEcole.Api.Infrastructure
{
    public class CsvMediaTypeFormatter<T> : BufferedMediaTypeFormatter
        where T : class
    {
        public CsvMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(T))
            {
                return true;
            }
            else
            {
                Type enumerableType = typeof(IEnumerable<T>);
                return enumerableType.IsAssignableFrom(type);
            }
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                var listeOfT = value as IEnumerable<T>;
                if (listeOfT != null)
                {
                    WriteHeader(writer);
                    foreach (T t in listeOfT)
                    {
                        WriteItem(t, writer);
                    }
                }
                else
                {
                    var singleT = value as T;
                    if (singleT == null)
                    {
                        throw new InvalidOperationException("Type non sérializable");
                    }

                    WriteHeader(writer);
                    WriteItem(singleT, writer);
                }
            }
        }

        private void WriteHeader(StreamWriter writer)
        {
            var properties = typeof(T).GetProperties().ToList();
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType.IsValueType || p.PropertyType == typeof(string))
                {
                    writer.Write(p.Name);
                    writer.Write("\t");
                }
            }

            writer.WriteLine();
        }

        // Helper methods for serializing Products to CSV format. 
        private void WriteItem(T singleT, StreamWriter writer)
        {
            var properties = singleT.GetType().GetProperties().ToList();
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType.IsValueType || p.PropertyType == typeof(string))
                {
                    writer.Write(Escape(p.GetValue(singleT)));
                    writer.Write("\t");
                }
            }

            writer.WriteLine();
        }

        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };

        private string Escape(object o)
        {
            if (o == null)
            {
                return string.Empty;
            }

            string field = o.ToString();
            if (field.IndexOfAny(_specialChars) != -1)
            {
                // Delimit the entire field with quotes and replace embedded quotes with "".
                return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
            }
            else
            {
                return field;
            }
        }
    }
}
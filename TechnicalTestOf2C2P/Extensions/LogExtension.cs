using System;

namespace TechnicalTestOf2C2P.Extensions
{
    public static class LogExtension
    {
        public static void WriteLog(string message)
        {
            DateTime date = DateTime.Now;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            string fileName = date.ToString("yyyy-MM-dd") + "_logs.log";
            string filePath = Path.Combine(path, fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    string details = string.Join(", ", LogMessage.Get().Select(s => $"\"{s}\""));
                    string request = LogRequest.Get().Replace("\"", "\'").Replace("\r\n", ",");
                    writer.WriteLine($"{date} {{\"Message\": \"{message}\", \"Details\": [{details}], \"Request\": \"{request}\"}}");
                    writer.Flush();
                    LogRequest.Clear();
                    LogMessage.Clear();
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    string details = string.Join(", ", LogMessage.Get().Select(s => $"\"{s}\""));
                    string request = LogRequest.Get().Replace("\"", "\'").Replace("\r\n", ",");
                    writer.WriteLine($"{date} {{\"Message\": \"{message}\", \"Details\": [{details}], \"Request\": \"{request}\"}}");
                    writer.Flush();
                    LogRequest.Clear();
                    LogMessage.Clear();
                }
            }
        }
    }

    public static class LogMessage
    {
        private static List<string> messages = new List<string>();

        public static void Add(string message) 
        {
            messages.Add(message);
        }

        public static void AddRange(List<string> message)
        {
            messages.AddRange(message);
        }

        public static List<string> Get()
        {
            return messages;
        }

        public static void Clear()
        {
            messages = new List<string>();
        }
    }

    public static class LogRequest
    {
        private static string request = string.Empty;

        public static void Add(string req)
        {
            request = req;
        }

        public static string Get()
        {
            return request;
        }

        public static void Clear()
        {
            request = string.Empty;
        }
    }
}

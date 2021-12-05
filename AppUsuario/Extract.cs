using System;
using System.IO;

namespace F5
{
    public static class Extract
    {
        public static byte[] Run(String path)
        {
            MemoryStream ms = new MemoryStream();
            JpegExtract extractor = new JpegExtract(ms, "h$-aZ+crufe@L0$9*wi3");
            Stream s = extractor.Extract(File.OpenRead(path));
            if (s != null)
            {
                s.Position = 0;
                MemoryStream bytes = new MemoryStream();
                s.CopyTo(bytes);
                byte[] texto = bytes.ToArray();
                bytes.Dispose();
                bytes.Close();
                //StreamReader sr = new StreamReader(s);
                //String texto = sr.ReadToEnd();
                //sr.Dispose();
                //sr.Close();
                s.Dispose();
                s.Close();
                ms.Dispose();
                ms.Close();
                return texto;
            }
            return null;
        }
    }
}

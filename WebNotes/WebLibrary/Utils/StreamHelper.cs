using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary.Utils
{
  public static class StreamHelper
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            using (stream)
            {
                using (var memStream = new MemoryStream())
                {
                    stream.CopyTo(memStream);
                    return memStream.ToArray();
                }
            }
        }
    }
}

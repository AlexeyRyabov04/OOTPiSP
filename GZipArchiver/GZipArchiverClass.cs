using System.IO.Compression;

namespace GZipArchiver
{
    public class GZipArchiverClass : Object_Editor.IArchiver
    {
        public string getExtension() { return ".gz"; }
        public void Compress(FileStream fs, MemoryStream ms)
        {
            ms.Position = 0;
            fs.Position = 0;
            fs.SetLength(0);
            using (GZipStream s = new GZipStream(fs, CompressionMode.Compress, true))
                ms.CopyTo(s);
        }
        public void Decompress(FileStream fs, MemoryStream ms)
        {
            fs.Position = 0;
            ms.Position = 0;
            using (GZipStream decompressStream = new GZipStream(fs, CompressionMode.Decompress, true))
                decompressStream.CopyTo(ms);
            ms.Position = 0;
        }
    }
}
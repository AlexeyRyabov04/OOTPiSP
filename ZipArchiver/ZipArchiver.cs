using System.IO.Compression;
namespace ZipArchiver
{
    public class ZipArchiver : Object_Editor.IArchiver
    {
        public string getExtension() { return ".zip"; }
        public void Compress(FileStream fs, MemoryStream ms)
        {
            string fileName = Path.GetFileName(fs.Name.Replace(".zip", ""));
            fs.Position = 0;
            fs.SetLength(0);
            ms.Position = 0;
            using var zipArchive = new ZipArchive(fs, ZipArchiveMode.Create);
            var entry = zipArchive.CreateEntry(fileName);
            using var entryStream = entry.Open();
            ms.CopyTo(entryStream);
        }
        public void Decompress(FileStream fs, MemoryStream ms)
        {
            using var zipArchive = new ZipArchive(fs, ZipArchiveMode.Read, true);
            using (var entryStream = zipArchive.Entries[0].Open())
                entryStream.CopyTo(ms);
            ms.Position = 0;
        }
    }
}
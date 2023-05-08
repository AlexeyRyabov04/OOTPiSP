namespace Object_Editor
{
    public interface IArchiver
    {
        string getExtension();
        void Compress(FileStream fs, MemoryStream ms);
        void Decompress(FileStream fs, MemoryStream ms);
    }
}

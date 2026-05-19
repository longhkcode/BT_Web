namespace Media_Proccesor;

public class audioFile : mediaFile,ICompressible
{
    private String bitrate { get; set; }

    public audioFile(string fileName, double fileSizeMB, string bitrate) : base(fileName, fileSizeMB)
    {
        this.bitrate = bitrate;
    }

    public override void ConvertFormat(string newExtension)
    {
        Console.WriteLine("Đang mix lại luồng âm thanh...");
    }

    public void Compress()
    {
        Console.WriteLine("Dang nen audio");
    }
}
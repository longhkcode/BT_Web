namespace Media_Proccesor;

public class videoFile : mediaFile,ICompressible
{
    private String resolution{get; set;}

    public videoFile(string fileName, double fileSizeMB, string resolution) : base(fileName, fileSizeMB)
    {
        this.resolution = resolution;
    }

    public override void ConvertFormat(string newExtension)
    {
        Console.WriteLine("Đang re-render video...");
    }

    public void Compress()
    {
        Console.WriteLine("Dang nen vid");
    }
}
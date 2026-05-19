namespace Media_Proccesor;

public abstract class mediaFile
{
    private String fileName { get; set; }
    private double fileSizeMB{get; set;}

    public mediaFile(String fileName, double fileSizeMB)
    {
        this.fileName = fileName;
        this.fileSizeMB = fileSizeMB;
    }

    public String PrintInfo()
    {
        return fileName + ": " + fileSizeMB;
    }
    public abstract void ConvertFormat(string newExtension);
}
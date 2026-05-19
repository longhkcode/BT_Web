namespace Media_Proccesor;

public class ProcessingQueue
{
    private List<mediaFile> files = new List<mediaFile>();

    public void addFile(mediaFile file)
    {
        files.Add(file);
    }
    public void  removeFile(mediaFile file)
    {
        files.Remove(file);
    }

    public void showFiles()
    {
        if(files.Count == 0) Console.WriteLine("No files found");
        foreach (mediaFile mf in files)
        {
            mf.PrintInfo();
        }
    }
}
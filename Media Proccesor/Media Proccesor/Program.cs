class Program
{
    static string[] fileNames = new string[10];
    static string[] extensions = new string[10];
    public static void Main(string[] args)
    {
        
        Console.WriteLine("=== HỆ THỐNG QUẢN LÝ FILE MEDIA ===\nThêm file vào hàng đợi\nXem danh sách hàng đợi\nBắt đầu xử lý (Nén & Chuyển đổi)\nThoát chương trình Chọn chức năng (1-4):\n");
        int n = Convert.ToInt32(Console.ReadLine());
        switch (n)
        {
            case 1:
                Console.WriteLine("Thêm file vào hàng đợi");
                break;
            case 2:
                Console.WriteLine("Xem danh sách hàng đợi");
                break;
            case 3: 
                Console.WriteLine("Bắt đầu xử lý (Nén & Chuyển đổi)");
                break;
            case 4: 
                Console.WriteLine("Thoát chương trình Chọn chức năng (1-4): _");
                break;
            default:
                Console.WriteLine("Moi ban nhap lai : ");
                n = Convert.ToInt32(Console.ReadLine());
                break;
        }
    }
    
    static bool CheckValidExtension(string ext)
    {
        string[] duoi = { ".mp4", ".avi", ".mp3", ".wav" };
        for (int i = 0; i < duoi.Length; i++)
        {
            if (ext.ToLower() == duoi[i])
            {
                return true;
            }
        }
        return false;
    }
    
    static double EstimateSize(double currentSize)
    {
        Random random = new Random();
        int percent = random.Next(10, 41);
        double newSize = currentSize * (100 - percent) / 100;
        return newSize;
    }
    static void ShowFiles()
    {
        Console.WriteLine("\n===== DANH SÁCH FILE =====");
        for (int i = 0; i < fileNames.Length; i++)
        {
            Console.WriteLine(fileNames);
        }
    }
}
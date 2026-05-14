class MineSweeper
{
    static int size = 10;
    static int totalMines = 10;
    static bool[,] mines = new bool[size, size];
    static char[,] displayBoard = new char[size, size];  // hiển th màn hình
    static bool[,] revealed = new bool[size, size]; // theo dõi xem mở chưa

    static void createBoard()    // hàm tạo bảng 
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                displayBoard[i, j] = '■';
            }
        }
    }
    static void PlaceMines()
    {
        Random random = new Random();
        int totalCells = size * size; 
        int totalMines = 10; 
        
        bool[] n = new bool[totalCells];
        
        for (int i = 0; i < totalMines; i++) 
        {
            n[i] = true;
        }
        
        for (int i = 0; i < totalCells - 1; i++)
        {
            int pos = random.Next(i, totalCells); 
            bool save = n[i];
            n[i] = n[pos];
            n[pos] = save;
        }
        
        int index = 0;
        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                mines[r, c] = n[index++];
            }
        }
    }   //hàm phân bố mìn

    static void RevealCell(int r,int c)  // hàm mở ô sử dụng đệ quy để mở loang gặp cell số 0
    {
        if(r<0 || r >= size || c<0 || c >= size || revealed[r, c]) return;
        revealed[r, c] = true; // đã đc mở
        int count = countMinesAround(r, c);
        displayBoard[r, c] = count.ToString()[0];   // chuyển int sang kiểu char
        if (count == 0)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    RevealCell(r+i,c+j);  // mở loang ra
                }
            }
        }
        
    }

    static int countMinesAround(int r, int c)  // ham in ra số lượng bomb xung quanh điểm tọa độ [r,c]
    {
        int count = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int nr = r + i;
                int nc = c + j;
                if (nr >= 0 && nr < size &&  nc >= 0 && nc < size && mines[nr,nc]) count++;
            }
        }
        return count;
    }

    static bool checkWin()
    {
        int countReveal = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (revealed[i, j]) countReveal++;
            }
        }
        return countReveal == (size*size - totalMines);
    }   // ktra khi nào số ô đã mở = tổng số ô an toanf

    static void drawBoard(bool showMines = false)
    {
        Console.Clear();
        Console.WriteLine("BẢN ĐỒ DÒ MÌN");
        Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine("  ----------");
        for (int i = 0; i < size; i++)
        {
            Console.Write(i + "| ");
            for (int j = 0; j < size; j++)
            {
                if (showMines == true && mines[i, j])
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(displayBoard[i, j] + " ");
                }
            }
            Console.WriteLine() ;
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        createBoard();
        PlaceMines();
        bool gameOver = false;
        while (!gameOver)
        {
            drawBoard();
            Console.WriteLine("Số mìn trong bảng là : " + totalMines);
            Console.WriteLine("Chọn 1 [hàng] [cột] để mở ô");
            Console.WriteLine("Chọn 2 [hàng] [cột] để gắn cờ Flag");
            Console.WriteLine("Nhập Lệnh : ");
            String inputS = Console.ReadLine();
            if(string.IsNullOrEmpty(inputS))continue;
            String[] input = inputS.Split(' ');
            if (input.Length < 3) continue;
            // Xử lý nhập liệu
            if (!int.TryParse(input[0], out int action) || 
                !int.TryParse(input[1], out int r) || 
                !int.TryParse(input[2], out int c)) continue;
            if (r < 0 || r >= size || c < 0 || c >= size)
            {
                Console.WriteLine("Tọa độ nằm ngoài phạm vi!");
                continue;
            }

            if (action == 2)
            {
                if (!revealed[r, c])
                {
                    displayBoard[r, c] = (displayBoard[r,c] == 'F')? '■' :'F';
                }
            }
            else if(action == 1)
            {
                if (mines[r, c])
                {
                    drawBoard(true);
                    Console.WriteLine("Game Over");
                    gameOver = true;
                }
                else
                {
                    RevealCell(r, c);
                    if (checkWin())
                    {
                        drawBoard(true);
                        Console.WriteLine("Game Win");
                        gameOver = true;
                    }
                }
            }
        }
        Console.ReadLine();
    }
}
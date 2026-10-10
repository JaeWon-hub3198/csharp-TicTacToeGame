using System;

bool gameStart = true;

const int TicTacToe = 9;
const int ColumCount = 3;

int[] board = new int[TicTacToe];
bool[] matched = new bool[TicTacToe];

int player = 1;
int count = 0;

while (gameStart)
{
    Title();
    DisPlayBoard(board, matched);

    string choiceName = player == 1 ? "X" : "O";

    int index = ReadBoardIndex(choiceName, matched);

    board[index] = player;
    matched[index] = true;
    count++;

    // 가로 3줄이 동일시 승리
    if (board[0] == player && board[1] == player && board[2] == player ||
        board[3] == player && board[4] == player && board[5] == player ||
        board[6] == player && board[7] == player && board[8] == player)
    {
        DisPlayBoard(board, matched);
        Console.WriteLine($"플레이어 {choiceName} 승리!");
        break;
    }

    // 세로 3줄이 동일시 승리
    if (board[0] == player && board[3] == player && board[6] == player ||
        board[1] == player && board[4] == player && board[7] == player ||
        board[2] == player && board[5] == player && board[8] == player)
    {
        DisPlayBoard(board, matched);
        Console.WriteLine($"플레이어 {choiceName} 승리!");
        break;
    }

    // 대각선 3줄이 동일시 승리
    if (board[0] == player && board[4] == player && board[8] == player ||
        board[2] == player && board[4] == player && board[6] == player)
    {
        DisPlayBoard(board, matched);
        Console.WriteLine($"플레이어 {choiceName} 승리!");
        break;
    }

    if (count == TicTacToe)
    {
        DisPlayBoard(board, matched);
        Console.WriteLine("무승부입니다.");
        break;
    }

    if (player == 1)
    {
        player = 2;
    }
    else
    {
        player = 1;
    }
}
WaitForEnter();

void WaitForEnter()
{
    Console.WriteLine("게임을 종료하시려면 Enter를 눌러주세요.");
    Console.ReadLine();
}

int ReadBoardIndex(string choiceName, bool[] matched)
{
    while (true)
    {
        Console.WriteLine($"플레이어 {choiceName}의 차례입니다.");
        Console.Write("위치를 선택하세요 (1~9): ");

        if (!int.TryParse(Console.ReadLine(), out int input))
        {
            Console.WriteLine("숫자를 입력하세요.");
            continue;
        }

        if (input < 1 || input > 9)
        {
            Console.WriteLine("1부터 9까지 입력하세요.");
            continue;
        }

        if (matched[input - 1] == true)
        {
            Console.WriteLine("이미 선택된 위치입니다.");
            continue;
        }

        else
        {
            return input - 1;
        }
    }
}

void DisPlayBoard(int[] board, bool[] matched)
{
    Console.Clear();
    Title();
    Console.WriteLine();
    Console.WriteLine("위치 번호:");

    for (int i = 0; i < board.Length; i += ColumCount)
    {
        Console.WriteLine(string.Join(" | ",
        i + 1, i + 2, i + 3));

        if (i + ColumCount < board.Length)
        {
            Console.WriteLine("---------");
        }
    }

    Console.WriteLine();
    Console.WriteLine("현재 보드:");

    string[] shows = new string[board.Length];

    for (int i = 0; i < board.Length; i++)
    {
        string show = ".";

        if (matched[i] == true)
        {
            if (board[i] == 1)
            {
                show = "X";
            }
            else
            {
                show = "O";
            }
        }
        shows[i] = show;
    }

    for (int i = 0; i < shows.Length; i += ColumCount)
    {
        Console.WriteLine(string.Join(" | ",
         shows[i], shows[i + 1], shows[i + 2]));

        if (i + ColumCount < shows.Length)
        {
            Console.WriteLine("---------");
        }
    }
    Console.WriteLine();
}

void Title()
{
    Console.WriteLine("=== 틱택토 게임 1단계 ===");
    Console.WriteLine("두 사람이 X와 O를 번갈아 놓습니다.");
    Console.WriteLine("X가 먼저 시작합니다.");
}
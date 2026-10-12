using System;

const int BoardSize = 9;
const int ColumnCount = 3;

int[] board = new int[BoardSize];

int player = 1;
int count = 0;
bool gameStart = true;

while (gameStart)
{
    DisplayBoard(board);

    string choiceName = player == 1 ? "X" : "O";

    int index = ReadBoardIndex(choiceName, board);

    board[index] = player;
    count++;

    if (CheckWin(board, player))
    {
        Console.WriteLine($"플레이어 {choiceName} 승리!");
        break;
    }

    if (count == BoardSize)
    {
        Console.WriteLine("무승부입니다.");
        break;
    }

    player = player == 1 ? 2 : 1;
}

WaitForEnter();


void WaitForEnter()
{
    Console.WriteLine("게임을 종료하시려면 Enter를 눌러주세요.");
    Console.ReadLine();
}


int ReadBoardIndex(string choiceName, int[] board)
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

        if (input < 1 || input > BoardSize)
        {
            Console.WriteLine("1부터 9까지 입력하세요.");
            continue;
        }

        int index = input - 1;

        if (board[index] != 0)
        {
            Console.WriteLine("이미 선택된 위치입니다.");
            continue;
        }

        return index;
    }
}


bool CheckWin(int[] board, int player)
{
    // 가로 확인
    for (int row = 0; row < BoardSize; row += ColumnCount)
    {
        if (board[row] == player &&
            board[row + 1] == player &&
            board[row + 2] == player)
        {
            return true;
        }
    }

    // 세로 확인
    for (int col = 0; col < ColumnCount; col++)
    {
        if (board[col] == player &&
            board[col + ColumnCount] == player &&
            board[col + ColumnCount * 2] == player)
        {
            return true;
        }
    }

    // 대각선 확인
    if (board[0] == player &&
        board[4] == player &&
        board[8] == player)
    {
        return true;
    }

    if (board[2] == player &&
        board[4] == player &&
        board[6] == player)
    {
        return true;
    }

    return false;
}


void DisplayBoard(int[] board)
{
    Console.Clear();
    Title();

    Console.WriteLine();
    Console.WriteLine("위치 번호:");

    for (int i = 0; i < BoardSize; i += ColumnCount)
    {
        Console.WriteLine(
            $"{i + 1} | {i + 2} | {i + 3}");

        if (i + ColumnCount < BoardSize)
        {
            Console.WriteLine("---------");
        }
    }

    Console.WriteLine();
    Console.WriteLine("현재 보드:");

    for (int i = 0; i < BoardSize; i += ColumnCount)
    {
        Console.WriteLine(string.Join(" | ",
            DotMark(board[i]),
            DotMark(board[i + 1]),
            DotMark(board[i + 2])));

        if (i + ColumnCount < BoardSize)
        {
            Console.WriteLine("---------");
        }
    }

    Console.WriteLine();
}


string DotMark(int value)
{
    if (value == 1)
    {
        return "X";
    }

    if (value == 2)
    {
        return "O";
    }

    return ".";
}


void Title()
{
    Console.WriteLine("=== 틱택토 게임 1단계 ===");
    Console.WriteLine("두 사람이 X와 O를 번갈아 놓습니다.");
    Console.WriteLine("X가 먼저 시작합니다.");
}
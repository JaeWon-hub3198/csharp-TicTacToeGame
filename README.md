# TicTacToeGame

## 프로젝트 소개

C# 콘솔 환경에서 제작한 2인용 틱택토(Tic-Tac-Toe) 게임이다.

3×3 크기의 게임 보드에서 두 플레이어가 X와 O를 번갈아 배치하며, 가로·세로·대각선 중 한 방향으로 같은 표시를 3개 연결하면 승리하는 방식으로 진행된다.

## 주요 기능

- 3×3 게임 보드 구성
- X와 O 플레이어의 턴 교대
- 숫자 입력을 통한 위치 선택
- 잘못된 입력 및 중복 선택 방지
- 가로·세로·대각선 승리 조건 검사
- 승리 및 무승부 판정
- 게임 보드 및 현재 진행 상황 출력

## 조작 방법

| 입력 | 기능 |
|---|---|
| `1~9` | 해당 번호의 보드 위치 선택 |
| `Enter` | 게임 종료 |

## 프로젝트 구조

```text
TicTacToeGame/
├── csharp-TicTacToeGame/
│   ├── csharp-TicTacToeGame.slnx
│   ├── csharp-TicTacToeGame/
│   │   ├── Program.cs
│   │   └── csharp-TicTacToeGame.csproj
│   └── csharp-TicTacToeGameRe/
│       ├── Program.cs
│       └── csharp-TicTacToeGameRe.csproj
└── .gitignore
```

- **csharp-TicTacToeGame**: 초기 구현 버전
- **csharp-TicTacToeGameRe**: 승리 조건 검사와 보드 관리 방식을 개선한 버전

## 실행 방법

1. 저장소를 Clone하거나 ZIP 파일로 다운로드한다.
2. Visual Studio 또는 VS Code에서 솔루션을 연다.
3. 실행할 프로젝트를 선택한다.
4. 콘솔에서 숫자 1~9를 입력하여 게임을 진행한다.

## 개발 환경

- Language: C#
- Framework: .NET 10
- C# Version: 9.0
- IDE: Visual Studio Code
- Application: Console Application

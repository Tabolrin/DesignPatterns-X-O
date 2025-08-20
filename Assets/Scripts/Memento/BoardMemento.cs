using UnityEngine;

public class BoardMemento
{
    private SlotContent[,] boardMemento = new SlotContent[3,3];

    public BoardMemento(SlotContent[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                boardMemento[i, j] = board[i, j];
            }
        }
    }
    
    public SlotContent[,] GetBoardMemento()
    {
        return boardMemento;
    }
}

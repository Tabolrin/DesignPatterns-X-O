using UnityEngine;

public class BoardMemento
{
    public bool DinoUnoTurn;
    public SlotContent[,] SlotMat { get; private set; } = new SlotContent[3, 3];

    public BoardMemento()
    {
    }
    
    public SlotContent[,] GetBoardMemento()
    {
        return SlotMat;
    }
}

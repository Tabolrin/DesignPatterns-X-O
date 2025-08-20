using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private BoardViewer boardViewer;
    
    private BoardModel boardModel = new BoardModel();
    
    public int MatIndexToArrIndex (int x, int y) { return y * 3 + x; }
    
    public void SetUno(int x, int y)
    {
        boardModel.SetUno(x, y);
        boardViewer.SetUno(MatIndexToArrIndex(x, y));
    }

    public void SetDos(int x, int y)
    {
        boardModel.SetDos(x, y);
        boardViewer.SetDos(MatIndexToArrIndex(x, y));
    }

    public SlotContent GetSlot(int x, int y)
    {
        return boardModel.GetSlotContent(x, y);
    }
    public void SetBoard(BoardMemento memento)
    {
        for (int i = 0; i < memento.SlotMat.GetLength(0); i++)
            for (int j = 0; j < memento.SlotMat.GetLength(1); j++)
            {
                boardModel.SetSlot(i, j, memento.SlotMat[i, j]);
                boardViewer.SetSlot(MatIndexToArrIndex(i, j), memento.SlotMat[i, j]);
            }
    }
}

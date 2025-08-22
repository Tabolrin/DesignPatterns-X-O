using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    
    private List<BoardMemento> historyList = new List<BoardMemento>();
    
    public int Count => historyList.Count;


    public BoardMemento GetBoardMemento(int turnCount)
    {
        int index = turnCount;// - 1; // Adjust for zero-based index

        if (index < 0 || index >= historyList.Count)
        {
            Debug.LogError($"Index out of bounds");
            return null;
        }

        
        return historyList[index];
    }
    public void CreateMemento(int turnCount, bool dinoUnoTurn, BoardController boardController, bool victoryAchived)
    {
        int index = turnCount;// - 1;

        //Delete all moves that this new move would overwrite (after undo)
        while(index < historyList.Count)
            historyList.RemoveAt(index);

        //set memento state
        BoardMemento memento = new BoardMemento();
        for (int i = 0; i < memento.SlotMat.GetLength(0); i++)
            for (int j = 0; j < memento.SlotMat.GetLength(1); j++)
            {
                memento.SlotMat[i, j] = boardController.GetSlot(i, j);
            }
        memento.DinoUnoTurn = dinoUnoTurn;
        memento.VictoryAchived = victoryAchived;
        
        historyList.Add(memento);
    }
}

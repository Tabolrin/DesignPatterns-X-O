using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    private BoardController boardController {get { return GameManager.instance.boardController; }}
    private List<BoardMemento> _history = new List<BoardMemento>();
    
    public SlotContent[,] GetBoardMemento(int turnCount)
    {
        int index = turnCount - 1; // Adjust for zero-based index
        
        if (index < 0 || index >= _history.Count)
        {
            Debug.LogError("Index out of bounds");
            return null;
        }
        
        return _history[index].GetBoardMemento();
    }

    
    public void CreateMemento(int turnCount)
    {
        int index = turnCount - 1;
        
        Debug.Log("COUNT: " + turnCount + " INDEX: " + index + " HISTORY COUNT: " + _history.Count);

        for(int i = index; i > _history.Count; i--)
            _history.RemoveAt(i);
        
        Debug.Log(" HISTORY COUNT: " + _history.Count);
            
        _history.Add(boardController.CreateMemento());
        
        Debug.Log(" HISTORY COUNT: " + _history.Count);
    }
}

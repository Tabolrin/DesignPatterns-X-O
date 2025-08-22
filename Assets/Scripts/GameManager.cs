using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] UIManager uiManager;

    [SerializeField] private History history;
    [SerializeField] public BoardController boardController;
    
    public bool PlayerUnoTurn { get; private set; } = true;
    public int TurnCount { get; private set; } = 1;
    
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);

        
    }
    private void Start()
    {
        history.CreateMemento(0, false, boardController);
        SetUI();
    }

    public void GetInput(int x, int y)
    {
        if (boardController.GetSlot(x, y) != SlotContent.Empty)
            return;
        
        if (PlayerUnoTurn)
            boardController.SetUno(x, y);
        else
            boardController.SetDos(x, y);
        
        if(CheckWin(x,y))
            
        
        history.CreateMemento(TurnCount, PlayerUnoTurn, boardController);
        
        PlayerUnoTurn = !PlayerUnoTurn;
        TurnCount++; 
        SetUI();
    }

    public void Undo()
    {
        TurnCount--; //make sure no 0
        LoadPreviousTurn();
        SetUI();
    }
    public void Redo()
    {
        TurnCount++;
        LoadPreviousTurn();
        SetUI();
    }

    private void SetUI()
    {
        uiManager.SetDisplayArea(TurnCount, PlayerUnoTurn);
        bool undoAvailable = true;
        bool redoAvailable = true;
        if (TurnCount == 1)
            undoAvailable = false;
        if (TurnCount == history.Count)
            redoAvailable = false;
        uiManager.SetUndoRedo(undoAvailable, redoAvailable);
    }
    private void LoadPreviousTurn()
    {
        BoardMemento memento = history.GetBoardMemento(TurnCount - 1);
        PlayerUnoTurn = !memento.DinoUnoTurn;
        boardController.SetBoard(memento);
    }

    private bool CheckWin(int x, int y)
    {
        SlotContent slot = boardController.GetSlot(x, y);
        
        for (int i = 0; i < 3; i++)
        {
            if(boardController.GetSlot(x,i) != slot)
                break;
            
            if (i==2)
                return true;
        }
        
        for (int i = 0; i < 3; i++)
        {
            if(boardController.GetSlot(i,y) != slot)
                break;
            
            if (i==2)
                return true;
        }
        
        if (x == y)
        {
            for (int i = 0; i < 3; i++)
            {
                if(boardController.GetSlot(i,i) != slot)
                    break;
                
                if (i==2)
                    return true;
            }
        }
        
        if (x + y == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                if(boardController.GetSlot(i, 2 - i) != slot)
                    break;
                
                if (i==2)
                    return true;
            }
        }

        return false;
    }
}

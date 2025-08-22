using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] UIManager uiManager;

    [SerializeField] private History history;
    [SerializeField] public BoardController boardController;

    private bool canGetInput = true;
    
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
        history.CreateMemento(0, false, boardController, false);
        SetUI();
    }

    public void GetInput(int x, int y)
    {
        if (boardController.GetSlot(x, y) != SlotContent.Empty)
            return;
        if (!canGetInput)
            return;
        
        if (PlayerUnoTurn)
            boardController.SetUno(x, y);
        else
            boardController.SetDos(x, y);

        bool won = CheckWin(x, y);
        if (won)
            ActOnWin();

        history.CreateMemento(TurnCount, PlayerUnoTurn, boardController, won);
        
        PlayerUnoTurn = !PlayerUnoTurn;
        TurnCount++; 
        SetUI();
    }

    public void Undo()
    {
        TurnCount--; //make sure no 0
        canGetInput = true;
        LoadPreviousTurn();
    }
    public void Redo()
    {
        TurnCount++;
        LoadPreviousTurn();
    }
    public void ResetGame()
    {
        TurnCount = 1; //make sure no 0
        canGetInput = true;
        LoadPreviousTurn();
        history.CreateMemento(0, false, boardController, false);
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
        if (memento.VictoryAchived)
        {
            PlayerUnoTurn = memento.DinoUnoTurn;
            ActOnWin();
        }
        SetUI();
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
    private void ActOnWin()
    {
        uiManager.OpenVictoryPanel(PlayerUnoTurn);
        canGetInput = false;
    }
}

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

        SetUI();
    }

    public void GetInput(int x, int y)
    {
        if (PlayerUnoTurn)
            boardController.SetUno(x, y);
        else
            boardController.SetDos(x, y);
        
        history.CreateMemento(TurnCount, PlayerUnoTurn);
        
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
    }
    private void LoadPreviousTurn()
    {
        BoardMemento memento = history.GetBoardMemento(TurnCount - 1);
        PlayerUnoTurn = !memento.DinoUnoTurn;
        boardController.SetBoard(memento);
    }
}

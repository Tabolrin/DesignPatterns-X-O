using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI text;

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

    private void Update()
    {
        text.text = $"Player 1? {PlayerUnoTurn}\ncurrent turn {TurnCount}";
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
    }
    
    public void Undo()
    {
        TurnCount--; //make sure no 0
        LoadPreviousTurn();
    }
    public void Redo()
    {
        TurnCount++;
        LoadPreviousTurn();

    }

    private void LoadPreviousTurn()
    {
        BoardMemento memento = history.GetBoardMemento(TurnCount - 1);
        PlayerUnoTurn = !memento.DinoUnoTurn;
        boardController.SetBoard(memento);
    }
}

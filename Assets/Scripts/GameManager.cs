using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private History history;
    [SerializeField] public BoardController boardController;
    public bool playerUnoTurn { get; private set; } = true;
    public int TurnCount { get; private set; } = 1;
    
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    
    public void GetInput(int x, int y)
    {
        if (playerUnoTurn)
            boardController.SetUno(x, y);
        else
            boardController.SetDos(x, y);
        
        history.CreateMemento(TurnCount);
        TurnCount++;
        playerUnoTurn = !playerUnoTurn;
    }
    
    //redo + undo
}

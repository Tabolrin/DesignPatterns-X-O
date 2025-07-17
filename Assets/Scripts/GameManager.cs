using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private BoardController boardController;
    public bool playerUnoTurn { get; private set; } = true;
    
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
        
        playerUnoTurn = !playerUnoTurn; 
    }
}

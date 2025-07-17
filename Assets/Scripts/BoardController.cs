using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private BoardViewer boardViewer;
    [SerializeField] private int debugX;
    [SerializeField] private int debugY;

    
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
    
    [ContextMenu("SetUno")]
    public void SetUno()
    {
        SetUno(debugX, debugY);
    }
    
    [ContextMenu("SetDos")]
    public void SetDos()
    {
        SetDos(debugX, debugY);
    }
}

using UnityEngine;

public enum SlotContent
{
    Empty,
    DinoUno,
    DinoDos
}

public class BoardModel
{
    private SlotContent[,] _slots = new SlotContent[3,3];

    public void SetUno(int x, int y)
    {
        _slots[x, y] = SlotContent.DinoUno;
    }

    public void SetDos(int x, int y)
    {
        _slots[x, y] = SlotContent.DinoDos;
    }
    
    public void SetClearSlot(int x, int y)
    {
        _slots[x, y] = SlotContent.Empty;
    }
    
    public SlotContent GetSlotContent(int x, int y)
    {
       return _slots[x, y];
    }
    
    public SlotContent[,] GetMatrix()
    {
        SlotContent[,] temp = new SlotContent[3, 3];
        
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                temp[i, j] = _slots[i, j];
                
        return temp;
    }
}

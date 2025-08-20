using UnityEngine;

public enum SlotContent
{
    Empty,
    DinoUno,
    DinoDos
}

public class BoardModel
{
    private SlotContent[,] slots = new SlotContent[3,3];

    public void SetUno(int x, int y)
    {
        SetSlot(x, y, SlotContent.DinoUno);
    }

    public void SetDos(int x, int y)
    {
        SetSlot(x, y, SlotContent.DinoDos);
    }

    public void SetClearSlot(int x, int y)
    {
        SetSlot(x, y, SlotContent.Empty);
    }

    public void SetSlot(int x, int y, SlotContent slot)
    {
        slots[x, y] = slot;
    }
    
    public SlotContent GetSlotContent(int x, int y)
    {
       return slots[x, y];
    }
    
    public SlotContent[,] GetMatrix()
    {
        SlotContent[,] temp = new SlotContent[3, 3];
        
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                temp[i, j] = slots[i, j];
                
        return temp;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class BoardViewer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] slotRenderers;
    [SerializeField] private Sprite dinoUnoSprite;
    [SerializeField] private Sprite dinoDosSprite;
    

    public void SetUno(int x)
    {
        slotRenderers[x].sprite = dinoUnoSprite;
    }
    
    public void SetDos(int x)
    {
        slotRenderers[x].sprite = dinoDosSprite;
    }
    
    public void ClearSlot(int x)
    {
        slotRenderers[x].sprite = null;
    }

    public void SetSlot(int x, SlotContent content)
    {
        switch(content)
        {
            case SlotContent.Empty:
                ClearSlot(x);
                break;
            case SlotContent.DinoUno:
                SetUno(x);
                break;
            case SlotContent.DinoDos:
                SetDos(x);
                break;

        }
    }
}

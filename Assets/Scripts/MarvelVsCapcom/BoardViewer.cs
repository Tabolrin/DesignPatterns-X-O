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
}

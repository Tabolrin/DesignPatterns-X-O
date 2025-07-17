using System;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    
    [SerializeField] private int x;
    [SerializeField] private int y;

    private void OnMouseUp()
    {
        GameManager.instance.GetInput(x, y);
    }
}

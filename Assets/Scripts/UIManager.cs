using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] string turnCountFormat;
    [SerializeField] Sprite playerUnoSprite;
    [SerializeField] Sprite playerDosSprite;
    [Header("DisplayArea")]
    [SerializeField] TextMeshProUGUI turnCountTMP;
    [SerializeField] Image currentPlayerImageDisplayer;
    [Header("ButtonArea")]
    [SerializeField] Button undoButton;
    [SerializeField] Button redoButton;

    public void SetUndoRedo(bool undo, bool redo)
    {
        undoButton.interactable = undo;
        redoButton.interactable = redo;
    }

    public void SetDisplayArea(int turnCount, bool playerUnoTurn)
    {
        turnCountTMP.text = turnCountFormat + turnCount;

        if(playerUnoTurn) 
            currentPlayerImageDisplayer.sprite = playerUnoSprite;
        else
            currentPlayerImageDisplayer.sprite = playerDosSprite;
    }
}

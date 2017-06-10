using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public Button button;           // This object's UI button component.
    public Text buttonText;         // The button's associated text component.
    public string playerSide;       // 'X' or '0'.

    // Called when the button is clicked.
    public void SetSpace()
    {
        buttonText.text = playerSide;
        button.interactable = false;
    }
}
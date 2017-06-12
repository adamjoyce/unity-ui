using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;                           // This object's UI button component.
    public Text buttonText;                         // The button's associated text component.

    private GameController gameController;          // The scene's game controller.

    // Called when the button is clicked.
    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }

    // Sets the scene's gamecontroller for this button.
    public void SetGameController(GameController controller)
    {
        gameController = controller;
    }
}
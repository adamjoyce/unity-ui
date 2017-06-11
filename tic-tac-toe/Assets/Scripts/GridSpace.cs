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
    public void setSpace()
    {
        buttonText.text = gameController.getPlayerSide();
        button.interactable = false;
        gameController.endTurn();
    }

    // Sets the scene's gamecontroller for this button.
    public void setGameController(GameController controller)
    {
        gameController = controller;
    }
}
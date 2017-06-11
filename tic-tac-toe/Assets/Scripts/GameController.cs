using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;

    private void Awake()
    {
        setGameControllerReferenceOnButtons();
    }

    // Returns which player go it is.
    public string getPlayerSide()
    {
        return "?";
    }

    // Ends the current player's turn.
    public void endTurn()
    {
        Debug.Log("EndTurn is not implemented yet.");
    }

    // Sets up the game controller reference for all button in the grid space.
    private void setGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; ++i)
        {
            buttonList[i].GetComponentInParent<GridSpace>().setGameController(this);
        }
    }
}
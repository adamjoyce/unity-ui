using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;

    private string playerSide;

    private void Awake()
    {
        playerSide = "X";
        setGameControllerReferenceOnButtons();
    }

    // Returns which player go it is.
    public string getPlayerSide()
    {
        return playerSide;
    }

    // Ends the current player's turn.
    public void endTurn()
    {
        // Top row.
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            gameOver();
        }

        // Middle row.
        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            gameOver();
        }

        // Bottom row.
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            gameOver();
        }

        // Left column.
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            gameOver();
        }

        // Middle column,
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            gameOver();
        }

        // Right column.
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            gameOver();
        }

        // Top-left diagonal.
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            gameOver();
        }

        // Top-right diagonal.
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            gameOver();
        }

        changeSides();
    }

    // Sets up the game controller reference for all button in the grid space.
    private void setGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; ++i)
        {
            buttonList[i].GetComponentInParent<GridSpace>().setGameController(this);
        }
    }

    // Deals with cleanup and ending the game.
    private void gameOver()
    {
        for (int i = 0; i < buttonList.Length; ++i)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }

    // Swaps the player to the other side.
    private void changeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }
}
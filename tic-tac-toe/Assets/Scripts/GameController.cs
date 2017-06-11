using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;

    private string playerSide;
    private int moveCount;
    private int maxMoves;

    private void Awake()
    {
        setGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        playerSide = "X";
        moveCount = 0;
        maxMoves = 9;
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
            gameOver(playerSide);
        }

        // Middle row.
        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            gameOver(playerSide);
        }

        // Bottom row.
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            gameOver(playerSide);
        }

        // Left column.
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            gameOver(playerSide);
        }

        // Middle column,
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            gameOver(playerSide);
        }

        // Right column.
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            gameOver(playerSide);
        }

        // Top-left diagonal.
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            gameOver(playerSide);
        }

        // Top-right diagonal.
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            gameOver(playerSide);
        }

        // Check for a draw.
        moveCount++;
        if (moveCount >= maxMoves)
        {
            gameOver("draw");
        }

        changeSides();
    }

    // Resets the game for another round.
    public void restartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        setBoardInteractable(true);
        for (int i = 0; i < buttonList.Length; ++i)
        {
            buttonList[i].text = "";
        }
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
    private void gameOver(string winningPlayer)
    {
        setBoardInteractable(false);

        // Displays the if the game was a win or a draw.
        if (winningPlayer == "draw")
        {
            setGameOverText("It's a draw!");
        }
        else
        {
            setGameOverText(playerSide + " Wins!");
        }

        restartButton.SetActive(true);
    }

    // Swaps the player to the other side.
    private void changeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    // Sets the game over text and enables the game over panel.
    private void setGameOverText(string text)
    {
        gameOverText.text = text;
        gameOverPanel.SetActive(true);
    }

    // Toggles the board's button interactibility.
    private void setBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; ++i)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
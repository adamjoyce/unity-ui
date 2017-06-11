﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    private string playerSide;
    private int moveCount;
    private int maxMoves;

    private void Awake()
    {
        setGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        playerSide = "X";
        setPlayerColors(playerX, playerO);
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
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)           // Top row.
        {
            gameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)      // Middle row.
        {
            gameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)      // Bottom row.
        {
            gameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)      // Left column.
        {
            gameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)      // Middle column.
        {
            gameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)      // Right column.
        {
            gameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)      // Top-left diagonal.
        {
            gameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)      // Top-right diagonal.
        {
            gameOver(playerSide);
        }
        else if (moveCount >= maxMoves)         // Check for a draw.
        {
            gameOver("draw");
        }
        else
        {
            changeSides();
        }
    }

    // Resets the game for another round.
    public void restartGame()
    {
        playerSide = "X";
        setPlayerColors(playerX, playerO);
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
        if (playerSide == "X")
        {
            setPlayerColors(playerX, playerO);
        }
        else
        {
            setPlayerColors(playerO, playerX);
        }
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

    // Sets the active and inactive player colours.
    private void setPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }
}
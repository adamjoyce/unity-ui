using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
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
    public GameObject GameOverPanel;
    public Text GameOverText;
    public GameObject restartButton;
    public GameObject startInfo;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;

    private string playerSide;
    private int moveCount;
    private int maxMoves;

    private void Awake()
    {
        SetGameControllerReferenceOnButtons();
        GameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        moveCount = 0;
        maxMoves = 9;
    }

    // Returns which player go it is.
    public string GetPlayerSide()
    {
        return playerSide;
    }

    // Ends the current player's turn.
    public void EndTurn()
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)           // Top row.
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)      // Middle row.
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)      // Bottom row.
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)      // Left column.
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)      // Middle column.
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)      // Right column.
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)      // Top-left diagonal.
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)      // Top-right diagonal.
        {
            GameOver(playerSide);
        }
        else if (moveCount >= maxMoves)         // Check for a draw.
        {
            GameOver("draw");
            SetPlayerColorsInactive();
        }
        else
        {
            ChangeSides();
        }
    }

    // Resets the game for another round.
    public void RestartGame()
    {
        moveCount = 0;

        GameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        for (int i = 0; i < buttonList.Length; ++i)
        {
            buttonList[i].text = "";
        }

        SetPlayerColorsInactive();
        SetPlayerButtons(true);
        startInfo.SetActive(true);
    }

    // Sets the side to begin the game.
    public void SetStartingState(string startingSide)
    {
        playerSide = startingSide;
        if (startingSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }

        StartGame();
    }

    // Begins the game after a starting player is chosen.
    private void StartGame()
    {
        startInfo.SetActive(false);
        SetBoardInteractable(true);
        SetPlayerButtons(false);
    }

    // Sets up the game controller reference for all button in the grid space.
    private void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; ++i)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameController(this);
        }
    }

    // Deals with cleanup and ending the game.
    private void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);

        // Displays the if the game was a win or a draw.
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a draw!");
        }
        else
        {
            SetGameOverText(playerSide + " Wins!");
        }

        restartButton.SetActive(true);
    }

    // Swaps the player to the other side.
    private void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    // Sets the game over text and enables the game over panel.
    private void SetGameOverText(string text)
    {
        GameOverText.text = text;
        GameOverPanel.SetActive(true);
    }

    // Toggles the board's button interactibility.
    private void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; ++i)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    // Sets the active and inactive player colours.
    private void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    // Toggles the player buttons for 'first turn' selection.
    private void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    // Sets the player selection panels to their inactive colour scheme.
    private void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}
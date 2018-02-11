using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    private const int MENU_SCENA = 0;
    private const int GAME_PLAY_SCENA = 1;

	public void PlayGame()
    {
        SceneManager.LoadScene(GAME_PLAY_SCENA);
    }

    public void Menu()
    {
        SceneManager.LoadScene(MENU_SCENA);
    }
}

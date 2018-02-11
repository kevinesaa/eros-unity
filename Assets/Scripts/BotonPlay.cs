using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonPlay : MonoBehaviour {

    private const int PLAY_SCENE = 1;

    public void PlayGame ()
	{
		SceneManager.LoadScene (PLAY_SCENE);
	}

	public void QuitGame ()
	{
		Application.Quit();
	}
}
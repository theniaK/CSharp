using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
[ExecuteInEditMode]

public class StartGameButton : MonoBehaviour {

    public void NewGame(string NewGameLevel)
    {
        SceneManager.LoadScene(NewGameLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

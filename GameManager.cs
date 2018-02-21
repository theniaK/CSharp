using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform musicPrefab;

	// Use this for initialization
	void Start ()
    {
	    if (!GameObject.FindGameObjectWithTag("MusicManager"))
        {
            Transform  music = Instantiate(musicPrefab, transform.position, Quaternion.identity) as Transform; // play the game music 
            music.name = musicPrefab.name;
            DontDestroyOnLoad(music); // don't destroy the music when the game restarts 
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

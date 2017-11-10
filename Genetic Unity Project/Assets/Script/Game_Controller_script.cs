using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller_script : MonoBehaviour {
    
    /// <summary>
    /// Displays the buttons that all player to speed up time
    /// </summary>
    void OnGUI()
    {

        if (GUI.Button(new Rect(10, 10, 50, 20), "1x"))
        {
            Time.timeScale = 1f;
            Debug.Log("1 Times Speed");
        }
        if (GUI.Button(new Rect(10, 30, 50, 20), "10x"))
        {
            Time.timeScale = 10f;
            Debug.Log("10 Times Speed");
        }
        if (GUI.Button(new Rect(10, 50, 50, 20), "100x"))
        {
            Time.timeScale = 100f;
            Debug.Log("100 Times Speed");
        }
        if (GUI.Button(new Rect(10, 70, 50, 20), "1000x"))
        {
            Time.timeScale = 1000f;
            Debug.Log("1000 Times Speed");
        }
        if (GUI.Button(new Rect(10, 90, 50, 20), "5000x"))
        {
            Time.timeScale = 5000f;
            Debug.Log("5000 Times Speed");
        }


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

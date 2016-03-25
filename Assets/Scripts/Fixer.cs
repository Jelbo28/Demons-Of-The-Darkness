using UnityEngine;
using System.Collections;

public class Fixer : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player 1");
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.frameCount == 5)
        {
            player.gameObject.SetActive(false);
        }
        if (Time.frameCount == 7)
        {
            player.gameObject.SetActive(true);
        }

    }
}

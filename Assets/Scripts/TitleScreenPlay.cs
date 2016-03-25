using UnityEngine;
using System.Collections;

public class TitleScreenPlay : MonoBehaviour {

	public void Play()
    {
        Application.LoadLevel(1); //Attack to the 1st button the one with "Start" as its text.
    }
}

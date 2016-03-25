using UnityEngine;
using System.Collections;

public class Transition1 : MonoBehaviour {

    public void Play()
    {
        Application.LoadLevel(1); //Change the number to what scene it needs to transition to
    }

}

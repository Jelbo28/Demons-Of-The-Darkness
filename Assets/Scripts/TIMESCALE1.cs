using UnityEngine;
using System.Collections;

public class TIMESCALE1 : MonoBehaviour {

    [SerializeField]
    float Thyme = 1;

	void Start ()
    {
        Time.timeScale = Thyme;
	}
	
	// Update is called once per frame
}

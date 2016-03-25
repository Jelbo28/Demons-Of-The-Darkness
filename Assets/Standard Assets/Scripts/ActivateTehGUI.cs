using UnityEngine;
using System.Collections;

public class ActivateTehGUI : MonoBehaviour
{
    [SerializeField]
    GameObject kui;

	void FixedUpdate ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            kui.SetActive(true);
        }
	}
}

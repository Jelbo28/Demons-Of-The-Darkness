using UnityEngine;
using System.Collections;

public class LockCursor : MonoBehaviour {

    private bool IsLocked;

	void Start ()
    {
        IsLocked = Screen.lockCursor;
	}

    void Update()
    {
        Screen.lockCursor = true;
    }

	
	}

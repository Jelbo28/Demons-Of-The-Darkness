using UnityEngine;
using System.Collections;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField]
    GameObject menu;

    public void Open()
    {
        menu.SetActive(true);
    }

	
}

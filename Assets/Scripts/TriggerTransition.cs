using UnityEngine;
using System.Collections;

public class TriggerTransition : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel(2);
        }
    }
}

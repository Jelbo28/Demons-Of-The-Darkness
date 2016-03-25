using UnityEngine;
using System.Collections;

public class EventHolder : MonoBehaviour 
{
	//Reference to the player controller script.
	PlayerController pl;
	//Accessing the player controller script.
	void Start ()
	{
		pl = transform.root.GetComponent<PlayerController> ();
	}
	//The fireball special attack. (activator)
	public void ThrowProjectile()
	{
		//Sets specialAttack bool to "true", calling the function in the player script.
		pl.specialAttack = true;
	}

    public void TakeDamage()
    {
        //Debug.Log("Damage");
        gameObject.transform.parent.GetComponent<PlayerHealth>().Damage();
    }
}

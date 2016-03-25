using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour 
{
	//Basic on trigger enter for the hitboxes.
	void OnTriggerEnter2D(Collider2D col)
	{
		//Checks to make sure we aren't hitting anything but the enemy.
		if(col.transform.root != transform.root && col.tag != "Ground" && !col.isTrigger)
		{
			//If the enemy has been hit condition.
			if(!col.transform.GetComponent<PlayerController>().damage && !col.transform.GetComponent<PlayerController>().blocking)
			{
				//Tells the script of the enemy that they've been hit.
				col.transform.GetComponent<PlayerController>().damage = true;
				//Tells the animator of the enemy that they've been hit.
				col.transform.root.GetComponentInChildren<Animator>().SetTrigger ("Damage");
			}
		}
	}
}

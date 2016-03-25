using UnityEngine;
using System.Collections;

public class Text2Load : MonoBehaviour {

    [SerializeField]
    GameObject Dialogue;
    [SerializeField]
    GameObject Player;

    private GameObject DialogueClone;

    IEnumerator Enable()
    {
        //Player.transform.Translate(-3, 1, 24);
        //Instantiate (Dialogue, new Vector3(8));
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
        Application.LoadLevel(2);
    }
	
    void Start()
    {
        
    }


	void OnTriggerEnter (Collider other)
    {
        if (other)
        {
            StartCoroutine("Enable");
            
        }
	}

}

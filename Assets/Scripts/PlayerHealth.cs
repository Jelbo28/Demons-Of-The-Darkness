using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    void Awake()
    {
        health.Initialize();
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            health.CurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            health.CurrentValue += 10;
        }
        */

    }

    public void Damage()
    {
        //Debug.Log(gameObject.tag);
        if (gameObject.name == "Player 1")
        {
            health.CurrentValue -= 10f;
            if (health.CurrentValue <= 0)
            {
                GM.instance.GameLost();
            }
        }
        else if (gameObject.name == "Player 2")
        {
            health.CurrentValue -= 7f;
            if (health.CurrentValue <= 0)
            {
                GM.instance.GameWon();
            }
        }
        
    }
}

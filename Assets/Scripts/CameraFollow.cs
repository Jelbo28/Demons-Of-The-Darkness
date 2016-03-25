using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    Vector3 cameraPosition;

    void Awake()
    {
        player = GameObject.Find("Player 1").transform;
    }

    void Update()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    {
        if (player == null)
        {
            Debug.Log("Nah");
        }
        else if (player != null)
        {
            cameraPosition = new Vector3(player.position.x, player.position.y + 1, -10);
            transform.position = cameraPosition;
        }
    }
}

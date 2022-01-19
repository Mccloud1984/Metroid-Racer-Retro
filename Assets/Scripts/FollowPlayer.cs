using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    float? playerOffset = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerLocation = player.transform.position;
        Vector3 newLocation = new Vector3();
        if (playerOffset == null)
            playerOffset = playerLocation.y;
        newLocation.x = transform.position.x;
        newLocation.y = playerLocation.y - playerOffset.Value;
        newLocation.z = transform.position.z;
        transform.position = newLocation;
    }
}

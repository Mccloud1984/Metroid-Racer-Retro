using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerLocation = player.transform.position;
        playerLocation.x = transform.position.x;
        //playerLocation.y = transform.position.y;
        playerLocation.z = transform.position.z;
        transform.position = playerLocation;
    }
}

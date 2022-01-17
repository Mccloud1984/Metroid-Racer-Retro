using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerBody;
    public float thrust;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        player = null;
        GameObject[] foundPlayers = GameObject.FindGameObjectsWithTag("Player");
        for (int i = foundPlayers.Length - 1; i >= 0; i--)
        {
            if (player == null)
                player = foundPlayers[i];
            else
                GameObject.Destroy(foundPlayers[i]);
        }

        if(player != null)
        {
            playerBody = player.GetComponent<Rigidbody2D>();
            if(playerBody != null)
            {
                float vDirection = Input.GetAxis("Vertical");
                if(vDirection > 0)
                {
                    float translation = (vDirection * thrust) * Time.deltaTime; 
                    playerBody.AddRelativeForce(new Vector2(0, translation));
                }
                //playerBody.transform.Translate(0, translation, 0);
                float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

                playerBody.transform.Rotate(0, 0, rotation);
                
            }
        }
    }
}

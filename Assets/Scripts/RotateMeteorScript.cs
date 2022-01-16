using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMeteorScript : MonoBehaviour
{
    public int rotation;
    public int rotateSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        int rightOrLeft = Random.Range(0, 1);
        if(rightOrLeft == 1)
        {
            rotation = rotateSpeed;
        } else
        {
            rotation = -rotateSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotation * Time.deltaTime), Space.World);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDrop : MonoBehaviour
{
    public BoxCollider2D DropZone;
    public GameObject[] Meteors;
    public int createSpeed = 50;
    public int fallDrag = 10;
    private int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (++frameCount >= createSpeed)
        {
            int randomChance = Random.Range(0, 1);
            if(randomChance == 1 || frameCount >= createSpeed + 5)
            {
                frameCount = 0;
                Vector3 dropZoneLoc = DropZone.transform.position;
                Vector3 dropZoneSize = DropZone.bounds.size;
                float dropZoneHalfWidth = dropZoneSize.x / 2f;
                float dropZoneLeftX = dropZoneLoc.x - dropZoneHalfWidth;
                float dropZoneRightX = dropZoneLoc.x + dropZoneHalfWidth;
                float dropXLocation = Random.Range(dropZoneLeftX, dropZoneRightX);
                float dropYLocation = dropZoneLoc.y;
                GameObject createObject = Meteors[0];
                Rigidbody2D objectBody = (Rigidbody2D)createObject.GetComponent(typeof(Rigidbody2D));
                int randomFallSpeed = Random.Range(0, fallDrag);
                objectBody.drag = randomFallSpeed;
                GameObject newObject = GameObject.Instantiate(createObject, new Vector3(dropXLocation, dropYLocation), Quaternion.Euler(new Vector3(0,10,0)));
                //newObject.transform.eulerAngles = new Vector3(0, 50, 0);
            }
        }
    }
}

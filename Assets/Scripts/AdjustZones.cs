using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ZoneData
{
    public BoxCollider2D Zone { get; set; }
    public float ZoneYLocation { get; set; }
    public float ZoneXLocation { get; set; }

    public ZoneData(BoxCollider2D zone)
    {
        Zone = zone;
        ZoneYLocation = zone.transform.position.y;
        ZoneXLocation = zone.transform.position.x;
    }

    internal void UpdateZoneData(Vector3 cameraLocation)
    {
        cameraLocation.x += ZoneXLocation;
        cameraLocation.y += ZoneYLocation;
        cameraLocation.z = Zone.transform.position.z;
        Zone.transform.position = cameraLocation;
    }
}

public class AdjustZones : MonoBehaviour
{
    public BoxCollider2D[] Zones;
    public Camera MainCamera;
    public float zoneHangeOver;

    private List<ZoneData> zoneData = new List<ZoneData>();
    // Start is called before the first frame update
    void Start()
    {
        float cameraWidth = MainCamera.pixelRect.width;
        float cameraHeight = MainCamera.pixelRect.height;
        float pixelsToWorldHeight = ((Camera.main.orthographicSize) / (Screen.height / 2.0f));
        float pixelsToWorldWidth = ((Camera.main.orthographicSize) / (Screen.width));
        foreach(var zone in Zones)
        {
            //float zoneCenter = zone.transform.position.x;b 
            //Renderer zoneRenderer = zone.GetComponent<Renderer>();
            //zoneRenderer.bounds.size = new Vector3(cameraWidth + 20, zone.size.y);
            float zoneHeight = zone.size.y;
            float zoneWidth = zone.size.x;
            if(zoneWidth > 1)
            {
                zoneWidth = (cameraWidth + zoneHangeOver) * pixelsToWorldWidth;
                if (zone.size.x < 0)
                    zoneWidth = -zoneWidth;
            }
            if(zoneHeight > 1)
            {
                zoneHeight = (cameraHeight + zoneHangeOver) * pixelsToWorldHeight;
                if (zone.size.y < 0)
                    zoneHeight = -zoneHeight;
            }   
            zone.size = new Vector3(zoneWidth, zoneHeight);
            //zone.transform.right = new Vector3((cameraWidth + 20) / 2, zone.transform.right.y);
            zoneData.Add(new ZoneData(zone));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(var zone in zoneData)
        {
            Vector3 cameraLocation = MainCamera.transform.position;
            //cameraLocation.x += zone.transform.position.x;
            //cameraLocation.y += zone.transform.position.y;
            //cameraLocation.z = zone.transform.position.z;
            //zone.transform.position = cameraLocation;
            zone.UpdateZoneData(cameraLocation);
        }
    }
}

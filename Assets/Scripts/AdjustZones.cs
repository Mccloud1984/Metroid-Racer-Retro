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
        foreach(var zone in Zones)
        {
            //float zoneCenter = zone.transform.position.x;b 
            float cameraWidth = MainCamera.pixelRect.width;
            //Renderer zoneRenderer = zone.GetComponent<Renderer>();
            float pixelsToWorld = ((Camera.main.orthographicSize) / (Screen.height / 2.0f));
            //zoneRenderer.bounds.size = new Vector3(cameraWidth + 20, zone.size.y);
            zone.size = new Vector3((cameraWidth + zoneHangeOver) * pixelsToWorld, zone.size.y);
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

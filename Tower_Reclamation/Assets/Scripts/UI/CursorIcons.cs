﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorIcons : MonoBehaviour {

    [SerializeField] Texture2D regularCursor = null;
    [SerializeField] Texture2D enemyCursor = null;
    [SerializeField] Texture2D towerCursor = null;
    [SerializeField] Texture2D waypointCursor = null;

    [SerializeField] Vector2 cursorHotspot = new Vector2(96, 96);

    Raycasting raycasting;
	// Use this for initialization
	void Start () {
        raycasting = GetComponent<Raycasting>();
        raycasting.layerChangeObservers += SetCursorOnLayerChange;
	}
	
	// Update is called once per frame
	void Update () {

        print("delegate for cursor change..");
        switch (raycasting.LayerHit)
        {
            case Layer.Enemy:
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Tower:
                Cursor.SetCursor(towerCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Waypoint:
                Cursor.SetCursor(waypointCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(regularCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Debug.LogError("Error in cursorIcons script targetting");
                break;
        }
    }

    public void PrintLayerHit()
    {
        print(raycasting.LayerHit);
    }

    // Delegate listener
    void SetCursorOnLayerChange()
    {
        
        print("delegate for cursor change..");
        switch (raycasting.LayerHit)
        {
            case Layer.Enemy:
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Tower:
                Cursor.SetCursor(towerCursor, cursorHotspot, CursorMode.Auto);
                    break;
            case Layer.Waypoint:
                Cursor.SetCursor(waypointCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(regularCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Debug.LogError("Error in cursorIcons script targetting");
                break;
        }
    }
}

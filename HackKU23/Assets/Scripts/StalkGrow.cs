using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class StalkGrow : MonoBehaviour
{
    [SerializeField] private Transform stalkSegmentPrefab;
    [SerializeField] private Transform stalkArrowPrefab;

    private float localTicks;
    private Vector3 mousePosition;
    private float aimDir;

    void Awake()
    {
        // Initializtions
        localTicks = 0;
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
        Camera.main.transform.position = transform.position;
        Camera.main.transform.position += new Vector3(0, 0, -10);
    }

    // Start is called before the first frame update
    void Start()
    {
        var arrow = Instantiate(stalkArrowPrefab, transform.position, transform.rotation);
        arrow.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if(localTicks < 1)
        {

            // Get rotation from arrow
            Quaternion newRotation = transform.GetChild(1).transform.rotation;

            // Generate new position for next segment which is towards mouse
            Vector3 newPos = (newRotation * Vector3.up).normalized + transform.position;

            while(transform.childCount > 1)
            {
                DestroyImmediate(transform.GetChild(1).gameObject);
            }

            // Create new segment using new position and current rotation
            Instantiate(stalkSegmentPrefab, newPos, newRotation);
        }

        // Increment ticks
        localTicks++;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class StalkGrow : MonoBehaviour
{
    [SerializeField] private Transform stalkSegmentPrefab;

    private float localTicks;
    private Vector3 mousePosition;
    private float aimDir;

    void Awake()
    {
        // Get mouse position
        mousePosition = UtilsClass.GetMouseWorldPosition();

        // Get direction from object to mouse
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

        // Set up direction towards mouse
        transform.up = direction;

        // Initializtions
        localTicks = 0;
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug for checking direction towards mouse
        Debug.DrawLine(transform.position, mousePosition, Color.green);
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if(localTicks < 1)
        {
            // Get mouse position
            mousePosition = UtilsClass.GetMouseWorldPosition();

            // Get direction towards mouse
            Vector3 direction = new Vector3(
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y,
                0
            );

            // Generate new position for next segment which is towards mouse
            Vector3 newPos = direction.normalized + transform.position;

            // Create new segment using new position and current rotation
            Instantiate(stalkSegmentPrefab, newPos, transform.rotation);
        }

        // Increment ticks
        localTicks++;
    }
}

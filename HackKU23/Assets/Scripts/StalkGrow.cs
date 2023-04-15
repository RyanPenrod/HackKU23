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

    // Start is called before the first frame update
    void Start()
    {
        mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );
        transform.up = direction;

        localTicks = 0;
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, mousePosition, Color.green);
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if(localTicks < 1)
        {
            mousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 direction = new Vector3(
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y,
                0
            );
            Vector3 newPos = direction.normalized + transform.position;

            // Create new segment
            Instantiate(stalkSegmentPrefab, newPos, transform.rotation);
        }

        localTicks++;
    }
}

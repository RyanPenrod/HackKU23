using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkGrow : MonoBehaviour
{
    [SerializeField] private Transform stalkSegmentPrefab;

    private float localTicks;

    // Start is called before the first frame update
    void Start()
    {
        localTicks = 0;

        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if(localTicks < 1)
        {
            // Build next section of stalk
            Instantiate(stalkSegmentPrefab, new Vector3(transform.position.x, transform.position.y + 1, -1), Quaternion.identity);
        }

        localTicks++;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkGrow : MonoBehaviour
{
    [SerializeField] private Transform stalkSegmentPrefab;

    private float segmentCount;

    // Start is called before the first frame update
    void Start()
    {
        segmentCount = 1;

        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        Debug.Log(e.tick);

        // Build next section of stalk
        Instantiate(stalkSegmentPrefab, new Vector3(transform.position.x, transform.position.y + segmentCount, -1), Quaternion.identity);
        segmentCount++;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkGrow : MonoBehaviour
{
    [SerializeField] private Transform stalkSegmentPrefab;
    [SerializeField] private float growFrequency;

    // Start is called before the first frame update
    void Start()
    {
        TimeTickSystem.OnTick_20 += TimeTickSystem_OnTick_20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TimeTickSystem_OnTick_20(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        //Build next section of stalk
        Debug.Log(e.tick);
    }
}

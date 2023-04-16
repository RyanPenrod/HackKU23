using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class StalkGrow : MonoBehaviour
{
    [SerializeField] private Transform stalkSegmentPrefab;
    [SerializeField] private Transform stalkArrowPrefab;
    [SerializeField] private Transform flowerPrefab;

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
        CheckGameOver();
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
            Vector3 newPos = (newRotation * Vector3.up).normalized * 1.5f + transform.position;

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

    private void CheckGameOver()
    {
        if(transform.position.y >= 10f){
            Debug.Log("You Won!");
            Instantiate(flowerPrefab, transform.position, Quaternion.identity);
            TimeTickSystem.OnTick -= TimeTickSystem_OnTick;
            DestroyImmediate(gameObject);
        }
    }
}

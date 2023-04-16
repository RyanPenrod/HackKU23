using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkManager : MonoBehaviour
{
    [SerializeField] private float speedBoostDuration;

    public bool activeSpeedBoost;
    public int ticksToGrow;

    // Start is called before the first frame update
    void Start()
    {
        ticksToGrow = 10;
        activeSpeedBoost = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkManager : MonoBehaviour
{
    [SerializeField] private float speedBoostDuration;

    public bool activeSpeedBoost;
    public int speedBoostTicksLeft;

    private int localTicks;

    // Start is called before the first frame update
    void Start()
    {
        activeSpeedBoost = false;
        speedBoostTicksLeft = 0;

        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if(e.tick % 10 == 0)
        {
            Debug.Log("manager ticks: " + speedBoostTicksLeft);
            if(speedBoostTicksLeft > 0)
            {
                activeSpeedBoost = true;
                speedBoostTicksLeft--;
            }
            else
            {
                activeSpeedBoost = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

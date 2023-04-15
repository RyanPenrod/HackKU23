using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey;

public class TimeTickSystem : MonoBehaviour {

    public class OnTickEventArgs : EventArgs {
        public int tick;
    }
    
    public static event EventHandler<OnTickEventArgs> OnTick_20;

    private const float TICK_TIMER_MAX = 1f;

    private int tick;
    private float tickTimer;


    private void Awake() {
        tick = 0;
    }

    private void Update() {
        tickTimer += Time.deltaTime;
        if (tickTimer >= TICK_TIMER_MAX) {
            tickTimer -= TICK_TIMER_MAX;
            tick++;
            if (tick % 20 == 0) {
                if (OnTick_20 != null) OnTick_20(this, new OnTickEventArgs { tick = tick });
            }
        }
    }
}

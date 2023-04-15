using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;

public class Building {
    /*
    private GameObject gameObject;
    private World_Bar constructingWorldBar;
    private SpriteRenderer spriteRenderer;
    private int buildTick;
    private int buildTickMax;
    private bool isConstructing;

    public Building(Vector3 position, int ticksToConstruct) {
        gameObject = new GameObject("Building");
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = GameAssets.i.tower_1;
        gameObject.transform.position = position;

        buildTick = 0;
        buildTickMax = ticksToConstruct;
        isConstructing = true;

        constructingWorldBar = new World_Bar(gameObject.transform, new Vector3(0, -12f), new Vector3(20, 2), Color.grey, Color.yellow, .0f, -10, new World_Bar.Outline() { color = Color.black, size = .5f });

        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e) {
        if (isConstructing) {
            buildTick += 1;

            float buildTickNormalized = buildTick * 1f / buildTickMax;
            if (buildTickNormalized >= .3f) spriteRenderer.sprite = GameAssets.i.tower_2;
            if (buildTickNormalized >= .6f) spriteRenderer.sprite = GameAssets.i.tower_3;
            if (buildTickNormalized >=  1f) spriteRenderer.sprite = GameAssets.i.tower_Built;

            if (buildTick >= buildTickMax) {
                // Building is fully constructed
                isConstructing = false;
                constructingWorldBar.Hide();
            } else {
                // Building is still under construction
                constructingWorldBar.SetSize(buildTick * 1f / buildTickMax);
            }
        }
    }
    */
}

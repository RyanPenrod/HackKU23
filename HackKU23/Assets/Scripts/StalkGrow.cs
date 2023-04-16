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
    [SerializeField] private RectTransform playAgainButtonPrefab;
    [SerializeField] private int speedBoostDuration;
    [SerializeField] private float gameOverHeight;
    
    private GameObject stalkManager;
    private GameObject canvas;
    private float localTicks;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initializtions
        canvas = GameObject.Find("Canvas");
        stalkManager = GameObject.Find("StalkManager");
        localTicks = 0;
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
        Camera.main.transform.position = transform.position;
        Camera.main.transform.position += new Vector3(-10, 0, -10);
        var arrow = Instantiate(stalkArrowPrefab, transform.position, transform.rotation);
        arrow.transform.parent = gameObject.transform;
        CheckGameOver();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Bee"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(TempSpeedUp());
        }
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {

        if(stalkManager.transform.GetComponent<StalkManager>().activeSpeedBoost)
        {
            if(localTicks >= 3 && localTicks < 10)
            {
                Debug.Log("grow 5");

                SoundManagerScript.PlaySound("grow");

                // Get rotation from arrow
                Quaternion newRotation = transform.GetChild(1).transform.rotation;

                // Generate new position for next segment which is towards arrow
                Vector3 newPos = (newRotation * Vector3.up).normalized * 1.5f + transform.position;

                while(transform.childCount > 1)
                {
                    DestroyImmediate(transform.GetChild(1).gameObject);
                }

                // Create new segment using new position and current rotation
                Instantiate(stalkSegmentPrefab, newPos, newRotation);

                TimeTickSystem.OnTick -= TimeTickSystem_OnTick;
            }
        }
        else
        {
            if(localTicks >= 10)
            {
                Debug.Log("grow 10");

                SoundManagerScript.PlaySound("grow");

                // Get rotation from arrow
                Quaternion newRotation = transform.GetChild(1).transform.rotation;

                // Generate new position for next segment which is towards arrow
                Vector3 newPos = (newRotation * Vector3.up).normalized * 1.5f + transform.position;

                while(transform.childCount > 1)
                {
                    DestroyImmediate(transform.GetChild(1).gameObject);
                }

                // Create new segment using new position and current rotation
                Instantiate(stalkSegmentPrefab, newPos, newRotation);

                TimeTickSystem.OnTick -= TimeTickSystem_OnTick;
            }
        }
        

        // Increment ticks
        localTicks++;
    }

    private void CheckGameOver()
    {
        if(transform.position.y >= gameOverHeight){
            Debug.Log("You Won!");
            SoundManagerScript.PlaySound("cheer");
            Instantiate(flowerPrefab, transform.position, Quaternion.identity);
            var playAganButton = Instantiate(playAgainButtonPrefab, new Vector3(0f, 90f, 0f), Quaternion.identity);
            playAganButton.transform.SetParent (canvas.transform,false);
            TimeTickSystem.OnTick -= TimeTickSystem_OnTick;
            DestroyImmediate(gameObject);
        }
    }
    
    private IEnumerator TempSpeedUp()
    {
        SoundManagerScript.PlaySound("1up");
        stalkManager.transform.GetComponent<StalkManager>().speedBoostTicksLeft += speedBoostDuration;
        Debug.Log("user ticks: " + stalkManager.transform.GetComponent<StalkManager>().speedBoostTicksLeft);
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeKeeper : MonoBehaviour
{
    [SerializeField] private Transform beePrefab;
    [SerializeField] private int numberOfBees;
    [SerializeField] private float spawnRangeX;
    [SerializeField] private float spawnRangeY;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfBees; i++)
        {
            Instantiate(beePrefab, new Vector3(Random.Range(transform.position.x - spawnRangeX, transform.position.x + spawnRangeX), Random.Range(transform.position.y - spawnRangeY, transform.position.y + spawnRangeY), 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

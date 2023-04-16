using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] private Transform stalkSegmentPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position + new Vector3(0f, 1.5f, 0f);
        Instantiate(stalkSegmentPrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

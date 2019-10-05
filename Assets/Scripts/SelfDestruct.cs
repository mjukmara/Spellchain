using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    public GameObject ThisObject;
    public float DestoyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(ThisObject, DestoyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

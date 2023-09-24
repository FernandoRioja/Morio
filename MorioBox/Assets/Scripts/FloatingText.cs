using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 1f;

    public Vector3 Offset = new Vector3(0, 2, 0);
    public Vector3 RandomOffset = new Vector3(1, 0, 0);

    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.localPosition += Offset;
        transform.localPosition += new Vector3 (Random.Range(-RandomOffset.x, RandomOffset.x), Random.Range(-RandomOffset.y, RandomOffset.y), Random.Range(-RandomOffset.z, RandomOffset.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

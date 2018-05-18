using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SurfaceMover))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    public float lifeSpan = 5f;
    float aliveTime = 0;

    public Vector3 velocity
    {
        get
        {
            return GetComponent<SurfaceMover>().localVelocity;
        }
        set
        {
            GetComponent<SurfaceMover>().localVelocity = value;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    void OnEnable()
    {
        aliveTime = 0;
        GetComponent<Collider>().enabled = false;
    }

    void OnDisable()
    {
        GetComponent<Collider>().enabled = false;
    }

    public bool IsAlive => aliveTime <= lifeSpan;

    // Update is called once per frame
    void Update()
    {
        aliveTime += Time.deltaTime;
		if (!IsAlive)
		{
			gameObject.SetActive(false);
		}
    }
}

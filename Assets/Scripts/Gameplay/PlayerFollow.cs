using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private Transform player;
    private Transform world;
    public float orbitDistance = 20;
    public float speed = 0.5f;

    // Use this for initialization
    void Start()
    {
        world = GameObject.FindWithTag("World").transform;
        transform.position = world.position + Vector3.up * orbitDistance;
        transform.LookAt(world, Vector3.up);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
			Debug.Assert(player != null);
			Debug.Log($"Found player {player.name}");
        }

        Vector3 cameraNormal = transform.position - world.position;
        Vector3 playerNormal = player.position - world.position;
        float angularDiff = Vector3.Angle(cameraNormal, playerNormal);
        Vector3 rotationAxis = Vector3.Cross(cameraNormal, playerNormal);
        transform.RotateAround(world.position, rotationAxis, Mathf.Lerp(0, angularDiff, speed));
    }
}

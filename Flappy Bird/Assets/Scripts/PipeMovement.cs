using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float deathZone = -30f;
    private BirdScript bird;

    private void Awake()
    {

        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    private void StopPipe()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bird.inGame)
        {
            transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;

            if (transform.position.x < deathZone)
            {
                Destroy(gameObject);
            }
        }
    }
}

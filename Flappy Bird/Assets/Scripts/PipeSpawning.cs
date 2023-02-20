using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawning : MonoBehaviour
{

    public GameObject pipe;

    public float timeBetweenSpawns = 1.5f;
    public float heightOffset = 5f;
    private float timer = 0;

    private BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.inGame)
        {
            if (timer < timeBetweenSpawns)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timer = 0;
            }
        }

    }


    private void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Vector3 pipePosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        Instantiate(pipe, pipePosition, transform.rotation);
    }
}

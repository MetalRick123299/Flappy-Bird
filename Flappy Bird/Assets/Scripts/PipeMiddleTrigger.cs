using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleTrigger : MonoBehaviour
{
    public LogicManger logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManger>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Bird"))
            logic.addScore(1);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    private BirdInputActions birdInputActions;
    private InputAction movement;
    public Rigidbody2D birdRigidBody;
    public float flapStrength = 12.5f;

    // Start is called before the first frame update
    void Awake()
    {
        birdInputActions = new BirdInputActions();

        birdRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        movement = birdInputActions.InGame.FlapWings;
        movement.Enable();

        //    When Input for FlapWings += CallBack Context => FlapWings();
        birdInputActions.InGame.FlapWings.performed += ctx => FlapWings();
        birdInputActions.InGame.FlapWings.Enable();
    }

    private void FlapWings()
    {
        birdRigidBody.velocity = Vector2.up * flapStrength;
    }

    private void OnDisable()
    {
        movement.Disable();
        birdInputActions.InGame.FlapWings.Disable();
    }

}

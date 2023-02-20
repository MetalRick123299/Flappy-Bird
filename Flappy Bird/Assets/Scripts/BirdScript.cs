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
    private LogicManger logic;
    public event Action OnGameOver;
    public float flapStrength = 12.5f;

    public bool inGame = true;

    // Start is called before the first frame update
    void Awake()
    {
        birdInputActions = new BirdInputActions();

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManger>();

        birdRigidBody = gameObject.GetComponent<Rigidbody2D>();

        OnGameOver += GameOver;
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

    private void OnCollisionEnter2D(Collision2D other) => OnGameOver?.Invoke();

    private void GameOver()
    {
        inGame = false;
        // Disables Bird Movement
        OnDisable();
    }
}

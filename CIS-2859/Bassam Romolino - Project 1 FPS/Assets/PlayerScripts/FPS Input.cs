using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{

    [SerializeField]
    private float speed = 6.0f;

    [SerializeField]
    private float gravity = -9.8f;

    private CharacterController characterController;

    PlayerCharacter player;

    public const float baseSpeed = 3.0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = GetComponent<PlayerCharacter>();

    }

    void Update()
    {
        if (player.isAlive)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = gravity;
            movement *= Time.deltaTime;

            movement = transform.TransformDirection(movement);
            characterController.Move(movement);
        }
    }

    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGE, OnSpeedChange);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGE, OnSpeedChange);
    }

    private void OnSpeedChange(float value)
    {
        speed = baseSpeed * value;
    }
}

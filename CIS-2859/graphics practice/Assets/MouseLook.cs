using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    [SerializeField]
    private RotationAxes axes = RotationAxes.MouseXAndY;

    [SerializeField]
    private float horizontalSensitivity = 9.0f;

    [SerializeField]
    private float verticalSensitivity = 9.0f;
    [SerializeField]
    private float minimumVert = -45.0f;
    [SerializeField]
    private float maximumVert = 45.0f;

    private float verticalRotation = 0.0f;

    private PlayerCharacter player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        if (player.isAlive)
        {
            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
                verticalRotation = Mathf.Clamp(verticalRotation, minimumVert, maximumVert);

                // keep same Y angle (no horizontal rotation)
                float horizontalRotation = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
            }
            else
            {
                verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
                verticalRotation = Mathf.Clamp(verticalRotation, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * horizontalSensitivity;
                float horizontalRotation = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
            }
        }
    }
}

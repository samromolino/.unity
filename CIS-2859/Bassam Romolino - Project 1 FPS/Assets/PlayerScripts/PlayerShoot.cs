using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject fireballPrefab;

    private GameObject fireball;

    private Camera camera;

    private PlayerCharacter player;


    void Start()
    {        
        camera = GetComponent<Camera>();
        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        if (player.isAlive)
        {
            // 0 is lmb
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                fireball = Instantiate(fireballPrefab) as GameObject;

                fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                fireball.transform.rotation = transform.rotation;

            }

        }
       
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = camera.pixelWidth / 2 - size / 4;
        float posY = camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}


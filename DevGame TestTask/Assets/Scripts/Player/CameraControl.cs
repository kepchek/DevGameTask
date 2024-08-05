using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public Vector2 levelSize = new Vector2(3, 4); // Размер уровня по осям X и Z
    public Vector2 cameraOffset = new Vector2(0, 0); // Смещение камеры относительно игрока

    private Camera cam;
    private float camHalfHeight;
    private float camHalfWidth;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = 7.68f;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = player.position; //+ new Vector3(cameraOffset.x, 0, cameraOffset.y);

        float minX = camHalfWidth - (levelSize.x / 2);
        float maxX = (levelSize.x / 2) - camHalfWidth;
        float minZ = camHalfHeight - (levelSize.y / 2);
        float maxZ = (levelSize.y / 2) - camHalfHeight;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.z = Mathf.Clamp(targetPosition.z, minZ, maxZ);
        targetPosition.y = transform.position.y; // Сохранить текущую высоту камеры

        transform.position = targetPosition;
    }
}

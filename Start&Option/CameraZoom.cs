using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//마우스휠로 플레이어쪽으로 확대 및 축소
public class CameraZoom : MonoBehaviour
{

    public GameObject player;
    public float scrollSpeed = 2000.0f;
    public Vector3 Max;
    public Vector3 Min;

    private void Start()
    {
        Max = new Vector3(32, 35, -8);
        Min = new Vector3(25, 45, 10);
    }

    void Update()
    {
        float zoomDelta = 0f;
#if UNITY_STANDALONE || UNITY_EDITOR
        zoomDelta = Input.GetAxis("Mouse ScroolWheel") * scrollSpeed * Time.deltaTime;

#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 prevTouch0 = touch0.position - touch0.deltaPosition;
            Vector2 prevTouch1 = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (prevTouch0 - prevTouch1).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoomDelta = -difference * scrollSpeed * 0.001f * Time.deltaTime;
        }
#endif
        /*float scroollWheel = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView -= scroollWheel * Time.deltaTime * scrollSpeed;

        if (Camera.main.fieldOfView <=60 && Camera.main.fieldOfView >=45)
        {
            Vector3 cameraDirection = player.transform.localRotation * Vector3.forward;
            Vector3 x = new Vector3(-0.3f, -0.57f, -0.55f);
            transform.position -= cameraDirection * Time.deltaTime * scroollWheel * scrollSpeed;
            transform.position += x * Time.deltaTime * scroollWheel * scrollSpeed;
        }
        else if (Camera.main.fieldOfView < 45)
        {
            Camera.main.fieldOfView = 45;
            transform.position = Max;
        }
        else if (Camera.main.fieldOfView > 60)
        {
            Camera.main.fieldOfView = 60;
            transform.position = Min;
        }*/
    }
}

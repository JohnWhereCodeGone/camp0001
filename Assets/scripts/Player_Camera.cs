using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [Header("Camera Speed")]
    public float CameraSpeedX;
    public float CameraSpeedY;

    [Header("Zoom")]
    public float maxCameraZoom;
    public float minCameraZoom;
    public float smoothZoomDelay;

    [Header("Transformers Optimus Prime Alpha")]
    [Tooltip("Maximum grind")]
    public Transform playerTransform;
    public Transform cameraTransform;

    [Header("Scrollspeed")]
    [Range(1f, 5f)]
    public float scrollSpeed;

    private float currCameraZoomLvl;

    private Coroutine zoomLoop;
    
    #region CameraFunctions
    private void CameraMovement()
    {
        if (Input.GetMouseButton(0) == false && Input.GetMouseButton(1) == false)
        {
            Cursor.lockState = CursorLockMode.Confined;
            return;
        }
        float CAMERA_MOVEMENT_X = Input.GetAxis("Mouse X") * CameraSpeedX;
        float CAMERA_MOVEMENT_Y = Input.GetAxis("Mouse Y") * CameraSpeedY;



        transform.localEulerAngles += new Vector3(CAMERA_MOVEMENT_Y, CAMERA_MOVEMENT_X, 0);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void CameraZoom()
    {
        float scrollDirection = Input.mouseScrollDelta.y;
        if (scrollDirection == 0)
            return;

        currCameraZoomLvl =  Mathf.Clamp(cameraTransform.localPosition.z + (scrollDirection * scrollSpeed), maxCameraZoom, minCameraZoom); 
        
/*        if (zoomLoop == null)
        {

            zoomLoop = StartCoroutine(LerpToNewCameraZoom());
        }*/
    }
/*    private IEnumerator LerpToNewCameraZoom()
    {

        zoomLoop = null;
    }*/


    private void FollowPlayer()
    {
        transform.position = playerTransform.position;

    }
    private void PlayerSnap()
    {
        if (Input.GetMouseButton(1) == false)
            return;
        
        playerTransform.localEulerAngles = new Vector3(
            y:transform.localEulerAngles.y,
            x:playerTransform.localEulerAngles.x,
            z:playerTransform.localEulerAngles.z
            );
        
    }
#endregion


    #region UpdateFunctions
    void Update()
    {
        CameraZoom();
        CameraMovement();
        FollowPlayer();
        PlayerSnap();
     
    }
    #endregion
} 

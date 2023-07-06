using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer;

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
    public float minZoomSpeed;

    [Header("Zoom Smooth")]
    public float zoomSpeedMult;
    /// <summary>
    /// The minimum distance the camera smooth zoom function needs to repeat the loop.
    /// </summary>
    public float minDefaultDistance;
    
    private float curCamTargetPosition;
    [SerializeField]
    private bool zoomLoop;

    public float maxZoomStepSize;
    
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

        curCamTargetPosition =  Mathf.Clamp(cameraTransform.localPosition.z + (scrollDirection * scrollSpeed),
            maxCameraZoom,
            minCameraZoom);

        curCamTargetPosition = Mathf.Clamp(
            curCamTargetPosition,
            cameraTransform.localPosition.z - maxZoomStepSize,
            cameraTransform.localPosition.z + maxZoomStepSize);
        
        if (zoomLoop == false)
        {
            LerpToNewCameraZoom();
        }
    }
    private async void LerpToNewCameraZoom()
    {
        zoomLoop = true;
        float TRAVEL_DISTANCE; 
        while (Mathf.Abs(cameraTransform.localPosition.z - curCamTargetPosition) > minDefaultDistance)
        {
            TRAVEL_DISTANCE = Mathf.Abs(cameraTransform.localPosition.z - curCamTargetPosition);
            TRAVEL_DISTANCE = Mathf.Max(minZoomSpeed, TRAVEL_DISTANCE);
            TRAVEL_DISTANCE *= zoomSpeedMult * Time.deltaTime;
            cameraTransform.localPosition = Vector3.MoveTowards(cameraTransform.localPosition, new Vector3(0, 0, curCamTargetPosition), TRAVEL_DISTANCE);
            await Task.Yield();
        }

        zoomLoop = false;
    }


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
        timer += Time.deltaTime * scrollSpeed;
        CameraZoom();
        CameraMovement();
        FollowPlayer();
        PlayerSnap();
        
    }
    private void LateUpdate()

    {
        FollowPlayer() ;
    }
    private void Start()
    {
        GameManager.SubscribeToPause(Toggle);
    }
    private void OnDestroy()
    {
        GameManager.UnSubscribeToPause(Toggle);
    }

    #endregion
    private void Toggle(bool _State)
    {

        enabled = !_State;
        Cursor.lockState = CursorLockMode.Confined;

    }
    public void SetCameraSpeed(float _NewCameraSpeed)
    {
        scrollSpeed = (_NewCameraSpeed * (5 - 1) + 1);
    }
} 

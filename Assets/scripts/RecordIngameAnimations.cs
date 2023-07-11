using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class RecordIngameAnimations : MonoBehaviour
{
    public AnimationClip clip;

    private GameObjectRecorder m_Recorder;

    public float elevationSpeed;

    [SerializeField]
    private bool isRecording;

    private void cameraDisplacement()
    {
        Vector3 DISPLACE = Vector3.zero;
        DISPLACE += Input.GetAxisRaw("Horizontal") * transform.right;
        DISPLACE += Input.GetAxisRaw("Vertical") * transform.forward;
        DISPLACE += Input.GetAxisRaw("Elevation") * transform.up;
        


        DISPLACE.Normalize();
        DISPLACE *= Time.deltaTime;
        transform.position += DISPLACE * elevationSpeed;
        Debug.Log(DISPLACE);
    }

    private void Update()
    {
        cameraDisplacement();
    }

    void Start()
    {
        // Create recorder and record the script GameObject.
        m_Recorder = new GameObjectRecorder(gameObject);

        // Bind all the Transforms on the GameObject and all its children.
        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isRecording = !isRecording;
        }
        if (isRecording == false)
            return;

        // Take a snapshot and record all the bindings values for this frame.
        m_Recorder.TakeSnapshot(Time.deltaTime);
    }

    void OnDisable()
    {
        if (clip == null)
            return;

        if (m_Recorder.isRecording)
        {
            // Save the recorded session to the clip.
            m_Recorder.SaveToClip(clip);
        }
    }
}

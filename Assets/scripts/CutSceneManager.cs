using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
  [SerializeField]
  private Animator cutscene;
  [SerializeField]
  private List<MonoBehaviour> scriptsToTurnOff;

    public static CutSceneManager instance;

    private Vector3 savedRotation;

    private void Awake()
    {
        instance = this;
    }

    public void StartCutScene()
    {
        cutscene.enabled = true;
        cutscene.SetTrigger("Cutscene");
        savedRotation = cutscene.transform.localEulerAngles;
        foreach (MonoBehaviour script in scriptsToTurnOff)
      {
            script.enabled = false;
            Debug.Log("I'm working!!");
      }
    }
    public async void endCutscene()
    {
        cutscene.enabled = false;
        foreach (MonoBehaviour script in scriptsToTurnOff)
        {

            script.enabled = true;
        }
        await Task.Yield();
        cutscene.transform.localEulerAngles = savedRotation;
    }
}

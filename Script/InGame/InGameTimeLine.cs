using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InGameTimeLine : MonoBehaviour
{
    public PlayableDirector oTimeLine;
    public GameObject oObject;

    public PlayableDirector xTimeLine;
    public GameObject xObject;

    public PlayableDirector changeStageTimeLine;
    public GameObject changeStageObject;

    public PlayableDirector startTimeLine;
    public PlayableDirector stopTimeLine;

    void Start()
    {
        changeStageObject.SetActive(false);
    }

    public void PlayStart()
    {
        startTimeLine.Play();
    }

    public void PlayStop()
    {
        stopTimeLine.Play();
        Invoke(nameof(PlayChangeStage), 2.0f);
        Invoke(nameof(CloseChangeStageObject), 4.5f);
    }

    public void PlayO(Vector3 _vector3)
    {
        oTimeLine.Stop();
        oTimeLine.Play();
        oObject.transform.position = new Vector3(_vector3.x, _vector3.y, -5f);
    }

    public void PlayX(Vector3 _vector3)
    {
        xTimeLine.Stop();
        xTimeLine.Play();
        xObject.transform.position = new Vector3(_vector3.x, _vector3.y, -5f);
    }

    public void PlayChangeStage()
    {
        changeStageObject.SetActive(true);
        changeStageTimeLine.Play();
    }

    private void CloseChangeStageObject()
    {
        changeStageObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraMovement : MonoBehaviour
{
    public GameObject CamGameplay;
    public GameObject CamStart;
    //public Vector3 CamPosition;
    public GameObject Button;

    private void Start()
    {
        CamStart.SetActive(true);
    }


    public void GameStart()
    {
        CamStart.SetActive(false);
        CamGameplay.SetActive(true);
        Button.SetActive(false);
    }

}

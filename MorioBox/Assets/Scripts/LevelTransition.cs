using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class LevelTransition : MonoBehaviour
{
    public int ActiveLevel;

    public Transform Envoirment1;
    public Transform Envoirment2;
    public Transform Envoirment3;
    public Image EndOfLevelLight;
    public GameObject JumpScript;
    public GameObject MainCanvas;
    public GameObject StoreCanvas;

    private void Start()
    {
        
        ActiveLevel = 1;
    }

    public void OpenStore()
    {
        MainCanvas.SetActive(false);
        StoreCanvas.SetActive(true);
    }
    public void CloseStore()
    {
        MainCanvas.SetActive(true);
        StoreCanvas.SetActive(false);
    }

    public void ChangeLevel()
    {
        ActiveLevel ++;
        EndOfLevelLight.color = new Vector4(1,1,1,1);
        EndOfLevelLight.DOFade(0, 2f);
        //EndOfLevelLight.intensity = 500;
        //EndOfLevelLight.DOIntensity(0, 1);
        FindObjectOfType<AudioManagerScript>().Play("NextLevelSound");
        
        switch (ActiveLevel)
        {
            case 2:
                Envoirment1.DOLocalMoveY(-40, 1, true);
                Envoirment2.DOLocalMoveY(0, 1, true).OnComplete(() => 
                {
                    FindAnyObjectByType<Jump>().CanJump = true;
                });             
                break;
            case 3:
                Envoirment2.DOLocalMoveY(-40f, 1, true);
                Envoirment3.DOLocalMoveY(0, 1, true).OnComplete(() =>
                {
                    FindAnyObjectByType<Jump>().CanJump = true;
                }); ;
                break;
            case 4:
                Envoirment1.transform.position = new Vector3(-1.8f, 40, -12);
                Envoirment2.transform.position = new Vector3(-1, 40, -10);
                Envoirment1.DOLocalMoveY(0, 1, true);
                Envoirment3.DOLocalMoveY(-40, 1).OnComplete(() =>
                {
                    Envoirment3.transform.position = new Vector3(-1, 40, -7);
                    FindAnyObjectByType<Jump>().CanJump = true;
                });
                ActiveLevel = 1;
                break;


        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LevelTransition : MonoBehaviour
{
    public GameObject Envoirment1;
    public GameObject Envoirment2;
    public GameObject Envoirment3;
    public GameObject JumpScript;
    public GameObject MainCanvas;
    public GameObject StoreCanvas;
    public void Level2()
    {
        //JumpScript.SetActive(false);
        Envoirment1.transform.DOMove(new Vector3(0, -10, 0), 1);
        
        Envoirment2.transform.DOMove(new Vector3(0, 3, -14), 1);
        FindObjectOfType<AudioManagerScript>().Play("NextLevelSound");
        Invoke("DestroyLevel1", 2f);
    }
    void DestroyLevel1() 
    {
        
        FindAnyObjectByType<Jump>().CanJump = true;
        
        Envoirment1.SetActive(false);
    }

    public void Level3()
    {
        //JumpScript.SetActive(false);
        Envoirment2.transform.DOMove(new Vector3(0, -10, 0), 1);

        Envoirment3.transform.DOMove(new Vector3(0, 3, -14), 1);
        FindObjectOfType<AudioManagerScript>().Play("NextLevelSound");
        Invoke("DestroyLevel2", 2f);
    }
    void DestroyLevel2()
    {

        FindAnyObjectByType<Jump>().CanJump = true;
        Debug.Log("Funciona");
        Envoirment2.SetActive(false);
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

}

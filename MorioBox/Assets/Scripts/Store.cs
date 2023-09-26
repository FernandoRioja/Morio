using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    
    public Transform CharacterPosition;
    
    

    private void Start()
    {
        Character1.SetActive(true);
    }
    public void CharacterChange1()
    {
        Character1.SetActive(true);

        if (Character2 == isActiveAndEnabled || Character3 == isActiveAndEnabled)
        {
            Character2.SetActive(false);
            Character3.SetActive(false);
        }

        

    }

    public void CharacterChange2()
    {
        Character2.SetActive(true);
        if (Character1 == isActiveAndEnabled || Character3 == isActiveAndEnabled)
        {
            Character1.SetActive(false);
            Character3.SetActive(false);
        }
        
        
            
       
    }

    public void CharacterChange3()
    {
        Character3.SetActive(true);
        if (Character1 == isActiveAndEnabled || Character2 == isActiveAndEnabled)
        {
            Character1.SetActive(false);
            Character2.SetActive(false);
        }
        
        
            
        
    }

}

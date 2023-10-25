using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;

    public Transform CharacterPosition;

    private bool owned1;
    private bool owned2;


    private void Start()
    {
        owned1 = false;
        owned2 = false;
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
        if (owned1 == true)
        {
            Character2.SetActive(true);
            if (Character1 == isActiveAndEnabled || Character3 == isActiveAndEnabled)
            {
                Character1.SetActive(false);
                Character3.SetActive(false);
            }
        }

        else
        {
            if (Jump.BrokenBoxes >= 5)
            {
                Jump.BrokenBoxes = Jump.BrokenBoxes - 5;
                owned1 = true;
                Character2.SetActive(true);
                if (Character1 == isActiveAndEnabled || Character3 == isActiveAndEnabled)
                {
                    Character1.SetActive(false);
                    Character3.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Te falta");
            }
        }




    }

    public void CharacterChange3()
    {
        if (owned2 == true)
        {
            Character3.SetActive(true);
            if (Character1 == isActiveAndEnabled || Character2 == isActiveAndEnabled)
            {
                Character1.SetActive(false);
                Character2.SetActive(false);
            }
        }
        else
        {

            if (Jump.BrokenBoxes >= 10)
            {

                Jump.BrokenBoxes = Jump.BrokenBoxes - 10;
                owned2 = true;
                Character3.SetActive(true);
                if (Character1 == isActiveAndEnabled || Character2 == isActiveAndEnabled)
                {

                    Character1.SetActive(false);
                    Character2.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Te falta");
            }
        }




    }

}

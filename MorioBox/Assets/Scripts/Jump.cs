using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jump : MonoBehaviour
{
    //personaje morio
    public Rigidbody MorioRB;
    public int Damage;
    public bool CanJump;
    //Lista de cajas que van a aparecer
    public Boxes[] BoxesDB;

    //Numero que corresponde al puesto en la lista de cajas posibles
    private int SelectedBox;

    //Lugar en el mundo donde aparecen las cajas
    public Transform BoxSpot;

    //Lista en la que se colocan los gameobjects cajas al empezar el juego
    public List<GameObject> Boxes;

    //Cantidad de golpes que la caja necesita
    public int BoxHP;

    //Texto flotante de dano
    public GameObject FloatingText;

    //Controlador de particulas
    public ParticleSystem Dust;
    public ParticleSystem Explosion;
    public ParticleSystem Hit;

    //Animator
    public Animator Anim;

    //Info Text
    
    public int LevelNumber;
    public int BrokenBoxes;
    public TMP_Text TextBox;
    public TMP_Text TextLevel;
    public TMP_Text TextDamage;

    void Start()
    {
        Boxes = new List<GameObject>();
        foreach(var BoxesDB in BoxesDB)
        {
            GameObject gameObject = Instantiate(BoxesDB.BoxType, BoxSpot.position, Quaternion.identity);
            gameObject.SetActive(false);
            Boxes.Add(gameObject);
        }
        
        UpdateBox(SelectedBox);
        BoxHP = BoxesDB[SelectedBox].HP;
        CanJump = true;
        Damage = 1;
        LevelNumber = 1;
        BrokenBoxes = 1;
        
    }

    


    public void JumpButton()
    {
        if(CanJump == true)
        {
            MorioRB.AddForce(0, 100000, 0);
            ShowFloatingText();
            CreateDust();
            
            if (BoxHP != 0)
            {
                HitBox();

            }
            else
            {
                BrokenBoxes++;
                Anim.SetTrigger("FinalJump");
                FindObjectOfType<AudioManagerScript>().Play("FinalBoxSound");
                Damage = Damage + Random.Range(1, 3);
                BoxExplosion();
                NextBox();

                if (BoxesDB[SelectedBox].LevelBox == true)
                {
                    BreakBoxNextLevel();
                }


            }
        }
        UpdateText();
    }

    public void HitBox()
    {
        FindObjectOfType<AudioManagerScript>().Play("HitBoxSound");
        BoxHP = BoxHP - 1;
        Boxes[SelectedBox].gameObject.transform.localScale += new Vector3(0.03f, 0.01f, 0.01f);
    }



    public void BreakBoxNextLevel()
    {

        CanJump = false;
        LevelNumber++;
        Damage = Damage + Random.Range(1, 3);

        FindObjectOfType<LevelTransition>().ChangeLevel();
    }


    public void NextBox()
    {
        if(SelectedBox < 8)
        {

            Boxes[SelectedBox].SetActive(false);
            SelectedBox++;
            Boxes[SelectedBox].SetActive(true);
            BoxHP = BoxesDB[SelectedBox].HP;
            Boxes[SelectedBox].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {

            Boxes[SelectedBox].SetActive(false);
            SelectedBox = 0;
            Boxes[SelectedBox].SetActive(true);
            BoxHP = BoxesDB[SelectedBox].HP;
            Boxes[SelectedBox].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        


        
    }

    private void UpdateBox(int SelectedBox)
    {
        Boxes[SelectedBox].SetActive(true);

        BoxHP = BoxesDB[SelectedBox].HP;
        
    }

    void CreateDust()
    {
        Dust.Play();
        Hit.Play();
    }
    void BoxExplosion()
    {
        Explosion.Play();
    }





    void UpdateText()
    {
        TextDamage.text = "Damage: " + Damage.ToString();
        TextLevel.text = "Level: " + LevelNumber.ToString();
        TextBox.text = "Buck$ : " + BrokenBoxes.ToString();
    }

    void ShowFloatingText()
    {

        var go = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = Damage.ToString();
    }

}

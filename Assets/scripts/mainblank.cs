using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainblank : MonoBehaviour
{
    GameObject controler;
    public Sprite[] fronts;
    public Sprite back;
    SpriteRenderer show;
    public bool match = false;

    public int frontsIndex;
    public void OnMouseDown()
    {
        if(match == false)
        {
            if(show.sprite == back)
            {
                if(controler.GetComponent<Controler>().cardfront() == false)
                {
                    show.sprite = fronts[frontsIndex];
                    controler.GetComponent<Controler>().Addvisiblefront(frontsIndex);
                    match = controler.GetComponent<Controler>().matched();

                }       
                
            }
            else 
            {
                show.sprite = back;
                controler.GetComponent<Controler>().Removevisiblefront(frontsIndex);
            }
        } 

    }
    public void Awake()
    {
        controler = GameObject.Find("Controler");
        show = GetComponent<SpriteRenderer>();
    }
}

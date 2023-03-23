using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    GameObject blanks;
    List<int>frontindexes=new List<int> {0,1,2,3,4,5,6,7,0,1,2,3,4,5,6,7};
    public static System.Random rnd = new System.Random();
    public int shuffle = 0;
    int[] visible = {-1,-2};
    
    void Start()
    {
        int originallength = frontindexes.Count;
        float y = 3.4f;
        float x = -3.3f;
        for(int i = 0; i < 15; i++)
        {
            shuffle = rnd.Next(0, (frontindexes.Count));
            var temp = Instantiate(blanks, new Vector3(
                x, y, 0 ),
                Quaternion.identity);
            temp.GetComponent<mainblank>().frontsIndex = frontindexes[shuffle];
            frontindexes.Remove(frontindexes[shuffle]);
            x = x + 4;
            if (i == (originallength/8))
            {
                y = 1.5f;
                x = -7.3f; 
            }
            // if (i == 4)
            // {
            //     y = -1.5f;
            //     x = -4.2f;
            // }
            if (i == (originallength/8 + 4 ))
            {
                y = -0.5f;
                x = -7.3f;
            }
            if (i == (originallength/8 + 8 ))
            {
                y = -2.5f;
                x = -7.3f;
            }



        }
        blanks.GetComponent<mainblank>().frontsIndex = frontindexes[0];
    }  
    public bool cardfront()
    {
        bool cf = false; 
        if (visible[0] >= 0 && visible[1] >= 0)
        {
            cf = true;

        } 
        return cf;

    }
    public void Addvisiblefront(int index)
    {
        if(visible[0] == -1)
        {
            visible[0] = index;
        }
        else if (visible[1] == -2)
        {
            visible[1] = index;
        }
    }

    public void Removevisiblefront(int index)
    {
         if(visible[0] == index)
        {
            visible[0] = -1;
        }
        else if (visible[1] == index)
        {
            visible[1] = -2;
        }
    }

    public bool matched()
    {
        bool success = false;
        if(visible[0] == visible[1])
        {
            visible[0] = -1;
            visible[1] = -2;
            success = true;

        }
        
        return success;
        
    }



    private void Awake()    
    {
        blanks = GameObject.Find("mainblank");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlanksScriptOne : MonoBehaviour
{

   private  Vector3 [] plankNr= new Vector3[40];
    public GameObject[] Planks;
    public GameObject Player;
    public Collider player;
    private Vector3 posPlayer;
    // Vector3 pa = new Vector3();
     

    void Start()
    {
      //Planks = GameObject.FindGameObjectsWithTag("Plank");
       

        // So I have found a giant error in the code all the coordinats for each plank[i] is the same so I am going to need som help
        for (int i = 0; i < Planks.Length; i++)

        {

            //This works when using The gameObject Planks,
           
         //  plankNr[i] = new Vector3(Planks[i].transform.localPosition.x, Planks[i].transform.localPosition.y, Planks[i].transform.localPosition.z);
           
            plankNr[i].Set(Planks[i].transform.localPosition.x, Planks[i].transform.localPosition.y, Planks[i].transform.localPosition.z);
          //  print("nr " + i + " " + plankNr[i]);
           // Debug.Log(plankNr[2] + plankNr[3]);


        }
        
    }


    // Update is called once per frame
    void Update()
{
        checkPlayerLocation();
      //  playerOnPlank();
    }

    
    void checkPlayerLocation()
    {
        posPlayer = new Vector3 (Player.transform.localPosition.x , Player.transform.localPosition.y , Player.transform.localPosition.z);
      // print( "Player Location is " + Player.transform.localPosition.x + Player.transform.localPosition.y+ Player.transform.localPosition.z);
        OnTriggerEnter(player);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hey ");
    }

    /* void playerOnPlank()
     {
         if (posPlayer.y(plankNr[plankNr.Length]))
         {
             print("RUN!");
         }
     }*/

}
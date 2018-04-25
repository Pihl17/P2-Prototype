using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlanksScriptOne : MonoBehaviour
{
    float fallAmount=0.1f;
   private  Vector3 [] plankNr= new Vector3[40];
    public GameObject[] Planks;
    public GameObject Player;
    public Collider player;
    private Vector3 posPlayer;
    // Vector3 pa = new Vector3();
    int entered;
    int exited;
    float x = 0.4f;
    float y = 0.2f;
    float z = 0.3f;
    Vector3 newPos= new Vector3();

    bool en = false;
    bool noEn = false;
    GameObject []pla;
    

        
        
     
       
    void Start()
    {
      Planks = GameObject.FindGameObjectsWithTag("Plank");
        pla = GameObject.FindGameObjectsWithTag("transformPlank");
        print("pla"+pla);
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
        //Player.transform.localPosition = posPlayer;
    }

    
    void checkPlayerLocation()
    {
        posPlayer = new Vector3(Player.transform.localPosition.x, Player.transform.localPosition.y, Player.transform.localPosition.z);
        if (en == true)
        {
            /*OnTriggerEnter(player);
            posPlayer.Set(Player.transform.localPosition.x, Player.transform.localPosition.y - fallAmount, Player.transform.localPosition.z);
            Player.transform.localPosition = posPlayer;*/

            

        }
        if (noEn == true)
        {
           
              /*  OnTriggerExit(player);
                posPlayer.Set(Player.transform.localPosition.x, Player.transform.localPosition.y + fallAmount, Player.transform.localPosition.z);
                Player.transform.localPosition = posPlayer;*/
            
            
        }
        
        

        // print( "Player Location is " + Player.transform.localPosition.x + Player.transform.localPosition.y+ Player.transform.localPosition.z);
       // Debug.Log(posPlayer);
        //Player.Set(posPlayer.x, posPlayer.y, posPlayer.z);
    }


    void OnTriggerEnter(Collider other)
    {
        en = true;
        noEn = false;
        entered++;
            print("entered " + entered);
      /*  if (other==Player)
        {
           other.transform.localPosition= other.transform.localPosition-2;
        }*/

    //    other.transform.localPosition;
         //   
         //   other.transform.localPosition.z);

        

    }
    void OnTriggerStay(Collider other)
    {
        en = false;
        noEn = false;
    }
    void OnTriggerExit(Collider other)
    {
        exited++;
      
          //  plankNr[].Set(Planks[i].transform.localPosition.x - x, Planks[i].transform.localPosition.y - y, Planks[i].transform.localPosition.z - z);
        
        en = false;
        noEn = true;
       

        print("exited " + exited);

       
    }

  

}
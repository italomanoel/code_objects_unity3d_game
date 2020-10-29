using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle : MonoBehaviour {

    public static int count = 0; //Bottles points click, is static so  belong to the class.
    public static int state;
    public Point destiny; // Bottle next step
    public Text winText;    //Win text

    private int maxCount = 5; //maximum point count
    public int speed; //accelerate the bottle's speed,with "Movetoward".
    
    private bool buttonClick;


    void Start() {
        Bottle.state = 0;
        Bottle.count = 0;
        
        buttonClick = true;
        winText.enabled = false;      
    }

    
    void Update() {
        if (Bottle.state == 1) { 
            //Bottle's movement, inheritance of "Point".
            if (!destiny.isMovetowards)
                transform.position = Vector3.MoveTowards(transform.position, destiny.transform.position, speed * Time.deltaTime);
            else
                transform.position = destiny.transform.position;
            if (transform.position == destiny.transform.position)
                destiny = destiny.next;
        }
    }
    
    
   void OnMouseDown() {
        //Destroy(gameObject);
        Bottle.count++; //because of being static that is one form to declare, class.object.
        print("Contagem de pontos Bottles: " + Bottle.count);
        destiny = destiny.next; //change the direction of the Bottle when clicked, no destruction of object.
        speed++;
        if (Bottle.count >= maxCount)
        {
            Win();
            //Destroy(gameObject);    
        }
    } 

    private void OnGUI() {
        GUI.contentColor = Color.red; //font color of letter.
        GUI.Label(new Rect(150, 15, 200, 25), "Contagem Garrfas " + Bottle.count + " Level " + speed); //position xy scala xy.        
        if (buttonClick) {
            GUI.contentColor = Color.blue; //font color of letter.
            if (GUI.Button(new Rect(200, 50, 120, 20), "Clique para Iniciar"))
            {            
                Bottle.state = 1;
                buttonClick = false;
                Debug.Log("Estado do jogo " + Bottle.state);
            
            }
        }

    }

    private void Win() {
        winText.enabled = true;
        transform.position = destiny.transform.position;
        buttonClick = true;
        Debug.Log("Estado do jogo " + Bottle.state);
        /*Start();*/
    }
    
}

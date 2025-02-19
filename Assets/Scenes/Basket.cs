using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the current screem position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;

        //the camera's position sets how far to push the mouse in 3d
        //if this line causes a NULLreferenceexcpetion, select the Main Camera
        //in the Hierarchy and set itsd tag to main camera in the inspector
        mousePos2D.z = -Camera.main.transform.position.z;

        //convert the x position of this basket to the x position of the mouse
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {//find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            //increase the score
            scoreCounter.score += 100;
        }
    }
}

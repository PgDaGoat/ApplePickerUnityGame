using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")] //Used to describe fields that will not change

    // Prefabfor instantiating apples

    public GameObject applePrefab;

    //speed at which the appletree moves

    public float speed = 1f;

    //distance where the AppleTree turns around

    public float leftAndRightEdge = 10f;

    //Vhancethat the AppleTree will change directions

    public float changeDirChance = 0.1f;

    //seconds betweem apples instantiations

    public float appleDropDelay = 1f;

    void Start()
    {
        //start dropping apples
        Invoke("DropApple", 2f);//2f tells the function to wait 2 seconds before repeated process written below(before it valls the function dropApple()
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke( "DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        }
       // else if (Random.value < changeDirChance)
       // {
          //  speed *= -1; //change direction
        }
    
    void FixedUpdate()
{
    if ( Random.value < changeDirChance ) {
        speed *= -1;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyEnemy : MonoBehaviour {
    private int points;
    public Canvas scoreCanvas;
    private bool isScoreCanvasActive;
    public GameObject scoreCanvas2;

    private void OnCollisionEnter(Collision collision)
    {
        //scoreCanvas.enabled = true;
        if (collision.transform.tag == "Enemy")
        {
            
            Destroy(collision.gameObject);
   
            //gameObject.SetActive(true);
            //SumScore.Add(10);
            
            

        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using System;

public class Voice : MonoBehaviour {
    [SerializeField]
    public Rigidbody cannonBall;
    [SerializeField]
    public Transform firePoint;

    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();

    private KeywordRecognizer keywordRecognizer;

	// Use this for initialization
	void Start () {
        keywordActions.Add("fire", Fire);
        keywordActions.Add("turn right", TurnRight);
        keywordActions.Add("turn left", TurnLeft);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
	}
	
    private void OnKeywordsRecognized (PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void TurnLeft()
    {
        transform.Rotate(0f, -10f, 0f);
    }


    private void TurnRight()
    {
        transform.Rotate(0f, -10f, 0f);
    }

    private void Fire()
    {
        var ball = Instantiate(cannonBall, firePoint.position, firePoint.rotation) as Rigidbody;
        ball.AddForce(firePoint.transform.forward * 500f);

    }

    // Update is called once per frame
    void Update () {
		
	}





 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using System;

public class VoiceControll : MonoBehaviour {

    [SerializeField]
    private Rigidbody cannonBall;
    [SerializeField]
    private Transform firePoint;
    public GameObject lightSpot;
    public AudioSource _AudioSource; 


    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();

    private KeywordRecognizer keywordRecognizer;

    // Use this for initialization
    void Start()
    {
        keywordActions.Add("fire", Fire);
        keywordActions.Add("turn right", TurnRight);
        keywordActions.Add("turn left", TurnLeft);
        keywordActions.Add("lights on", LightsOn);
        keywordActions.Add("lights off", LightsOff);
        keywordActions.Add("Play some music", PlayMusic);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void TurnLeft()
    {
        transform.Rotate(0f, -20f, 0f);
    }


    private void TurnRight()
    {
        transform.Rotate(0f, 20f, 0f);
    }

    private void Fire()
    {
        var ball = Instantiate(cannonBall, firePoint.position, firePoint.rotation) as Rigidbody;
        ball.AddForce(firePoint.transform.forward * 500f);

    }


    private void LightsOn()
    {
        lightSpot.SetActive(true);
    }

    private void LightsOff()
    {
        lightSpot.SetActive(false);
    }

    private void PlayMusic()
    {
        _AudioSource.Play();
    }

    

    // Update is called once per frame
    void Update()
    {

    }






}
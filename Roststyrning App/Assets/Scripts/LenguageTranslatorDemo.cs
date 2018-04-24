using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Watson.DeveloperCloud.Services.LanguageTranslator.v2;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.Connection;

public class LenguageTranslatorDemo : MonoBehaviour {

    public Text ResponseTextField;

    private LanguageTranslator _languageTranslator;
    private string _translationModel = "en-es";

	// Use this for initialization
	void Start () {
        LogSystem.InstallDefaultReactors();
        Credentials languageTranslatorCredencials = new Credentials()
        {
            Username = "bf04a455-4014-4df5-9fd7-aef7578e718e",
            Password = "dk5n7Zrnsibz",
            Url = "https://gateway.watsonplatform.net/language-translator/api",
            
        };

        _languageTranslator = new LanguageTranslator(languageTranslatorCredencials);


        

	}
	
	public void Translate(string text)
    {
        _languageTranslator.GetTranslation(OnTranslate, OnFail, text, _translationModel); 
    }

    private void OnTranslate (Translations response, Dictionary<string, object>customData)
    {
        ResponseTextField.text = response.translations[0].translation;
    }

    private void OnFail(RESTConnector.Error error, Dictionary<string, object>customData)
    {
        Log.Debug("LenguageTranslatorDemo.OnFail()", "Error:{0}", error.ToString());
    }



}
 
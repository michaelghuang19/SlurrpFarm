using System;
using System.Collections;
using System.Collections.Generic;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerOpen : MonoBehaviour {
    [SerializeField]
    Canvas UICanvas;
    [SerializeField]
    Canvas DiscountCanvas;
    public Canvas settingsCanvas;

    private AmazonDynamoDBClient client;
    private CognitoAWSCredentials credentials;
    private DynamoDBContext Context;
    private String discCode;

    void Awake () {
        UnityInitializer.AttachToGameObject (this.gameObject);
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
    }
    // Start is called before the first frame update
    void Start () {

        credentials = new CognitoAWSCredentials (
            "us-west-2:a7272201-d02b-449c-9dca-abeaeb7a5e4a", // Identity pool ID
            RegionEndpoint.USWest2 // Region
        );
        client = new AmazonDynamoDBClient (credentials, RegionEndpoint.USWest2);
        Context = new DynamoDBContext (client);

        discCode = "No Codes Available";
        settingsCanvas.gameObject.SetActive (false);
        bool levelledUp = Convert.ToBoolean (PlayerPrefs.GetInt ("LevelChanged"));
        if (levelledUp) {
            Text codeText = GameObject.Find ("/PopupCanvas/PopupBackground/Code").GetComponent<Text> ();
            codeText.text = genCode ();
            UICanvas.gameObject.SetActive (false);
            DiscountCanvas.gameObject.SetActive (true);
            codeText.text = discCode;
        } else {
            UICanvas.gameObject.SetActive (true);
            DiscountCanvas.gameObject.SetActive (false);
        }
    }

    private String genCode () {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new System.Random ();

        for (int i = 0; i < stringChars.Length; i++) {
            stringChars[i] = chars[random.Next (chars.Length)];
        }

        var finalString = new String (stringChars);
        CodeClass code = new CodeClass {
            Code = finalString,
            Uses = 1
        };
        discCode = finalString;

        bool codeAvail = false;

        Context.SaveAsync (code, (result) => {
            if (result.Exception == null) {
                codeAvail = true;
                Debug.Log ("Save worked: aval " + codeAvail);
            } else {
                Debug.Log ("AWS Error: " + result.Exception);
            }
        });
        Debug.Log("Avail: " + codeAvail);
        if (codeAvail) { return finalString; } else { return "No Codes Available"; }
    }

}

[DynamoDBTable ("SlurrpFarm")]
public class CodeClass {
    [DynamoDBHashKey] // Hash key.
    public string Code { get; set; }

    [DynamoDBProperty]
    public int Uses { get; set; }

}
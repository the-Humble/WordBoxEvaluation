using System;
using System.Collections;
using Model;
using UnityEngine;
using UnityEngine.Networking;

public class JSONReader : MonoBehaviour
{
    private string _jsonURL = "https://randomuser.me/api/?results=50";

    private void Start()
    {
        StartCoroutine(getJsonData(_jsonURL));
    }

    IEnumerator getJsonData(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    string jsonData = webRequest.downloadHandler.text;
                    Debug.Log(":\nReceived: " + jsonData);

                    PeopleModel people = JsonUtility.FromJson<PeopleModel>(jsonData);

                    foreach (PersonModel person in people.results)
                    {
                        
                    }
                        
                    
                    break;
            }
        }
    }
}

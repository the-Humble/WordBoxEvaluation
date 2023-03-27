using System.Collections;
using System.Collections.Generic;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FriendPanel : MonoBehaviour
{
    public int ID { get; private set; }
    public RawImage _rawImage;
    public TextMeshProUGUI _textBox;
    public Button _likeButton;
    
    
    public void Initialize(int id, PersonModel person)
    {
        ID = id;
        StartCoroutine(DownloadImage(person.picture.large));
        _textBox.text = person.name.first + " " + person.name.last;
    }
    
    IEnumerator DownloadImage(string imageURL)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageURL))
        {
            yield return request.SendWebRequest();
            if(request.isNetworkError || request.isHttpError) 
                Debug.Log(request.error);
            else
                _rawImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
        }
    } 
}

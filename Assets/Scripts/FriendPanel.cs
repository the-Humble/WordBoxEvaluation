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
    public PersonModel _personModel;
    public RawImage _rawImage;
    public TextMeshProUGUI _textBox;
    public Button _likeButton;

    public Texture _friendImage;
    
    public PersonModelEvent _inspectSpecificFriend;
    
    public void Initialize(int id, PersonModel person)
    {
        ID = id;
        _personModel = person;
        StartCoroutine(DownloadImage(_personModel.picture.large));
        _textBox.text = _personModel.name.first + " " + _personModel.name.last;
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

    public void InspectSpecificFriend()
    {
        if (_personModel == null)
        {
            return;
        }
        _inspectSpecificFriend.Invoke(_personModel);
    }
}

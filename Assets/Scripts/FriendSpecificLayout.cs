using System.Collections;
using System.Collections.Generic;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FriendSpecificLayout : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _email;
    [SerializeField] private TextMeshProUGUI _gender;
    [SerializeField] private TextMeshProUGUI _age;
    [SerializeField] private TextMeshProUGUI _city;
    
    public void InitializeInfo(PersonModel personModel)
    {
        _name.text = personModel.name.first + " " + personModel.name.last;
        _email.text = personModel.email;
        _gender.text = personModel.gender;
        _age.text = personModel.dob.age.ToString();
        _city.text = personModel.location.city;

        StartCoroutine(DownloadImage(personModel.picture.large));
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

    public void ToggleOff()
    {
        gameObject.SetActive(false);
    }
    
    
}

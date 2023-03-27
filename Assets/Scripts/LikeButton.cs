using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeButton : MonoBehaviour
{
    [SerializeField] private bool _isLiked = false;

    [SerializeField] public Sprite _likedImage;
    [SerializeField] public Sprite _notLikedImage;
    
    
    public void toggleLiked()
    {
        _isLiked = !_isLiked;

        gameObject.GetComponent<Image>().sprite = _isLiked ? _likedImage : _notLikedImage;
    }
}

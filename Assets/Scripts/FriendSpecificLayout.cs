using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class FriendSpecificLayout : MonoBehaviour
{
    public void ToggleOn(PersonModel personModel)
    {
        gameObject.SetActive(true);
    }

    public void ToggleOff()
    {
        gameObject.SetActive(false);
    }
}

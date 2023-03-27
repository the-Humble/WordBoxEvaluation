using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using Zenject;

public class FriendListViewer : MonoBehaviour
{
    [SerializeField]
    private GameObject _friendViewPrefab;

    [Inject]
    public void Construct(GameObject friendViewPrefab)
    {
        _friendViewPrefab = friendViewPrefab;
    }

    public void PopulateFriendList(PeopleModel peopleModel)
    {
        int cardID = 0;
        foreach (PersonModel person in peopleModel.results)
        {
            FriendPanel friendPanel = GameObject.Instantiate(_friendViewPrefab, transform).GetComponent<FriendPanel>();
            friendPanel.Initialize(cardID, person);
        }
    }
}

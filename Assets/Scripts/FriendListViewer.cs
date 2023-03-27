using Model;
using UnityEngine;
using Zenject;

public class FriendListViewer : MonoBehaviour
{
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
            FriendPanel friendPanel = Instantiate(_friendViewPrefab, transform).GetComponent<FriendPanel>();
            friendPanel.Initialize(cardID, person);
        }
    }
}

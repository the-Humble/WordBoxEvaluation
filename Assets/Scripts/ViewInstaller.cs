using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _friendViewPrefab;
    
    public override void InstallBindings()
    {
        Container.Bind<GameObject>().FromInstance(_friendViewPrefab);
    }
}

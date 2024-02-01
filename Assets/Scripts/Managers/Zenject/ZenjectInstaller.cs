using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller 
{
    //public AudioManager audioManager;


    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();
        //Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManager).AsSingle();
    }
}

﻿using UnityEngine;
using Zenject;

namespace Baku.VMagicMirror.Installer
{
    /// <summary> デバイスの座標周りの処理をインジェクトしてくれるすごいやつだよ </summary>
    public class DevicesInstaller : InstallerBase, IDevicesRoot
    {
        [SerializeField] private SmallGamepadProvider gamepadProvider = null;
        [SerializeField] private KeyboardProvider keyboardProvider = null;
        [SerializeField] private TouchPadProvider touchPadProvider = null;
        [SerializeField] private MidiControllerProvider midiControllerProvider = null;
        [SerializeField] private ParticleStore particleStore = null;

        public Transform Transform => transform;
        
        public override void Install(DiContainer container)
        {
            //prefabの各要素がワールド直下じゃなくてこのオブジェクト以下にぶら下がれるように、親っぽい雰囲気を出しておく
            container.Bind<IDevicesRoot>().FromInstance(this).AsCached();
            container.Bind<SmallGamepadProvider>().FromComponentInNewPrefab(gamepadProvider);
            container.Bind<KeyboardProvider>().FromComponentInNewPrefab(keyboardProvider);
            container.Bind<TouchPadProvider>().FromComponentInNewPrefab(touchPadProvider);
            container.Bind<MidiControllerProvider>().FromComponentInNewPrefab(midiControllerProvider);
            container.Bind<ParticleStore>().FromComponentInNewPrefab(particleStore);
        }
    }

    public interface IDevicesRoot
    {
        Transform Transform { get; }
    }
}

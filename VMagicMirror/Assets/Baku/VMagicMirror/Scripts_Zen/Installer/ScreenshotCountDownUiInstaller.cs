﻿using UnityEngine;
using Zenject;

namespace Baku.VMagicMirror.Installer
{
    public class ScreenshotCountDownUiInstaller : InstallerBase
    {
        [SerializeField] private ScreenshotCountDownCanvas countDownCanvas = null;
        public override void Install(DiContainer container)
        {
            container.BindInstance(countDownCanvas);
        }
    }
}

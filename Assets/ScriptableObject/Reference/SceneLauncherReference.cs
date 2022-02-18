using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reference/SceneLauncherReference")]
public class SceneLauncherReference : Reference<SceneLauncher> {
    public void ReloadCurrentScene() => Instance.ReloadCurrentScene();
}

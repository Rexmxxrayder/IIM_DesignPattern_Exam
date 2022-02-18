using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLauncherSetter : MonoBehaviour {
    [SerializeField] SceneLauncher _scenelauncher;
    [SerializeField] SceneLauncherReference _scenelauncherRef;

    void Awake() {
        (_scenelauncherRef as IReferenceSetter<SceneLauncher>).SetInstance(_scenelauncher);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reference/ControlShakeReference")]
public class ControlShakeReference : Reference<ControlShake> {
    public void LaunchScreenShake() => Instance?.LaunchScreenShake();
}

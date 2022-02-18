using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour {
    [SerializeField] GameObject _feedback;
    [SerializeField] float _feedbackTime;

    public IEnumerator ShowFeedback() {
        if (_feedbackTime <= 0) yield break;
        _feedback.SetActive(true);
        yield return new WaitForSeconds(_feedbackTime);
        _feedback.SetActive(false);
    }
}

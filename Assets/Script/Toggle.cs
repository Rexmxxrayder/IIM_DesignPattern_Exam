using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Toggle : MonoBehaviour, ITouchable
{
    // Je veux ouvrir un évènement pour les designers pour qu'ils puissent set la couleur du sprite eux même
    [SerializeField] UnityEvent _onToggleOn;
    [SerializeField] UnityEvent _onToggleOff;
    [SerializeField] Color _colorOn;
    [SerializeField] Color _colorOff;
    [SerializeField] SpriteRenderer sr = null;
    private void Start() {
        UpdateColor();
    }
    public bool IsActive { get; private set; }

    public void Touch(int power)
    {
        IsActive = !IsActive;
        if (IsActive) {
            _onToggleOn.Invoke();
        } else {
            _onToggleOff.Invoke();
        }
        UpdateColor();
    }

    public void UpdateColor() {
        if (IsActive) {
            sr.color = _colorOn;
        } else {
            sr.color = _colorOff;
        }
    }
}

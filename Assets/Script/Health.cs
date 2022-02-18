using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth {
    // Champs
    [SerializeField] List<Slider> sliders = new List<Slider>();
    [SerializeField] List<Feedback> feedbacks = new List<Feedback>();
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] UnityEvent _onDeath;
    [SerializeField] UnityEvent<int> _onDamage;
    [SerializeField] bool _isShield;

    // Propriétés
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsDead => CurrentHealth <= 0;
    public bool IsShield { get => _isShield; set => _isShield = value; }

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage { add => _onDamage.AddListener(value); remove => _onDamage.RemoveListener(value); }
    public event UnityAction OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }

    // Methods
    void Awake() => Init();

    void Init() {
        CurrentHealth = _startHealth;
        OnSpawn?.Invoke();
        for (int i = 0; i < feedbacks.Count; i++) {
            OnDamage += (int c) => StartCoroutine(feedbacks[i].ShowFeedback());
        }
    }

    public void TakeDamage(int amount) {
        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");
        if (_isShield) return;
        var tmp = CurrentHealth;
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        var delta = CurrentHealth - tmp;
        _onDamage?.Invoke(delta);
        UpdateSliders();

        if (CurrentHealth <= 0) {
            _onDeath?.Invoke();
        }
    }
    public void Heal(int amount) {
        if(amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        UpdateSliders();
    }

    void UpdateSliders() {
        for (int i = 0; i < sliders.Count; i++) {
            sliders[i].value = CurrentHealth / (float)MaxHealth;
        }
    }
    [Button("test")]
    void MaFonction() {
        var enumerator = MesIntPrefere();

        while (enumerator.MoveNext()) {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere() {

        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;



        //
        yield break;
    }





}

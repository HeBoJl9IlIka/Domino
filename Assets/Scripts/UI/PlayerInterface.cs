using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _money; 

    private void OnEnable()
    {
        _playerWallet.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _playerWallet.Changed -= OnChanged;
    }

    private void OnChanged(int money)
    {
        _money.text = money.ToString();
    }
}

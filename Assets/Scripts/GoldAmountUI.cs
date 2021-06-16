using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldAmountUI : MonoBehaviour
{
   private TextMeshProUGUI _textMeshProUGUI;

   private Bank bank;

   private void Start()
   {
      _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
      bank = FindObjectOfType<Bank>();
   }

   private void Update()
   {
      _textMeshProUGUI.text = bank.CurrentBalance.ToString();
   }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
   [SerializeField] private int maxHitPoints = 5;
   
   [Tooltip("Adds amount to max hitpoints when enemy dies")]
   [SerializeField] private int difficultyRamp = 1;
   
   private int currentHitPoints = 0;

   private Enemy enemy;

   private void Start()
   {
      enemy = GetComponent<Enemy>();
   }

   private void OnEnable()
   {
      currentHitPoints = maxHitPoints;
   }

   private void OnParticleCollision(GameObject other)
   {
      ProcessHit();
   }

   private void ProcessHit()
   {
      currentHitPoints--;
      if (currentHitPoints <= 0)
      {
         gameObject.SetActive(false);
         maxHitPoints += difficultyRamp;
         enemy.RewardGold();
      }
   }
}

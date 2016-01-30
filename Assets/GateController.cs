﻿using Assets.Scripts.GameStates;
using GameStateManagement;
using System.Collections;
using UnityEngine;

namespace Assets
{
    [RequireComponent(typeof(Animator))]
    public class GateController : MonoBehaviour
    {
        #region Editor Variables
        public GameObject InvisibleWall;
        #endregion

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if(coll.gameObject.layer == 8)
            {                
                _animator.SetTrigger("Close");
                InvisibleWall.SetActive(true);
                StartCoroutine(TransitionGameState());
            }
        }

        IEnumerator TransitionGameState()
        {
            yield return new WaitForSeconds(2.0f);
            GameStateManager.Instance.TransitionToGameState<FightingState>();
        }
    }
}

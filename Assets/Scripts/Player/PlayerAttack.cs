using Assets.Scripts.Booster;
using Assets.Scripts.Character;
using Assets.Scripts.InputCharacter;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAttack : CharacterAttack
    {
        [SerializeField] protected InputCtrl input;

        private void Awake()
        {
            input = GetComponent<InputCtrl>();
            attackRange = GetComponent<AttackRange>();
        }
        private void Start()
        {
            SetProperties();
        }
        protected override void SetProperties()
        {
            attackRange.SetProperties(45, 10);
            attackDelay = 0;
            m_attackDelay = 0;
            percentIncrease = 5;
        }
        private void Update()
        {
            ReadyAttack();
            attackRange.SetOrigin(transform.position + Vector3.up + transform.forward / 3);
            attackRange.SetForward(transform.forward);

        }

    }
}


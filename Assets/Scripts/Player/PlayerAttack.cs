using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAttack : CharacterAttack
    {
        private void Awake()
        {
            attackRange = GetComponent<AttackRange>();
        }
        private void Start()
        {
            SetProperties();
        }
        protected override void SetProperties()
        {
            //Degree and Distance check
            attackRange.SetProperties(45, 10);
            attackDelay = 0;
            m_attackDelay = 0;
        }
        private void Update()
        {
            ReadyAttack();
            attackRange.SetOrigin(transform.position + Vector3.up + transform.forward / 3);
            attackRange.SetForward(transform.forward);
        }
    }
}


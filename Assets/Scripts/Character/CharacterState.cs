using Assets.Scripts.StateControl;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterState : MonoBehaviour
    {
        public StateMovement stateMove;
        public StateAttack stateAttack;
        public StateBooster stateBooster;

        public StateMovement GetStateMove { get => stateMove; }
        public StateAttack GetStateAttack { get => stateAttack; }
        public StateBooster GetStateBooster { get => stateBooster; }

    }
}

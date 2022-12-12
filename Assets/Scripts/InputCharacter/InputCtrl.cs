using Assets.Scripts.Interface;
using UnityEngine;
namespace Assets.Scripts.InputCharacter
{
    public class InputCtrl : MonoBehaviour, IInput
    {
        public Vector2 direction { get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
        public bool attack { get => Input.GetMouseButtonDown(0); }

        public bool useBoosterFastTrack;
        public bool useBoosterRot;
        public bool useBoosterSheildUp;
        public bool useBoosterShockwave;
    }
}

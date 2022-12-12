using Assets.Scripts.Character;
using UnityEngine;
namespace Assets.Scripts.AnimationControl
{
    public class AnimControl : MonoBehaviour
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected CharacterState state;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            state = GetComponentInParent<CharacterState>();
        }

        private void LateUpdate()
        {
            
        }
    }
}

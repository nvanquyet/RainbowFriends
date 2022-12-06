using UnityEngine;


namespace Assets.Scripts.Interface
{
    public interface IMove 
    {
        void MoveCharacter(Vector2 direction);

        void Booster_FastTrack(float time);
        void Booster_Rot(float time);
    }
}


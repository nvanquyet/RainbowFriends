using UnityEngine;


namespace Assets.Scripts.Interface
{
    public interface IMove 
    {
        void MoveCharacter(Vector2 direction);
        void Booster_FastTrack(float time);
        void Booster_Rot(float time);
        void ReduceBooster_FastTrack();
        int GetNumberTurn_Booster_FastTrack();
        int GetNumberTurn_Booster_Rot();     
        void ReduceBooster_Rot();
        void SetNumberTurn_Booster_FastTrack(int numberTurn);
        void SetNumberTurn_Booster_Rot(int numberTurn);
        void NoMove(float time);
    }
}


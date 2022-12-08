namespace Assets.Scripts.Interface
{
    public interface IAttack 
    {
        void Attack();
        void Booster_Shockwave(float distance);
        int GetNumberTurn_Booster_Shockwave();
        void ReduceBooster_Shockwave();
        void SetNumberTurn_Booster_Shockwave(int numberTurn);
    }
}


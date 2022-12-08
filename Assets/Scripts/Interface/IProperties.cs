namespace Assets.Scripts.Interface
{
    public interface IProperties 
    {
        void Booster_SecondLife();
        void Booster_ShieldUp(float time);
        int GetNumberLife();
        void SetNumberLife(int number);
        bool IsAlive();
        void Dead();
    }
}


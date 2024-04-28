namespace Core.LevelSystems
{
    public interface ILevelStarter
    {
        void StartLevel();
    }
    public interface ILevelPauser
    {
        void PauseLevel();
        void UnPauseLevel();
    }
    public enum FinishReason
    {
        Win,
        Lose,
        Break
    }
    public interface ILevelFinisher
    {
        void FinnishLevel(FinishReason finishReason);
    }
}

using UnityEngine;

namespace Core.LevelSystems
{
    public class LevelPauser : ILevelPauser
    {
        readonly float fixedDelta;
        public LevelPauser()
        {
            fixedDelta = Time.fixedDeltaTime;
        }
        public void PauseLevel()
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }

        public void UnPauseLevel()
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDelta;
        }
    }
}
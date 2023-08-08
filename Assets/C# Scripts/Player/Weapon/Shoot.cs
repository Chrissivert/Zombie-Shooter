
    using UnityEngine;

    public class Shoot : MonoBehaviour
    {
        public PointAndShoot pointAndShoot;
        

        public void PistolShot()
        {
            pointAndShoot.Bullet(pointAndShoot.GetNormalizedVector2FromPlayerPosToCrosshair());
        }

        public void ShotgunShot()
        {
            pointAndShoot.SpreadBullets(pointAndShoot.GetNormalizedVector2FromPlayerPosToCrosshair());
        }
        
        public void GrenadeShot()
        {
            pointAndShoot.InstantiateGrenade();
        }
    }
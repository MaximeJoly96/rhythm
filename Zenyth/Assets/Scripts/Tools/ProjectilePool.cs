using Zenyth.Models;

namespace Zenyth.Tools
{
    public class ProjectilePool : ObjectPool<Projectile>
    {
        protected override void CleanUp(Projectile obj)
        {
            obj.CleanUp();
        }

        protected override Projectile Instantiate()
        {
            return Projectile.Instantiate();
        }
    }
}


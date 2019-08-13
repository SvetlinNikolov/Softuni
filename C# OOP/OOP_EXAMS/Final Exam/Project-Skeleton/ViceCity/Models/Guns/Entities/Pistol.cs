using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns.Entities
{
    public class Pistol : Gun, IGun
    {
        private const int BULLETS_PER_BARREL = 10;
        private const int TOTAL_BULLETS = 100;


        public Pistol(string name)
            : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }

        public override int Fire()
        {
            if (this.CanFire)
            {
                this.BulletsPerBarrel -= 1;
                return 1;
            }

            else if (this.CanFire == false)
            {
                if (this.TotalBullets > 0)
                {
                    //This could be <=
                    while (this.TotalBullets > 0
                        && this.BulletsPerBarrel < BULLETS_PER_BARREL)
                    {
                        this.TotalBullets--;
                        this.BulletsPerBarrel++;
                    }

                    this.BulletsPerBarrel -= 1;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            //Dont know about this one rick;
            return 0;
        }
    }
}

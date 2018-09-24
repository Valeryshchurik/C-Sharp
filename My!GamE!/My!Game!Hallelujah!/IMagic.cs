using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_The_Year
{
    interface IMagic //интерфейс "волшебство"
    {
        void SaySpell();
        void SaySpell(Hero hero);
        void SaySpell(Hero hero, int power);
    }
}

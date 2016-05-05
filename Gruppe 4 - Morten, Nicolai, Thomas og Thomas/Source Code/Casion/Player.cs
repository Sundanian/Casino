using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casion
{
    class Player
    {
        int id;
        string name;
        int money;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        public Player(int id, string name, int money)
        {
            this.id = id;
            this.name = name;
            this.money = money;
        }
    }
}

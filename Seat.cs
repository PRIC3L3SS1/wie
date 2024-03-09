using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace hw3_conkin
{
    public class Seat
    {
        private int number;
        private Person owner;

        public Seat(int number, Person owner)
        {
            Number = number;
            Owner = owner;
        }

        public int Number
        {
            get => number;
            set
            {
                number = value;
            }
        }

        public Person Owner
        {
            get => owner;
            set
            {
                owner = value;
            }
        }

        public int getCost()
        {
            if (owner != null)
            {
                if (owner.Age <= 12)
                {
                    return 5; // seat owner is 12 or under
                }
                return 10; // seat owner is older than 12
            }
            return 0; // seat has no owner
        }
    }
}
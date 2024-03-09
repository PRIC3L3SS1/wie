using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace hw3_conkin
{
    public class Person
    {
        private string name;
        private int age;
        private Seat seat;
        //private int purchaseId;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            //PurchaseId = purchaseId;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value; 
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value >= 0) 
                {
                    age = value;
                }
            }
        }

        public Seat Seat
        {
            get => seat;
            set
            {
                seat = value; 
            }
        }

        //public int PurchaseId
        //{
        //    get => purchaseId;
        //    set
        //    {
        //        purchaseId = value;
        //    }
        //}

    }
}
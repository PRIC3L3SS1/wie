using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.Media;

namespace hw3_conkin
{
    public class Event
    {
        private string eventName;
        private List<Seat> seats;
        private List<Person> eventGoers;
        private string color = "#161616";
        private SoundPlayer sound = null;

        public Event(string eventName, int minSeat, int maxSeat, List<Person> eventGoers)
        {
            this.eventName = eventName ?? "None";
            seats = generateSeats(minSeat, maxSeat) ?? new List<Seat>();
            this.eventGoers = eventGoers ?? new List<Person>();
        }



        public string EventName
        {
            get => eventName;
            set
            {
                eventName = value;
            }
        }

        public List<Seat> Seats
        {
            get => seats;
            set
            {
                seats = value;
            }
        }

        public List<Person> EventGoers
        {
            get => eventGoers;
            set
            {
                eventGoers = value;
            }
        }

        public string Color
        {
            get => color;
            set
            {
                color = value;
            }
        }

        public SoundPlayer Sound
        {
            get => sound;
            set
            {
                sound = value;
            }
        }

        public List<Seat> generateSeats(int min, int max)
        {
            List<Seat> generatedSeats = new List<Seat>();
            for (int i = 0; i < (max - min) + 1; i++)
            {
                
                Seat newSeat = new Seat(min + i, owner: null);
                generatedSeats.Add(newSeat);
            }
            return generatedSeats;
        }

        public int getNumberOfAttendees()
        {
            return eventGoers.Count;
        }

        public void assignSeat(int Seat, Person person)
        {
            for (int i = 0; i < seats.Count; i++)
            {
                if (seats[i].Number == Seat)
                {
                    seats[i].Owner = person;
                }
            }
        }

        public void assignSeat(Seat Seat, Person person)
        {
            eventGoers.Add(person);
            seats[seats.IndexOf(Seat)].Owner = person;
        }

        public List<Person> GetSortedEventGoers(int sortType)
        {
            List<Person> sortedEventGoers;

            switch (sortType)
            {
                case 0: // Return unsorted list
                    sortedEventGoers = new List<Person>(eventGoers); // Create a copy
                    break;
                case 1: // Name Sort
                    sortedEventGoers = new List<Person>(eventGoers);
                    sortedEventGoers.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase));
                    break;
                case 2: // Seat Number Sort
                    sortedEventGoers = new List<Person>(eventGoers);
                    sortedEventGoers.Sort((p1, p2) => p1.Seat.Number.CompareTo(p2.Seat.Number));
                    break;
                default:
                    sortedEventGoers = new List<Person>(eventGoers); // Default to unsorted
                    break;
            }

            return sortedEventGoers;
        }


        public List<Seat> getAvailableSeats()
        {
            if (seats == null)
            {
                seats = new List<Seat>();
            }
            List<Seat> availableSeats = new List<Seat>();
            foreach (Seat seat in seats)
            {
                if (seat.Owner == null)
                {
                    availableSeats.Add(seat);
                }
            }
            
            return availableSeats;
        }

        public int getTicketsAvailable()
        {
            return seats.Count - eventGoers.Count;
        }

        public int getTotalPriceOfTicketsSold()
        {
            int total = 0;
            foreach (Seat seat in seats)
            {
                total += seat.getCost();
            }
            return total;
        }

        public double getAverageTicketCost()
        {
            return (double) getTotalPriceOfTicketsSold() / getNumberOfAttendees();
        }

    }
}
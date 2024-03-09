using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw3_conkin
{
    public partial class summary : System.Web.UI.Page
    {
        Event newEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                eventName.Text = "None";
                personToRemove.Items.Insert(0, new ListItem("Choose Person to Remove", "0"));
                if (Session["event"] != null)
                {
                    loadSavedSession();

                }
                else
                {
                    updateEventSummary();
                }
            }
            else
            {
                newEvent = (Event)Session["event"];
                updateEventSummary();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            if (Session["event"] != null)
            {
                newEvent = (Event)Session["event"];
                body.Style["background-color"] = newEvent.Color;
                if (newEvent.Color == "hotpink")
                {

                    loadSpecialConcert();
                    //string script = "let audio = new Audio('wieMusic.wav'); audio.play();";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "PlayAudio", script, true);
                }
            }

        }

        private void loadSavedSession()
        {
            newEvent = (Event)Session["event"];
            eventName.Text = newEvent.EventName;
            updateEventSummary();
            updatePeopleToRemove(0);
        }

        protected void sortList_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEventSummary();
            updatePeopleToRemove(sortList.SelectedIndex);
        }

        protected void removePerson_Click(object sender, EventArgs e)
        {
            if (personToRemove.SelectedItem != null && personToRemove.SelectedItem.Text != "Choose Person to Remove")
            {
                for (int i = newEvent.EventGoers.Count - 1; i >= 0; --i)
                {
                    if (personToRemove.SelectedValue == newEvent.EventGoers[i].Name)
                    {
                        newEvent.EventGoers[i].Seat.Owner = null;
                        newEvent.EventGoers[i].Seat = null;
                        newEvent.EventGoers.RemoveAt(i);
                    }
                }
            }
            updatePeopleToRemove(sortList.SelectedIndex);
            updateEventSummary();
        }

        private void updateEventSummary()
        {
            string eventSummary = "";
            if (newEvent != null && newEvent.EventGoers.Count > 0)
            {
                List<Person> eventGoers = newEvent.GetSortedEventGoers(0);
                if (sortList.SelectedValue != null)
                {
                    eventGoers = newEvent.GetSortedEventGoers(sortList.SelectedIndex);
                }
                eventSummary += $"{"Name",-20} {"Seat",-5} {"Age",-3} {"Price",7}\r\n";
                eventSummary += "------------------- ----- ----- ------\r\n";
                foreach (Person person in eventGoers)
                {
                    eventSummary += $"{person.Name,-20} {person.Seat.Number,4} {person.Age,4} {person.Seat.getCost().ToString("$0.00"),7}\r\n";
                }
                eventSummary += "------------------- ----- ----- ------\r\n";
                eventSummary += "Tickets Sold: " + newEvent.getNumberOfAttendees() + "\r\n";
                eventSummary += "Tickets Available: " + newEvent.getTicketsAvailable() + "\r\n";
                eventSummary += $"{"Total Ticket Prices: "} {newEvent.getTotalPriceOfTicketsSold().ToString("$0.00")}\r\n";
                eventSummary += $"{"Average Ticket Prices: "} {newEvent.getAverageTicketCost().ToString("$0.00")}\r\n";
                if (newEvent.getAvailableSeats().Count == 0)
                {
                    eventSummary += "Available Seats: None" + "\r\n";

                }
                else
                {
                    eventSummary += "Available Seats: " + string.Join(", ", newEvent.getAvailableSeats().Select(seat => seat.Number.ToString())) + "\r\n";
                }
                displayEvent.Text = eventSummary;

            }
            else
            {
                eventSummary += $"{"Name",-20} {"Seat",-5} {"Age",-3} {"Price",7}\r\n";
                eventSummary += "------------------- ----- ----- ------\r\n";
                eventSummary += "Please create an event and/or add ticket purchases\n";
                eventSummary += "------------------- ----- ----- ------\r\n";
                displayEvent.Text = eventSummary;
            }

        }

        protected void personToRemove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (personToRemove.Items.Count > 0 && personToRemove.Items[0].Text == "Choose Person to Remove")
            {
                personToRemove.Items.RemoveAt(0);
            }
        }

        private void updatePeopleToRemove(int sort)
        {
            if (newEvent != null)
            {
                personToRemove.Items.Clear();
                foreach (Person person in newEvent.GetSortedEventGoers(sort))
                {
                    bool personAlreadyInList = false;
                    foreach (ListItem personName in personToRemove.Items)
                    {
                        if (person.Name == personName.Text)
                        {
                            personAlreadyInList = true;
                        }
                    }
                    if (personAlreadyInList == false)
                    {
                        personToRemove.Items.Add(person.Name);
                    }
                }
            }
            else
            {
                personToRemove.Items.Clear();
                personToRemove.Items.Insert(0, "Choose Person to Remove");
            }
        }
        private void loadSpecialConcert()
        {
            catPanel.Visible = true;
            newEvent.Color = "hotpink";
            body.Style["background-color"] = newEvent.Color;
            string filePath = Server.MapPath("~/hw3_conkin/wieMusic.wav");

        }
    }
}
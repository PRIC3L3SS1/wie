using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace hw3_conkin
{
    public partial class _default : System.Web.UI.Page
    {
        Event newEvent;
        SoundPlayer sound = new SoundPlayer("C:\\Users\\easto\\Desktop\\CS3340Workspace\\hw3_conkin\\wieMusic.wav");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                form1.Attributes.Add("autocomplete", "off");
                lblAvailableSeats.Text = "0";
                if (Session["event"] != null)
                {
                    loadSavedSession();

                }
            }
            else
            {
                if (Session["event"] != null)
                {
                    newEvent = (Event)Session["event"];
                    lblAvailableSeats.Text = newEvent.getAvailableSeats().Count.ToString();
                    body.Style["background-color"] = newEvent.Color;
                }
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
                    if (newEvent.Sound == null)
                    {
                        newEvent.Sound = sound;
                        sound.Play();
                    }

                    //ScriptManager.RegisterStartupScript(this, GetType(), "PlayAudio", script, true);
                }
            }

        }

        protected void makeEvent_Click(object sender, EventArgs e)
        {

            try
            {
                newEvent = new Event(eventName.Text, int.Parse(seatMinimum.Text), int.Parse(seatMaximum.Text), null);
                if (eventName.Text == "wie concert")
                {
                    newEvent.Color = "hotpink";
                    


                }
                if (Session["event"] == null)
                {
                    Session.Add("event", newEvent);
                }
                else
                {
                    Session["event"] = newEvent;
                }
                lblAvailableSeats.Text = ((Event)(Session["event"])).getAvailableSeats().Count.ToString();
                lbxAvailableSeats.Items.Clear();
                foreach (Seat seat in newEvent.getAvailableSeats())
                {
                    lbxAvailableSeats.Items.Add(seat.Number.ToString());
                }
                eventName.Text = "";
                seatMinimum.Text = "";
                seatMaximum.Text = "";

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        protected void startOver_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("default.aspx");
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                int parsedAge;
                if (!int.TryParse(age.Text, out parsedAge))
                {
                    // Handle invalid age input
                    //txbDebugInfo.Text = "Invalid age input";
                    return;
                }

                Person newPerson = new Person(name.Text, parsedAge);
                Seat selectedSeat = null;
                for (int i = newEvent.Seats.Count - 1; i >= 0; i--)
                {
                    int selectedValue;

                    if (int.TryParse(lbxAvailableSeats.SelectedValue, out selectedValue))
                    {
                        if (selectedValue == newEvent.Seats[i].Number)
                        {
                            selectedSeat = newEvent.Seats[i];
                            lbxAvailableSeats.Items.Remove(lbxAvailableSeats.SelectedValue);
                            newPerson.Seat = selectedSeat;
                            newEvent.assignSeat(selectedSeat, newPerson);
                            break;
                        }
                    }
                }

                lblAvailableSeats.Text = newEvent.getAvailableSeats().Count.ToString();
                name.Text = "";
                age.Text = "";
            }
            catch (Exception ex)
            {
                //txbDebugInfo.Text = "An error occurred: " + ex.Message;
            }
        }


        //protected void btnPurchase_Click(object sender, EventArgs e)
        //{
        //    Person newPerson = new Person(name.Text, int.Parse(age.Text));



        //    lblAvailableSeats.Text = newEvent.getAvailableSeats().Count.ToString();
        //}


        private void loadSavedSession()
        {
            newEvent = (Event)Session["event"];
            lblAvailableSeats.Text = newEvent.getAvailableSeats().Count.ToString();
            lbxAvailableSeats.Items.Clear();
            foreach (Seat seat in newEvent.getAvailableSeats())
            {
                lbxAvailableSeats.Items.Add(seat.Number.ToString());
            }
        }

        private void loadSpecialConcert()
        {
            catPanel.Visible = true;
            newEvent.Color = "hotpink";
            body.Style["background-color"] = newEvent.Color;
            string filePath = Server.MapPath("~/hw3_conkin/wieMusic.wav");

        }

        protected void btnEventSummary_Click(object sender, EventArgs e)
        {
            
        }
    }
}
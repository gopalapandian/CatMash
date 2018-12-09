using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Scores : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var cats = SessionHelper.Get<List<Cat>>("Cats");
        if (cats != null)
        {
            var catsToDisplay = cats.OrderByDescending(s => s.score);
            rptCats.DataSource = catsToDisplay.Where(c => c.nbmatchsnuls + c.nbvotesgagnants + c.nbvotesperdants > 0);
            rptCats.DataBind();
            int? totalVotesCount = SessionHelper.Get<int>("totalVotesCount");
            lblVotesCount.Text = totalVotesCount.HasValue ? " (" + totalVotesCount.Value.ToString() + " total votes" + ")" : string.Empty;
        }
    }

    protected void rptCats_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var cat = e.Item.DataItem as Cat;
        if (cat != null)
        {
            var imgCat = e.Item.FindControl("imgCat") as Image;
            imgCat.ImageUrl = cat.url;
            var lblCatScore = e.Item.FindControl("lblCatScore") as Label;
            lblCatScore.Text = Math.Round(cat.score, 2).ToString();
            var lblWinningVotes = e.Item.FindControl("lblWinningVotes") as Label;
            lblWinningVotes.Text = cat.nbvotesgagnants.ToString();
            var lblLosingVotes = e.Item.FindControl("lblLosingVotes") as Label;
            lblLosingVotes.Text = cat.nbvotesperdants.ToString();
            var lblInvalidVotes = e.Item.FindControl("lblInvalidVotes") as Label;
            lblInvalidVotes.Text = cat.nbmatchsnuls.ToString();
        }
    }
}